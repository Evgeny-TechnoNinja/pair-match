using System.IO;
using System.Windows;
using Newtonsoft.Json;
using PairMatch.ViewModels;

namespace PairMatch.Views
{
    /// <summary>
    ///     Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow
    {
        #region Properties

        private readonly UserViewModel _model;

        #endregion

        #region Constructors 

        public DeleteUserWindow(UserViewModel user)
        {
            InitializeComponent();

            _model = user;
        }

        #endregion

        #region Private Methods

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.Model.Users.Remove(_model);

                //var json = new JavaScriptSerializer().Serialize(mainWindow.Model.Users);
                var json = JsonConvert.SerializeObject(mainWindow.Model.Users, Formatting.Indented);
                
                File.WriteAllText("users.json", json);

                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}