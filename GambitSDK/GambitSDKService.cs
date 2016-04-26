using Newtonsoft.Json.Linq;

namespace GambitSDK
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Gambit.Data.Response;
    using GambitCore;
    using GambitCore.Util;
    using GambitData;
    using Newtonsoft.Json;

    /// <summary>
    /// A service, responsible for managing events and messages
    /// </summary>
    public class GambitSDKService : BaseService, IGambitSDKService
    {
        /// <summary>
        /// Constructor for initialization of the class
        /// </summary>
        /// <param name="settings">Optional. Instance of application settings</param>
        public GambitSDKService(GambitSettings settings = null) 
            : base(settings)
        {
        }

        /// <summary>
        /// Authenticates, validates and persists an incoming event
        /// </summary>
        /// <param name="eventModel">The incoming event</param>
        /// <param name="secretKey">Secret key for authentication</param>
        /// <returns>Event response</returns>
        public async Task<Response<EventResponse>> EventAsync(
            EventModel eventModel,
            string secretKey)
        {
            if (string.IsNullOrEmpty(eventModel.Timestamp))
            {
                eventModel.Timestamp = ServiceUtil.CurrentDate();
            }

            eventModel.ValidateRequiredProperties();

            string requestUri = GambitSettings.BaseUrl + GambitSettings.EventPath;
            string jsonBody = JsonConvert.SerializeObject(eventModel,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, jsonBody);

            using (var client = new HttpClient(GambitSettings))
            {
                Response<EventResponse> response = await client.PostAsync<EventResponse>(requestUri, jsonBody, clientSecretPayloadHMAC);
                return response;
            }
        }

        /// <summary>
        /// Establishes a websocket on which to receive push messages
        /// </summary>
        /// <param name="pushModel">Data to push</param>
        /// <param name="clientSecret">Client secret key</param>
        /// <param name="action">Declare callback that recieve message</param>
        public SocketClient PushAsync(PushModel pushModel, string clientSecret, Action<MessageResponse> action = null)
        {
            pushModel.Timestamp = ServiceUtil.CurrentDate();

            UTF8Encoding enc = new UTF8Encoding();
            var jsonString = JsonConvert.SerializeObject(pushModel);
            var jsonBase64 = Convert.ToBase64String(enc.GetBytes(jsonString));

            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(clientSecret, jsonString);

            var client = new SocketClient(GambitSettings);

            client.OnMessage = action;

            Task.Run(() =>
            {
                client.Start(GambitSettings.SocketUrl, jsonBase64, clientSecretPayloadHMAC);
            });

            return client;
        }

        /// <summary>
        /// Fetches the identified message by its token and the namespace + CIID which authenticated.
        /// </summary>
        /// <param name="messageBody">Message to be send</param>
        /// <param name="token">Token of the message</param>
        /// <param name="accessKey">Access key</param>
        /// <param name="clientSecret">Client secret</param>
        /// <returns>MessageResponse</returns>
        public async Task<Response<string>> MessageAsync(
            MessageModel messageBody,
            string token,
            string accessKey,
            string clientSecret)
        {
            string requestUri = GambitSettings.BaseUrl + string.Format(GambitSettings.MessagePath, token);

            messageBody.AccessKey = accessKey;
            messageBody.Timestamp = ServiceUtil.CurrentDate();

            UTF8Encoding enc = new UTF8Encoding();
            var jsonString = JsonConvert.SerializeObject(messageBody);
            var jsonBase64 = Convert.ToBase64String(enc.GetBytes(jsonString));

            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(clientSecret, jsonString);

            using (var client = new HttpClient(GambitSettings))
            {
                Response<string> response = await client.GetAsync<string>(requestUri, jsonBase64, clientSecretPayloadHMAC);
                return response;
            }
        }

        /// <summary>
        /// Fetches the schema for a particular namespace
        /// </summary>
        /// <param name="name">Name of the namespace that should be retreived</param>
        /// <param name="accessKey">Access key</param>
        /// <param name="secretKey">Secret key</param>
        /// <returns>Returns namespace schema details</returns>
        public async Task<Response<NamespaceResponse>> NamespaceAsync(string name, string accessKey, string secretKey)
        {
            string requestUri = GambitSettings.BaseUrl + string.Format(GambitSettings.NamespacePath, name);

            JObject json = new JObject();
            json.Add("access_key", accessKey);
            json.Add("timestamp", ServiceUtil.CurrentDate()); // must be within 1 minute of server time when processed.

            UTF8Encoding enc = new UTF8Encoding();
            var jsonString = JsonConvert.SerializeObject(json);
            var jsonBase64 = Convert.ToBase64String(enc.GetBytes(jsonString));

            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, jsonString);

            using (var client = new HttpClient(GambitSettings))
            {
                Response<NamespaceResponse> response = await client.GetAsync<NamespaceResponse>(requestUri, jsonBase64, clientSecretPayloadHMAC);

                return response;
            }
        }
    }
}
