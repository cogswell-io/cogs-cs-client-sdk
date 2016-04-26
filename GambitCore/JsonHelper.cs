namespace GambitCore
{
    using Newtonsoft.Json;

    /// <summary>
    /// Responsible for converting the JSON to .NET object
    /// </summary>
    internal class JsonHelper
    {
        /// <summary>
        /// A static constructor for initiazion of the class before accessing it
        /// </summary>
        static JsonHelper()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.DateTime,
            };
        }

        /// <summary>
        /// Convert json object to .NET object
        /// </summary>
        /// <typeparam name="T">Type of the destination object</typeparam>
        /// <param name="json">JSON content to be serialized</param>
        /// <returns>Object of type T</returns>
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
