using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using PairMatch.ViewModels;

namespace PairMatch.Views
{
    /// <summary>
    ///     Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow
    {
        #region Properties

        private readonly UserViewModel _model = new UserViewModel();

        #endregion

        #region Constructors 

        public NewUserWindow()
        {
            InitializeComponent();
            DataContext = _model;
        }

        #endregion

        #region Private Methods

        private void ArrowButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
            {
                return;
            }

            var buttonName = button.Name;

            if (buttonName == "LeftButton")
            {
                if (_model.AvatarIndex > 0)
                {
                    _model.AvatarIndex--;
                }
            }
            else if (buttonName == "RightButton")
            {
                if (_model.AvatarIndex < UserViewModel.Avatars.Count - 1)
                {
                    _model.AvatarIndex++;
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            var avatarIndex = _model.AvatarIndex;
            var username = UsernameTextBox.Text;

            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (string.IsNullOrEmpty(username) || mainWindow == null ||
                mainWindow.FindName("UsersListBox") is ListBox usersListBox &&
                usersListBox.Items.Cast<UserViewModel>().Select(user => user.Username).Contains(username))
            {
                return;
            }

            mainWindow.Model.Users.Add(new UserViewModel(username, avatarIndex));
            
            var json = JsonConvert.SerializeObject(mainWindow.Model.Users, Formatting.Indented);

            File.WriteAllText("users.json", json);

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}