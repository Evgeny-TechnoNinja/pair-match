using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using PairMatch.ViewModels;

namespace PairMatch.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            DataContext = Model;

            UsersListBox.ItemsSource = Model.Users;
        }

        #endregion

        #region Protected Methods

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                if (_newUserWindow != null)
                {
                    _newUserWindow.WindowState = WindowState.Minimized;
                }
                if (_deleteUserWindow != null)
                {
                    _deleteUserWindow.WindowState = WindowState.Minimized;
                }
            }

            base.OnStateChanged(e);
        }

        #endregion

        #region Properties

        internal readonly UsersViewModel Model = new UsersViewModel();

        private NewUserWindow _newUserWindow;
        private DeleteUserWindow _deleteUserWindow;

        #endregion

        #region Private Methods

        private void UsersListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                ScrollBar.LineDownCommand.Execute(null, e.OriginalSource as IInputElement);
            }

            if (e.Delta > 0)
            {
                ScrollBar.LineUpCommand.Execute(null, e.OriginalSource as IInputElement);
            }

            e.Handled = true;
        }

        private void UsersListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DeleteUserButton.IsEnabled = true;
            PlayButton.IsEnabled = true;
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            var newUserWindow = new NewUserWindow();
            newUserWindow.Show();
            newUserWindow.Owner = this;

            _newUserWindow = newUserWindow;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var deleteUserWindow = new DeleteUserWindow(UsersListBox.SelectedItem as UserViewModel);
            deleteUserWindow.Show();
            deleteUserWindow.Owner = this;

            _deleteUserWindow = deleteUserWindow;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var gameWindow = new GameWindow(Model.Users, UsersListBox.SelectedIndex);
            gameWindow.Show();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            //Application.Current.Shutdown();
        }

        #endregion
    }
}