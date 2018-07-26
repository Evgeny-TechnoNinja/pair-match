using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PairMatch.Views;

namespace PairMatch.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        #region Constructors
        
        public GameViewModel()
        {
            GeneratedCards = new ObservableCollection<CardViewModel>();
        }

        #endregion

        #region Properties

        private ObservableCollection<CardViewModel> _generatedCards;

        public ObservableCollection<CardViewModel> GeneratedCards
        {
            get => _generatedCards;
            set
            {
                if (_generatedCards == value)
                {
                    return;
                }

                _generatedCards = value;
                NotifyPropertyChanged(nameof(GeneratedCards));
            }
        }

        private const int StandardRowCount = 4;

        private const int StandardColumnCount = 4;

        private int _customRowCount = StandardRowCount;

        public int CustomRowCount
        {
            get => _customRowCount;
            set
            {
                if (_customRowCount == value)
                {
                    return;
                }

                _customRowCount = value;
                NotifyPropertyChanged(nameof(CustomRowCount));
            }
        }

        private int _customColumnCount = StandardColumnCount;

        public int CustomColumnCount
        {
            get => _customColumnCount;
            set
            {
                if (_customColumnCount == value)
                {
                    return;
                }

                _customColumnCount = value;
                NotifyPropertyChanged(nameof(CustomColumnCount));
            }
        }

        public int RowCount
        {
            get
            {
                var gameWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

                if (gameWindow?.FindName("StandardGameMenuItem") is MenuItem standardGameMenuItem &&
                    !standardGameMenuItem.IsChecked)
                {
                    return CustomRowCount;
                }

                return StandardRowCount;
            }
        }

        public int ColumnCount
        {
            get
            {
                var gameWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

                if (gameWindow?.FindName("StandardGameMenuItem") is MenuItem standardGameMenuItem &&
                    !standardGameMenuItem.IsChecked)
                {
                    return CustomColumnCount;
                }

                return StandardColumnCount;
            }
        }

        private bool _standardGame = true;

        public bool StandardGame
        {
            get => _standardGame;
            set
            {
                if (_standardGame == value)
                {
                    return;
                }

                _standardGame = value;
                NotifyPropertyChanged(nameof(StandardGame));
            }
        }

        private bool _customGame;

        public bool CustomGame
        {
            get => _customGame;
            set
            {
                if (_customGame == value)
                {
                    return;
                }

                _customGame = value;
                NotifyPropertyChanged(nameof(CustomGame));
            }
        }

        private int _timer = 1; // minutes

        public int Timer
        {
            get => _timer;
            set
            {
                if (_timer == value)
                {
                    return;
                }

                _timer = value;
                NotifyPropertyChanged(nameof(Timer));
            }
        }

        private int _timeLeft = 1 * 60 * 1000; // milliseconds

        public int TimeLeft
        {
            get => _timeLeft;
            set
            {
                if (_timeLeft == value)
                {
                    return;
                }

                _timeLeft = value;
                NotifyPropertyChanged(nameof(TimeLeftString));
            }
        }

        public string TimeLeftString => TimeSpan.FromMilliseconds(TimeLeft).ToString("mm':'ss':'fff");

        private int _gameLevel = 1;

        public int GameLevel
        {
            get => _gameLevel;
            set
            {
                if (_gameLevel == value)
                {
                    return;
                }

                _gameLevel = value;
                NotifyPropertyChanged(nameof(GameLevelString));
            }
        }

        public string GameLevelString => "Game " + GameLevel;

        #endregion
    }

    internal class GeneratedCardsCountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var gameWindow = Application.Current.Windows.OfType<GameWindow>().SingleOrDefault();
            var rowCountTextBox = gameWindow?.FindName("RowCountTextBox") as TextBox;
            var columnCountTextBox = gameWindow?.FindName("ColumnCountTextBox") as TextBox;

            if (rowCountTextBox != null && rowCountTextBox.Text != string.Empty && columnCountTextBox != null &&
                columnCountTextBox.Text != string.Empty)
            {
                var rowCount = int.Parse(rowCountTextBox.Text);
                var columnCount = int.Parse(columnCountTextBox.Text);

                var generatedCardsCount = rowCount * columnCount;

                if (columnCount <= 4 && generatedCardsCount <= CardViewModel.FrontImageSources.Count * 2)
                {
                    return new ValidationResult(true, null);
                }
            }

            return new ValidationResult(false, "*");
        }
    }
}