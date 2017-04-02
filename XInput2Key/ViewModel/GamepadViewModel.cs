namespace XInput2Key.ViewModel
{
    public interface IGamepadViewModel
    {
    }

    public class GamepadViewModel : BasePropertyChanged
    {
        #region IsConnected
        private bool _IsConnected;
        public bool IsConnected
        {
            get { return _IsConnected; }
            set
            {
                if (_IsConnected != value)
                {
                    _IsConnected = value;
                    OnPropertyChanged(nameof(IsConnected));
                }
            }
        }
        #endregion

        #region IsAPressed
        private bool _IsAPressed;
        public bool IsAPressed
        {
            get { return _IsAPressed; }
            set
            {
                if (_IsAPressed != value)
                {
                    _IsAPressed = value;
                    OnPropertyChanged(nameof(IsAPressed));
                }
            }
        }
        #endregion

        #region IsBPressed
        private bool _IsBPressed;
        public bool IsBPressed
        {
            get { return _IsBPressed; }
            set
            {
                if (_IsBPressed != value)
                {
                    _IsBPressed = value;
                    OnPropertyChanged(nameof(IsBPressed));
                }
            }
        }
        #endregion

        #region IsXPressed
        private bool _IsXPressed;
        public bool IsXPressed
        {
            get { return _IsXPressed; }
            set
            {
                if (_IsXPressed != value)
                {
                    _IsXPressed = value;
                    OnPropertyChanged(nameof(IsXPressed));
                }
            }
        }
        #endregion

        #region IsYPressed
        private bool _IsYPressed;
        public bool IsYPressed
        {
            get { return _IsYPressed; }
            set
            {
                if (_IsYPressed != value)
                {
                    _IsYPressed = value;
                    OnPropertyChanged(nameof(IsYPressed));
                }
            }
        }
        #endregion

        #region IsStartPressed
        private bool _IsStartPressed;
        public bool IsStartPressed
        {
            get { return _IsStartPressed; }
            set
            {
                if (_IsStartPressed != value)
                {
                    _IsStartPressed = value;
                    OnPropertyChanged(nameof(IsStartPressed));
                }
            }
        }
        #endregion

        #region IsBackPressed
        private bool _IsBackPressed;
        public bool IsBackPressed
        {
            get { return _IsBackPressed; }
            set
            {
                if (_IsBackPressed != value)
                {
                    _IsBackPressed = value;
                    OnPropertyChanged(nameof(IsBackPressed));
                }
            }
        }
        #endregion

        #region IsLeftTriggerPressed
        private bool _IsLeftTriggerPressed;
        public bool IsLeftTriggerPressed
        {
            get { return _IsLeftTriggerPressed; }
            set
            {
                if (_IsLeftTriggerPressed != value)
                {
                    _IsLeftTriggerPressed = value;
                    OnPropertyChanged(nameof(IsLeftTriggerPressed));
                }
            }
        }
        #endregion

        #region IsRightTriggerPressed
        private bool _IsRightTriggerPressed;
        public bool IsRightTriggerPressed
        {
            get { return _IsRightTriggerPressed; }
            set
            {
                if (_IsRightTriggerPressed != value)
                {
                    _IsRightTriggerPressed = value;
                    OnPropertyChanged(nameof(IsRightTriggerPressed));
                }
            }
        }
        #endregion

        #region IsLeftShoulderPressed
        private bool _IsLeftShoulderPressed;
        public bool IsLeftShoulderPressed
        {
            get { return _IsLeftShoulderPressed; }
            set
            {
                if (_IsLeftShoulderPressed != value)
                {
                    _IsLeftShoulderPressed = value;
                    OnPropertyChanged(nameof(IsLeftShoulderPressed));
                }
            }
        }
        #endregion

        #region IsRightShoulderPressed
        private bool _IsRightShoulderPressed;
        public bool IsRightShoulderPressed
        {
            get { return _IsRightShoulderPressed; }
            set
            {
                if (_IsRightShoulderPressed != value)
                {
                    _IsRightShoulderPressed = value;
                    OnPropertyChanged(nameof(IsRightShoulderPressed));
                }
            }
        }
        #endregion

        #region IsDPadLeftPressed
        private bool _IsDPadLeftPressed;
        public bool IsDPadLeftPressed
        {
            get { return _IsDPadLeftPressed; }
            set
            {
                if (_IsDPadLeftPressed != value)
                {
                    _IsDPadLeftPressed = value;
                    OnPropertyChanged(nameof(IsDPadLeftPressed));
                }
            }
        }
        #endregion

        #region IsDPadUpPressed
        private bool _IsDPadUpPressed;
        public bool IsDPadUpPressed
        {
            get { return _IsDPadUpPressed; }
            set
            {
                if (_IsDPadUpPressed != value)
                {
                    _IsDPadUpPressed = value;
                    OnPropertyChanged(nameof(IsDPadUpPressed));
                }
            }
        }
        #endregion

        #region IsDPadRightPressed
        private bool _IsDPadRightPressed;
        public bool IsDPadRightPressed
        {
            get { return _IsDPadRightPressed; }
            set
            {
                if (_IsDPadRightPressed != value)
                {
                    _IsDPadRightPressed = value;
                    OnPropertyChanged(nameof(IsDPadRightPressed));
                }
            }
        }
        #endregion

        #region IsDPadDownPressed
        private bool _IsDPadDownPressed;
        public bool IsDPadDownPressed
        {
            get { return _IsDPadDownPressed; }
            set
            {
                if (_IsDPadDownPressed != value)
                {
                    _IsDPadDownPressed = value;
                    OnPropertyChanged(nameof(IsDPadDownPressed));
                }
            }
        }
        #endregion

        #region Name
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        #endregion

        public GamepadViewModel()
        {
        }

    }
}
