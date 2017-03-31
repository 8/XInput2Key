namespace XInput2Key.Service
{
    using SharpDX.XInput;
    using System;
    using System.Collections.Generic;
    using XInput2Key.ViewModel;

    public interface IGamepadService
    {
        IEnumerable<GamepadViewModel> Gamepads { get; }
    }

    public class GamepadService : IGamepadService
    {
        private IDisposable ConnectedSubscription;
        private IDisposable KeystateSubscription;

        public IEnumerable<GamepadViewModel> Gamepads { get { return _Gamepads; } }
        public GamepadViewModel[] _Gamepads;

        public GamepadService(IXInputService xinputService)
        {
            var gamepads = this._Gamepads = new[]
            {
                new GamepadViewModel(),
                new GamepadViewModel(),
                new GamepadViewModel(),
                new GamepadViewModel()
            };

            this.ConnectedSubscription = xinputService.Connected.Subscribe(controllerConnected =>
            {
                var gamepad = gamepads[(int)controllerConnected.UserIndex];
                gamepad.Post(() => gamepad.IsConnected = controllerConnected.Connected);
            });

            this.KeystateSubscription = xinputService.Keystrokes.Subscribe(keystroke =>
            {

            });
        }
    }
}
