namespace XInput2Key.ViewModel
{
    using SharpDX.XInput;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using XInput2Key.Factory;

    public interface IButtonMappingViewModel
    {
    }

    public class ButtonMappingItemViewModel
    {
        public InputKey Key { get; set; }
        public GamepadKeyCode  Button { get; set; }
    }

    public class ButtonMappingViewModel : BasePropertyChanged, IButtonMappingViewModel
    {
        public IEnumerable<ButtonMappingItemViewModel> Items { get; private set; }

        public IEnumerable<InputKey> AllKeys { get; private set; }

        public ButtonMappingViewModel()
        {
            this.Items = GetItems();
            this.AllKeys = (InputKey[])Enum.GetValues(typeof(InputKey));
        }

        private IEnumerable<ButtonMappingItemViewModel> GetItems()
        {
            return ((GamepadKeyCode[])Enum.GetValues(typeof(GamepadKeyCode)))
                .Select(b => new ButtonMappingItemViewModel { Button = b, Key = InputKey.F1 })
                .ToArray();
        }
    }
}
