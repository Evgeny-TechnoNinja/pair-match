using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using PairMatch.ViewModels;
using static System.Byte;

namespace PairMatch.Views
{
    /// <summary>
    ///     Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        #region Constructors

        public GameWindow(IEnumerable<UserViewModel> users, int currentUserIndex)
        {
            InitializeComponent();

            _users =
                new ObservableCollection<UserViewModel>(users as IList<UserViewModel> ?? users.ToList());

            _currentUserIndex = currentUserIndex;
            
            DataContext = _model;
            
            CardsListView.ItemsSource = _model.GeneratedCards;
            
            StatisticsItemsControl.ItemsSource = _users;
        }

        #endregion

        #region Protected Methods

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                if (_aboutWindow != null)
                {
                    _aboutWindow.WindowState = WindowState.Minimized;
                }
            }

            base.OnStateChanged(e);
        }

        #endregion

        #region Properties

        private readonly ObservableCollection<UserViewModel> _users;
        private readonly int _currentUserIndex = 0;

        private readonly GameViewModel _model = new GameViewModel();
        
        private int _firstFlippedCardIndex = -1;
        private int _secondFlippedCardIndex = -1;

        private int _hiddenCardsCount;
        
        private BackgroundWorker _worker;
        private int _workerCount = 0;
        private int _workerIndex = 0;

        private AboutWindow _aboutWindow;

        private const int MaxGameLevel = 3;

        #endregion

        #region Private Methods

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _firstFlippedCardIndex = -1;
            _secondFlippedCardIndex = -1;
            _hiddenCardsCount = 0;

            GenerateCardsList();

            _model.TimeLeft = _model.Timer * 60 * 1000;
            _model.NotifyPropertyChanged(nameof(_model.TimeLeft));
            _model.NotifyPropertyChanged(nameof(_model.RowCount));
            _model.NotifyPropertyChanged(nameof(_model.ColumnCount));
            
            StatisticsGrid.Visibility = Visibility.Hidden;
            GameGrid.Visibility = Visibility.Visible;

            GameOverLabel.Visibility = Visibility.Hidden;
            NextGameButton.Visibility = Visibility.Hidden;

            LevelLabel.Visibility = Visibility.Visible;
            TimeLeftLabel.Visibility = Visibility.Visible;
            TimerLabel.Visibility = Visibility.Visible;
            CardsListView.Visibility = Visibility.Visible;

            SetupCountdown();
        }

        private void GenerateCardsList()
        {
            _model.GeneratedCards.Clear();

            var maxCardCount = CardViewModel.FrontImageSources.Count;
            var generatedCardsCount = _model.RowCount * _model.ColumnCount;
            if (generatedCardsCount % 2 != 0)
            {
                generatedCardsCount--;
            }

            var generatedIndeces = new List<int>();

            var rand = new Random();
            for (var i = 0; i < generatedCardsCount / 2; i++)
            {
                int randIndex;
                do
                {
                    randIndex = rand.Next(0, maxCardCount);
                } while (generatedIndeces.Contains(randIndex));

                generatedIndeces.Add(randIndex);

                var firstCard = new CardViewModel(CardViewModel.FrontImageSources[randIndex]);
                _model.GeneratedCards.Add(firstCard);

                var secondCard = new CardViewModel(CardViewModel.FrontImageSources[randIndex]);
                _model.GeneratedCards.Add(secondCard);
            }

            var provider = new RNGCryptoServiceProvider();

            while (generatedCardsCount > 1)
            {
                var box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                } while (!(box[0] < generatedCardsCount * (MaxValue / generatedCardsCount)));

                var k = box[0] % generatedCardsCount;

                generatedCardsCount--;

                var temp = _model.GeneratedCards[k];
                _model.GeneratedCards[k] = _model.GeneratedCards[generatedCardsCount];
                _model.GeneratedCards[generatedCardsCount] = temp;
            }
        }

        private void SetupCountdown()
        {
            _worker = new BackgroundWorker();

            _worker.DoWork += delegate
            {
                while (_model.TimeLeft > 0)
                {
                    _model.TimeLeft -= 1;
                    Thread.Sleep(1);
                }
            };

            _worker.RunWorkerCompleted += delegate
            {
                FinishGame(false);

                _workerCount--;
            };

            _worker.WorkerSupportsCancellation = true;

            _worker.RunWorkerAsync();

            _workerCount++;
        }

        private void StatisticsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameGrid.Visibility = Visibility.Hidden;
            StatisticsGrid.Visibility = Visibility.Visible;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void OptionsMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            if (menuItem?.Name == nameof(StandardGameMenuItem))
            {
                _model.CustomGame = false;
            }
            else
            {
                _model.StandardGame = false;
            }
        }

        private void OptionsMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            var gameType = sender as MenuItem;

            if (gameType?.Name == nameof(StandardGameMenuItem))
            {
                _model.CustomGame = true;
            }
            else
            {
                _model.StandardGame = true;
            }
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
            aboutWindow.Owner = this;

            _aboutWindow = aboutWindow;
        }

        private void CardsListView_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            var selectedCardImage = e.OriginalSource as Image;
            var selectedCard = selectedCardImage?.DataContext as CardViewModel;
            var selectedIndex = _model.GeneratedCards.IndexOf(selectedCard);

            if (selectedCard != null && Equals(selectedCard, CardViewModel.HiddenCard) ||
                _firstFlippedCardIndex != -1 && _firstFlippedCardIndex == selectedIndex ||
                _secondFlippedCardIndex != -1)
            {
                e.Handled = true;
            }
        }

        private async void CardsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var list = sender as ListView;
            var selectedCard = list?.SelectedItem as CardViewModel;

            if (selectedCard == null || Equals(selectedCard, CardViewModel.HiddenCard))
            {
                return;
            }

            var selectedIndex = list.SelectedIndex;

            if (_firstFlippedCardIndex == -1)
            {
                _firstFlippedCardIndex = selectedIndex;
            }
            else
            {
                _secondFlippedCardIndex = selectedIndex;

                if (_secondFlippedCardIndex != _firstFlippedCardIndex)
                {
                    await Task.Delay(1500);

                    if (!_model.GeneratedCards[_secondFlippedCardIndex].IsFlipped &&
                        !_model.GeneratedCards[_firstFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_secondFlippedCardIndex].FrontImage ==
                        _model.GeneratedCards[_firstFlippedCardIndex].FrontImage ||
                        _model.GeneratedCards[_secondFlippedCardIndex].IsFlipped &&
                        !_model.GeneratedCards[_firstFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_secondFlippedCardIndex].BackImage ==
                        _model.GeneratedCards[_firstFlippedCardIndex].FrontImage ||
                        !_model.GeneratedCards[_secondFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_firstFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_secondFlippedCardIndex].FrontImage ==
                        _model.GeneratedCards[_firstFlippedCardIndex].BackImage ||
                        _model.GeneratedCards[_secondFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_firstFlippedCardIndex].IsFlipped &&
                        _model.GeneratedCards[_secondFlippedCardIndex].BackImage ==
                        _model.GeneratedCards[_firstFlippedCardIndex].BackImage)
                    {
                        _model.GeneratedCards[_firstFlippedCardIndex] = CardViewModel.HiddenCard;
                        _model.GeneratedCards[_secondFlippedCardIndex] = CardViewModel.HiddenCard;

                        _hiddenCardsCount += 2;

                        if (_hiddenCardsCount == _model.GeneratedCards.Count)
                        {
                            FinishGame(true);
                        }
                    }
                    else
                    {
                        // OPTIONAL: Animate the two cards flipping

                        _model.GeneratedCards[_firstFlippedCardIndex].Flip();
                        _model.GeneratedCards[_secondFlippedCardIndex].Flip();
                    }
                }

                _firstFlippedCardIndex = -1;
                _secondFlippedCardIndex = -1;
            }
        }

        private void FinishGame(bool userWon)
        {
            if (_workerIndex > 0)
            {
                if (_workerIndex == _workerCount - 1)
                {
                    _workerIndex = 0;
                }

                return;
            }

            _workerIndex++;

            if (userWon)
            {
                if (_model.GameLevel < MaxGameLevel)
                {
                    _model.GameLevel++;

                    NextGameButton.Content = "Next Game";
                }
                else
                {
                    _model.GameLevel = 1;

                    if (_model.StandardGame)
                    {
                        _users[_currentUserIndex].StandardWonGamesCount++;
                    }
                    else
                    {
                        _users[_currentUserIndex].CustomWonGamesCount++;
                    }

                    NextGameButton.Content = "Play Again";
                }

                GameOverLabel.Content = "You wooooon!";
            }
            else
            {
                _model.GameLevel = 1;

                if (_model.StandardGame)
                {
                    _users[_currentUserIndex].StandardLostGamesCount++;
                }
                else
                {
                    _users[_currentUserIndex].CustomLostGamesCount++;
                }

                GameOverLabel.Content = "Time's up!";
                NextGameButton.Content = "Play Again";
            }
            
            LevelLabel.Visibility = Visibility.Hidden;
            TimeLeftLabel.Visibility = Visibility.Hidden;
            TimerLabel.Visibility = Visibility.Hidden;
            CardsListView.Visibility = Visibility.Hidden;

            GameOverLabel.Visibility = Visibility.Visible;
            NextGameButton.Visibility = Visibility.Visible;

            var json = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }

        #endregion
    }
}