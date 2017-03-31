namespace XInput2Key.Service
{
    using System;
    using System.Collections.Generic;
    using SharpDX.XInput;
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
                var gamepad = gamepads[(int)keystroke.UserIndex];

                switch (keystroke.VirtualKey)
                {
                    case GamepadKeyCode.A: gamepad.Post(() => gamepad.IsAPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.B: gamepad.Post(() => gamepad.IsBPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.X: gamepad.Post(() => gamepad.IsXPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.Y: gamepad.Post(() => gamepad.IsYPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.LeftTrigger: gamepad.Post(() => gamepad.IsLeftTriggerPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.RightTrigger: gamepad.Post(() => gamepad.IsRightTriggerPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.LeftShoulder: gamepad.Post(() => gamepad.IsLeftShoulderPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.RightShoulder: gamepad.Post(() => gamepad.IsRightShoulderPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.Start: gamepad.Post(() => gamepad.IsStartPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                    case GamepadKeyCode.Back: gamepad.Post(() => gamepad.IsBackPressed = (keystroke.Flags == KeyStrokeFlags.KeyDown)); break;
                }
            });
        }
    }
}
