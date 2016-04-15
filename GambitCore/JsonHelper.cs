namespace GambitCore
{
    using Newtonsoft.Json;

    internal class JsonHelper
    {
        static JsonHelper()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.DateTime,
            };
        }

        public static T ToItem<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
