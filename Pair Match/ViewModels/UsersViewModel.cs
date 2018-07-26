using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace PairMatch.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        #region Constructors

        public UsersViewModel()
        {
            Users = new ObservableCollection<UserViewModel>();

            using (var sr = new StreamReader("users.json"))
            {
                var json = sr.ReadToEnd();
                Users = JsonConvert.DeserializeObject<ObservableCollection<UserViewModel>>(json);
            }
        }

        #endregion

        #region Properties

        private ObservableCollection<UserViewModel> _users;

        public ObservableCollection<UserViewModel> Users
        {
            get => _users;
            set
            {
                if (_users == value)
                {
                    return;
                }

                _users = value;
                NotifyPropertyChanged(nameof(Users));
            }
        }

        #endregion
    }
}