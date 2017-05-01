namespace XInput2Key.Factory
{
    using System.Collections.Generic;

    public interface IInputFactory
    {
        INPUT[] GetKeyDownUp(InputKey key);
    }

    public class InputFactory : IInputFactory
    {
        class ScanCodeVirtualKey
        {
            public ScanCodeShort ScanCodeShort { get; set; }
            public VirtualKeyShort VirtualKeyShort { get; set; }
        }

        private Dictionary<InputKey, ScanCodeVirtualKey> Lookup;

        public InputFactory()
        {
            this.Lookup = new Dictionary<InputKey, ScanCodeVirtualKey>
            {
                { InputKey.F1, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F1, VirtualKeyShort = VirtualKeyShort.F1 } },
                { InputKey.F2, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F2, VirtualKeyShort = VirtualKeyShort.F2 } },
                { InputKey.F3, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F3, VirtualKeyShort = VirtualKeyShort.F3 } },
                { InputKey.F4, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F4, VirtualKeyShort = VirtualKeyShort.F4 } },
                { InputKey.F5, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F5, VirtualKeyShort = VirtualKeyShort.F5 } },
                { InputKey.F6, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F6, VirtualKeyShort = VirtualKeyShort.F6 } },
                { InputKey.F7, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F7, VirtualKeyShort = VirtualKeyShort.F7 } },
                { InputKey.F8, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F8, VirtualKeyShort = VirtualKeyShort.F8 } },
                { InputKey.F9, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F9, VirtualKeyShort = VirtualKeyShort.F9 } },
                { InputKey.F10, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F10, VirtualKeyShort = VirtualKeyShort.F10 } },
                { InputKey.F11, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F11, VirtualKeyShort = VirtualKeyShort.F11 } },
                { InputKey.F12, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.F12, VirtualKeyShort = VirtualKeyShort.F12 } },
                { InputKey.a, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_A, VirtualKeyShort = VirtualKeyShort.KEY_A} },
                { InputKey.b, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_B, VirtualKeyShort = VirtualKeyShort.KEY_B} },
                { InputKey.x, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_X, VirtualKeyShort = VirtualKeyShort.KEY_X} },
                { InputKey.y, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_Y, VirtualKeyShort = VirtualKeyShort.KEY_Y} },
                { InputKey.l, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_L, VirtualKeyShort = VirtualKeyShort.KEY_L} },
                { InputKey.r, new ScanCodeVirtualKey{ ScanCodeShort = ScanCodeShort.KEY_R, VirtualKeyShort = VirtualKeyShort.KEY_R} },
                { InputKey.Left, new ScanCodeVirtualKey { ScanCodeShort = ScanCodeShort.LEFT, VirtualKeyShort = VirtualKeyShort.LEFT } },
                { InputKey.Right, new ScanCodeVirtualKey { ScanCodeShort = ScanCodeShort.RIGHT, VirtualKeyShort = VirtualKeyShort.RIGHT } },
                { InputKey.Up, new ScanCodeVirtualKey { ScanCodeShort = ScanCodeShort.UP, VirtualKeyShort = VirtualKeyShort.UP} },
                { InputKey.Down, new ScanCodeVirtualKey { ScanCodeShort = ScanCodeShort.DOWN, VirtualKeyShort = VirtualKeyShort.DOWN } }
            };
        }

        public INPUT[] GetKeyDownUp(InputKey key)
        {
            INPUT[] ret;
            ScanCodeVirtualKey value;
            if (this.Lookup.TryGetValue(key, out value))
                ret = GetUpDown(value.ScanCodeShort, value.VirtualKeyShort);
            else
                ret = new INPUT[0];
            return ret;
        }

        private INPUT[] GetUpDown(ScanCodeShort scanCodeShort, VirtualKeyShort virtualKeyShort)
        {
            return new[]
              {
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wScan = scanCodeShort,
                            wVk = virtualKeyShort
                        }
                    }
                },
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wScan = scanCodeShort,
                            wVk = virtualKeyShort,
                            dwFlags = KEYEVENTF.KEYUP
                        }
                    }
                }
            };
        }
    }
}
