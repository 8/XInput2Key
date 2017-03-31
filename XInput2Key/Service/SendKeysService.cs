using System;
using System.Runtime.InteropServices;

namespace XInput2Key.Service
{
    public interface ISendKeysService
    {
        void SendKeys(string keys);
    }

    public class SendKeysService : ISendKeysService
    {
        private INPUT[] GetInputs(string keys)
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
                            wScan = ScanCodeShort.KEY_H,
                            wVk = VirtualKeyShort.KEY_H
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
                            wScan = ScanCodeShort.KEY_H,
                            wVk = VirtualKeyShort.KEY_H,
                            dwFlags = KEYEVENTF.KEYUP
                        }
                    }
                }
            };
        }

        public void SendKeys(string keys)
        {
            var pInputs = GetInputs(keys);

            NativeApi.SendInput((uint)pInputs.Length, pInputs, INPUT.Size);
        }
    }
}
