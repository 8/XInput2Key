namespace XInput2Key.ViewModel
{
    using SharpDX.XInput;
    using System;
    using System.ComponentModel;
    using System.Reactive;
    using System.Windows.Input;
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

        #region IsConnected1
        private bool _IsConnected1;
        public bool IsConnected1
        {
            get { return _IsConnected1; }
            set
            {
                if (_IsConnected1 != value)
                {
                    _IsConnected1 = value;
                    OnPropertyChanged(nameof(IsConnected1));
                }
            }
        }
        #endregion

        #region IsConnected2
        private bool _IsConnected2;
        public bool IsConnected2
        {
            get { return _IsConnected2; }
            set
            {
                if (_IsConnected2 != value)
                {
                    _IsConnected2 = value;
                    OnPropertyChanged(nameof(IsConnected2));
                }
            }
        }
        #endregion

        #region IsConnected3
        private bool _IsConnected3;
        public bool IsConnected3
        {
            get { return _IsConnected3; }
            set
            {
                if (_IsConnected3 != value)
                {
                    _IsConnected3 = value;
                    OnPropertyChanged(nameof(IsConnected3));
                }
            }
        }
        #endregion

        #region IsConnected4
        private bool _IsConnected4;
        public bool IsConnected4
        {
            get { return _IsConnected4; }
            set
            {
                if (_IsConnected4 != value)
                {
                    _IsConnected4 = value;
                    OnPropertyChanged(nameof(IsConnected4));
                }
            }
        }
        #endregion

        private readonly IXInputService XInputService;

        private IDisposable ConnectedSubscription;

        public MainViewModel(IXInputService xinputService)
        {
            this.XInputService = xinputService;

            this.PropertyChanged += this_PropertyChanged;
            this.ConnectedSubscription = xinputService.Connected.Subscribe(new AnonymousObserver<ControllerConnected>(
                controllerConnected =>
                {
                    switch (controllerConnected.UserIndex)
                    {
                        case UserIndex.One: this.Post(() => this.IsConnected1 = controllerConnected.Connected); break;
                        case UserIndex.Two: this.Post(() => this.IsConnected2 = controllerConnected.Connected); break;
                        case UserIndex.Three: this.Post(() => this.IsConnected3 = controllerConnected.Connected); break;
                        case UserIndex.Four: this.Post(() => this.IsConnected4 = controllerConnected.Connected); break;
                    }
                }));
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
