namespace XInput2Key.Model
{
    using SharpDX.XInput;
    using XInput2Key.Factory;

    public class ConfigButtonModel
    {
        public InputKey Key { get; set; }
        public GamepadKeyCode Button { get; set; }
    }

    public class ConfigModel
    {
        public ConfigButtonModel[] Buttons { get; set; }
    }
}
