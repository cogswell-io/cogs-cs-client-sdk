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

    public class GambitSDKService : BaseService, IGambitSDKService
    {
        public GambitSDKService(GambitSettings settings = null) : base(settings)
        {
        }

        public async Task<Response<EventResponse>> EventAsync(
            EventModel eventModel,
            string secretKey)
        {
            if (string.IsNullOrEmpty(eventModel.Timestamp))
            {
                eventModel.Timestamp = ServiceUtil.CurrentDate();
            }

            eventModel.ValidateRequiredProparties();

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
