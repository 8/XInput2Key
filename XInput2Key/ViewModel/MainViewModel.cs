namespace XInput2Key.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using XInput2Key.Service;

    public interface IMainViewModel
    {
    }

    public class MainViewModel : BasePropertyChanged, IMainViewModel
    {
        #region IsListening
        private bool _IsListening;
        public bool IsListening
        {
            get { return _IsListening; }
            set
            {
                if (_IsListening != value)
                {
                    _IsListening = value;
                    OnPropertyChanged(nameof(IsListening));
                }
            }
        }
        #endregion

        public IEnumerable<GamepadViewModel> Gamepads { get { return this.GamepadService.Gamepads; } }

        private readonly IXInputService XInputService;
        private readonly ISendKeysService SendKeysService;
        private readonly IGamepadService GamepadService;

        public MainViewModel(IXInputService xinputService,
                             ISendKeysService sendKeysService,
                             IGamepadService gamepadService)
        {
            this.XInputService = xinputService;
            this.SendKeysService = sendKeysService;
            this.GamepadService = gamepadService;

            this.PropertyChanged += this_PropertyChanged;

            this.IsListening = true;
        }

        private void this_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsListening):
                    this.XInputService.IsListening = this.IsListening;
                    break;
            }
        }
    }
}
