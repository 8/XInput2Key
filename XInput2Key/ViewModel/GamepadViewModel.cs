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


    }
}
