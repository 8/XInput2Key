namespace XInput2Key.Service
{
    using System.IO;
    using System.Reflection;
    using Newtonsoft.Json;
    using XInput2Key.Model;
    using Newtonsoft.Json.Converters;

    public interface ILoadConfigService
    {
        ConfigModel LoadConfig();
        void SaveConfig(ConfigModel configModel);
    }

    public class LoadConfigService : ILoadConfigService
    {
        private string GetConfigFilePath()
        {
            return Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "config.json");
        }

        private JsonSerializer GetSerializer()
        {
            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.Converters.Add(new StringEnumConverter());
            return serializer;
        }

        public ConfigModel LoadConfig()
        {
            using (var reader = new JsonTextReader(File.OpenText(GetConfigFilePath())))
                return GetSerializer().Deserialize<ConfigModel>(reader);
        }

        public void SaveConfig(ConfigModel configModel)
        {
            string filePath = GetConfigFilePath();

            using (var writer = new JsonTextWriter(new StreamWriter(filePath)))
                GetSerializer().Serialize(writer, configModel);
        }
    }
}
