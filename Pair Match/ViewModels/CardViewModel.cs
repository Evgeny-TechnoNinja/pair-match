using System;
using System.Collections.Generic;

namespace PairMatch.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        #region Constructors
        
        public CardViewModel(string frontImageSource)
        {
            FrontImage = new Uri("pack://application:,,," + frontImageSource);
            BackImage = new Uri("pack://application:,,," + BackImageSource);
        }

        #endregion

        #region Class Properties

        private const string BackImageSource = "/Resources/card-back.png";

        private const string HiddenCardImageSource = "/Resources/card-hidden.png";

        public static CardViewModel HiddenCard => new CardViewModel(HiddenCardImageSource)
        {
            BackImage = new Uri("pack://application:,,," + HiddenCardImageSource)
        };

        public static List<string> FrontImageSources => new List<string>
        {
            "/Resources/card01.png",
            "/Resources/card02.png",
            "/Resources/card03.png",
            "/Resources/card04.png",
            "/Resources/card05.png",
            "/Resources/card06.png",
            "/Resources/card07.png",
            "/Resources/card08.png",
            "/Resources/card09.png",
            "/Resources/card10.png",
            "/Resources/card11.png",
            "/Resources/card12.png",
            "/Resources/card13.png"
        };

        #endregion

        #region Instance Properties

        private Uri _frontImage;

        public Uri FrontImage
        {
            get => _frontImage;
            set
            {
                if (_frontImage == value)
                {
                    return;
                }

                _frontImage = value;
                NotifyPropertyChanged(nameof(FrontImage));
            }
        }

        private Uri _backImage;

        public Uri BackImage
        {
            get => _backImage;
            set
            {
                if (_backImage == value)
                {
                    return;
                }

                _backImage = value;
                NotifyPropertyChanged(nameof(BackImage));
            }
        }

        public bool IsFlipped;
        
        #endregion

        #region Public Methods

        public void Flip()
        {
            var temp = FrontImage;
            FrontImage = BackImage;
            BackImage = temp;

            IsFlipped = BackImage != new Uri("pack://application:,,," + BackImageSource);
        }

        #endregion
    }
}