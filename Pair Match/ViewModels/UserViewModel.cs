using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PairMatch.Views;

namespace PairMatch.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Constructors

        public UserViewModel()
        {
        }

        public UserViewModel(string username, int avatarIndex)
        {
            Username = username;
            AvatarIndex = avatarIndex;
        }

        #endregion

        #region Properties

        public static List<string> Avatars => new List<string>
        {
            "/Resources/avatar01.jpg",
            "/Resources/avatar02.jpg",
            "/Resources/avatar03.jpg",
            "/Resources/avatar04.jpg",
            "/Resources/avatar05.jpg",
            "/Resources/avatar06.jpg"
        };

        private int _avatarIndex;

        public int AvatarIndex
        {
            get => _avatarIndex;
            set
            {
                if (_avatarIndex == value)
                {
                    return;
                }

                _avatarIndex = value;
                NotifyPropertyChanged(nameof(Avatar));
            }
        }

        public string Avatar => Avatars[AvatarIndex];
        
        private int _standardLostGamesCount;

        public int StandardLostGamesCount
        {
            get => _standardLostGamesCount;
            set
            {
                if (_standardLostGamesCount == value)
                {
                    return;
                }

                _standardLostGamesCount = value;
                NotifyPropertyChanged(nameof(StandardLostGamesCount));
                NotifyPropertyChanged(nameof(StandardPlayedGamesCount));
            }
        }
        
        private int _standardWonGamesCount;

        public int StandardWonGamesCount
        {
            get => _standardWonGamesCount;
            set
            {
                if (_standardWonGamesCount == value)
                {
                    return;
                }

                _standardWonGamesCount = value;
                NotifyPropertyChanged(nameof(StandardWonGamesCount));
                NotifyPropertyChanged(nameof(StandardPlayedGamesCount));
            }
        }

        public int StandardPlayedGamesCount => StandardLostGamesCount + StandardWonGamesCount;

        private int _customLostGamesCount;

        public int CustomLostGamesCount
        {
            get => _customLostGamesCount;
            set
            {
                if (_customLostGamesCount == value)
                {
                    return;
                }

                _customLostGamesCount = value;
                NotifyPropertyChanged(nameof(CustomLostGamesCount));
                NotifyPropertyChanged(nameof(CustomPlayedGamesCount));
            }
        }

        private int _customWonGamesCount;

        public int CustomWonGamesCount
        {
            get => _customWonGamesCount;
            set
            {
                if (_customWonGamesCount == value)
                {
                    return;
                }

                _customWonGamesCount = value;
                NotifyPropertyChanged(nameof(CustomWonGamesCount));
                NotifyPropertyChanged(nameof(CustomPlayedGamesCount));
            }
        }

        public int CustomPlayedGamesCount => CustomLostGamesCount + CustomWonGamesCount;

        public string Username { get; set; }

        #endregion
    }

    internal class UsernameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return new ValidationResult(false, "I think you forgot something...");
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow?.FindName("UsersListBox") is ListBox usersListBox && usersListBox.Items.Cast<UserViewModel>()
                    .Select(user => user.Username).Contains(value.ToString()))
            {
                return new ValidationResult(false, "Ooops! Someone already took that username.");
            }

            return new ValidationResult(true, null);
        }
    }
}