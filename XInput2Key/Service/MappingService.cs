namespace XInput2Key.Service
{
    using SharpDX.XInput;
    using System.Collections.Generic;
    using System.Linq;
    using XInput2Key.Factory;
    using XInput2Key.Model;

    public interface IMappingService
    {
        InputKey? Map(GamepadKeyCode gamepadKeyCode);
    }

    public class MappingService : IMappingService
    {
        private readonly IConfigModelService ConfigModelService;

        public MappingService(IConfigModelService configModelService)
        {
            this.ConfigModelService = configModelService;
        }

        private Dictionary<GamepadKeyCode, InputKey> CachedLookup;
        private ConfigModel CachedConfigModel;

        private Dictionary<GamepadKeyCode, InputKey> GetKeyLookup()
        {
            Dictionary<GamepadKeyCode, InputKey> lookup;

            var configModel = this.ConfigModelService.ConfigModel;

            if (this.CachedConfigModel == configModel)
                lookup = CachedLookup;
            else
            {
                lookup = configModel.Buttons
                    .GroupBy(b => b.Button).Select(g => g.FirstOrDefault()) /* make the buttons unique */
                    .ToDictionary(b => b.Button, b => b.Key);

                this.CachedLookup = lookup;
                this.CachedConfigModel = configModel;
            }

            return lookup;
        }

        public InputKey? Map(GamepadKeyCode gamepadKeyCode)
        {
            var lookup = GetKeyLookup();

            InputKey? ret;
            if (lookup.TryGetValue(gamepadKeyCode, out InputKey key))
                ret = key;
            else
                ret = null;

            return ret;

            //this.ConfigModelService.ConfigModel.
            //InputKey? key;
            //switch (gamepadKeyCode)
            //{
            //    case GamepadKeyCode.A: key = InputKey.a; break;
            //    case GamepadKeyCode.B: key = InputKey.b; break;
            //    case GamepadKeyCode.X: key = InputKey.x; break;
            //    case GamepadKeyCode.Y: key = InputKey.y; break;
            //    case GamepadKeyCode.LeftShoulder: key = InputKey.l; break;
            //    case GamepadKeyCode.RightShoulder: key = InputKey.r; break;
            //    default: key = null; break;
            //}
            //return key;
        }
    }
}
