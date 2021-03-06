﻿namespace XInput2Key.Service
{
    using System;
    using SharpDX.XInput;
    using XInput2Key.Factory;

    public interface IKeyboardEmulatorService
    {
        bool IsEnabled { get; set; }
    }

    class KeyboardEmulatorService : IKeyboardEmulatorService
    {
        private IDisposable KeystrokeSubscription;

        public bool IsEnabled { get; set; }

        public KeyboardEmulatorService(ISendKeysService sendKeysService,
                                       IXInputService xinputService,
                                       IInputFactory inputFactory,
                                       IMappingService mappingService)
        {
            this.KeystrokeSubscription = xinputService.Keystrokes.Subscribe(keystroke =>
            {
                if (this.IsEnabled)
                {
                    if (keystroke.Flags == KeyStrokeFlags.KeyDown)
                    {
                        var key = mappingService.Map(keystroke.VirtualKey);
                        if (key != null)
                        {
                            var inputs = inputFactory.GetKeyDownUp(key.Value);
                            sendKeysService.SendKeys(inputs);
                        }
                    }
                }
            });
        }
    }
}
