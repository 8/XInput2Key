namespace XInput2Key.Service
{
    using SharpDX.XInput;
    using System;
    using XInput2Key.Factory;
    using XInput2Key.Model;

    public interface IConfigModelService
    {
        ConfigModel ConfigModel { get; set; }
    }

    public class ConfigModelService : IConfigModelService
    {
        public ConfigModel ConfigModel { get; set; }

        private readonly ILoadConfigService LoadConfigService;

        public ConfigModelService(ILoadConfigService loadConfigService)
        {
            this.LoadConfigService = loadConfigService;

            this.ConfigModel = LoadConfig();
        }

        private ConfigModel LoadConfig()
        {
            ConfigModel configModel;
            try { configModel = this.LoadConfigService.LoadConfig(); }
            catch
            {
                configModel = GetDefaultConfigModel();

                try { this.LoadConfigService.SaveConfig(configModel); }
                catch { }
            }
            return configModel;
        }

        private ConfigModel GetDefaultConfigModel()
        {
            return new ConfigModel
            {
                Buttons = new ConfigButtonModel[]
                {
                    new ConfigButtonModel{ Button = GamepadKeyCode.A, Key = InputKey.a },
                    new ConfigButtonModel{ Button = GamepadKeyCode.B, Key = InputKey.b },
                    new ConfigButtonModel{ Button = GamepadKeyCode.X, Key = InputKey.x },
                    new ConfigButtonModel{ Button = GamepadKeyCode.Y, Key = InputKey.y },
                    new ConfigButtonModel{ Button = GamepadKeyCode.LeftShoulder, Key = InputKey.l },
                    new ConfigButtonModel{ Button  = GamepadKeyCode.RightShoulder, Key = InputKey.r },
                    new ConfigButtonModel{ Button = GamepadKeyCode.DPadLeft, Key = InputKey.Left },
                    new ConfigButtonModel{ Button = GamepadKeyCode.DPadUp, Key = InputKey.Up },
                    new ConfigButtonModel{ Button = GamepadKeyCode.DPadRight, Key = InputKey.Right },
                    new ConfigButtonModel{ Button = GamepadKeyCode.DPadDown, Key = InputKey.Down }
                }
            };
        }
    }
}
