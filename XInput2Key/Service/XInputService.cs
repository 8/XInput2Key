namespace XInput2Key.Service
{
    using System;
    using System.Reactive.Subjects;
    using System.Threading;
    using SharpDX.XInput;

    public struct ControllerConnected
    {
        public ControllerConnected(UserIndex userIndex, bool connected)
        {
            this.UserIndex = userIndex;
            this.Connected = connected;
        }

        public UserIndex UserIndex { get; private set; }
        public bool Connected { get; private set; }
    }

    public interface IXInputService
    {
        bool IsListening { get; set; }
        IObservable<Keystroke> Keystrokes { get; }
        IObservable<ControllerConnected> Connected { get; }
    }

    public class XInputService : IXInputService
    {
        private bool _IsListening = false;
        private Thread PollingLoop = null;
        public bool IsListening { get { return this._IsListening; } set { this.SetListening(value, this.Controllers); } }

        private Subject<ControllerConnected> ConnectedSubject;
        public IObservable<ControllerConnected> Connected { get { return this.ConnectedSubject; } }

        private Subject<Keystroke> KeystrokeSubject;
        public IObservable<Keystroke> Keystrokes { get { return this.KeystrokeSubject; } }

        private Controller[] Controllers;

        public XInputService()
        {
            this.KeystrokeSubject = new Subject<Keystroke>();
            this.ConnectedSubject = new Subject<ControllerConnected>();

            this.Controllers = new[] {
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four),
            };
        }

        private void SetListening(bool enable, params Controller[] controllers)
        {
            void PollController(Controller controller)
            {
                this.ConnectedSubject.OnNext(new ControllerConnected(controller.UserIndex, controller.IsConnected));

                Keystroke keystroke;
                var result = controller.GetKeystroke(DeviceQueryType.Gamepad, out keystroke);
                if (result.Success)
                    this.KeystrokeSubject.OnNext(keystroke);
            }

            /* if an action is required */
            if (_IsListening != enable)
            {
                /* signal the thread what it should do */
                this._IsListening = enable;

                if (enable)
                {
                    var thread = this.PollingLoop = new Thread(new ThreadStart(() =>
                    {
                        while (_IsListening)
                        {
                            foreach (var controller in controllers)
                                PollController(controller);
                            Thread.Sleep(1000 / 25);
                        }
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                else
                {
                    this.PollingLoop.Join();
                    this.PollingLoop = null;
                }
            }
        }

    }
}
