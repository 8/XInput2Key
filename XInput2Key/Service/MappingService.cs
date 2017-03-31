namespace XInput2Key.Service
{
    using SharpDX.XInput;
    using XInput2Key.Factory;

    public interface IMappingService
    {
        InputKey? Map(GamepadKeyCode gamepadKeyCode);
    }

    public class MappingService : IMappingService
    {
        public InputKey? Map(GamepadKeyCode gamepadKeyCode)
        {
            InputKey? key;
            switch (gamepadKeyCode)
            {
                case GamepadKeyCode.A: key = InputKey.a; break;
                case GamepadKeyCode.B: key = InputKey.b; break;
                case GamepadKeyCode.X: key = InputKey.x; break;
                case GamepadKeyCode.Y: key = InputKey.y; break;
                case GamepadKeyCode.LeftShoulder: key = InputKey.l; break;
                case GamepadKeyCode.RightShoulder: key = InputKey.r; break;
                default: key = null; break;
            }
            return key;
        }
    }
}
