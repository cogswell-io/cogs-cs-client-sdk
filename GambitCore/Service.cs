namespace GambitCore
{
    using GambitData;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Util;

    public class Service : BaseService, IService
    {
        public Service(GambitSettings settings = null):base(settings)
        {

        }
        
        public async Task<Response<ClientSecretResponseCode200>> ClientSecretAsync(string accessKey, string secretKey)
        {
            if (accessKey == null) throw new ArgumentException("Missing accessKey");
            if (secretKey == null) throw new ArgumentException("Missing secretKey");

            ClientSecretPostBody postClientSecretBody = new ClientSecretPostBody()
            {
                AccessKey = accessKey,
                Timestamp = ServiceUtil.CurrentDate()
            };

            using (var client = new HttpClient(GambitSettings))
            {
                string requestUri = GambitSettings.BaseUrl + GambitSettings.ClientSecretPath;
                string clientSecretJson = JsonConvert.SerializeObject(postClientSecretBody);
                string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, clientSecretJson);

                Response<ClientSecretResponseCode200> response =  await client.PostAsync<ClientSecretResponseCode200>(requestUri, clientSecretJson, clientSecretPayloadHMAC);
                return response;
            }
        }

       
        public async Task<Response<RandomUuIdResponseCode200>> RandomUuIAsync(string accessKey, string secretKey)
        {

            IRandomUuIdPostBody postRandomUuIdBody = new RandomUuIdPostBody()
            {
                AccessKey = accessKey,
                Timestamp = ServiceUtil.CurrentDate()
            };
            postRandomUuIdBody.ValidateRequiredProparties();

            string requestUri = GambitSettings.BaseUrl + GambitSettings.RandomUuIdPath;
            string clientSecretJson = JsonConvert.SerializeObject(postRandomUuIdBody);
            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, clientSecretJson);

            using (var client = new HttpClient(GambitSettings))
            {
                Response<RandomUuIdResponseCode200> response = await client.PostAsync<RandomUuIdResponseCode200>(requestUri, clientSecretJson, clientSecretPayloadHMAC);
                return response;
            }
        }

        public async Task<Response<EventResponseCode200>> EventAsync(EventPostBody eventPostBody, string accessKey, string secretKey)
        {

            eventPostBody.Timestamp = ServiceUtil.CurrentDate();
            eventPostBody.ValidateRequiredProparties();

            string requestUri = GambitSettings.BaseUrl + GambitSettings.EventPath;
            string clientSecretJson = JsonConvert.SerializeObject(eventPostBody);
            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, clientSecretJson);


            using (var client = new HttpClient(GambitSettings))
            {
                Response<EventResponseCode200> response = await client.PostAsync<EventResponseCode200>(requestUri, clientSecretJson, clientSecretPayloadHMAC);
                return response;
            }
        }

        public async Task<Response<RootObject>> GetApiDocsAsync()
        {
            string requestUri = GambitSettings.BaseUrl + GambitSettings.DocsPath;

            using (var client = new HttpClient(GambitSettings))
            {
                Response<RootObject> response = await client.GetAsync<RootObject>(requestUri);
                return response;
            }
        }

        public Task<Response> MessageAsync()
        {
            throw new NotImplementedException();
        }

        

        public async Task<Response<string>> NamespaceAsync(string name, string accessKey, string secretKey)
        {
            string requestUri = GambitSettings.BaseUrl + string.Format("/namespace/{0}/schema", name);

            JObject json = new JObject();
            json.Add("access_key", accessKey);
            json.Add("timestamp", ServiceUtil.CurrentDate());

            UTF8Encoding enc = new UTF8Encoding();
            var jsonString = JsonConvert.SerializeObject(json);
            var jsonBase64 = Convert.ToBase64String(enc.GetBytes(jsonString));

            string clientSecretPayloadHMAC = GambitEncryption.HMACSHA256(secretKey, jsonString);

            using (var client = new HttpClient(GambitSettings))
            {
                Response<string> response = await client.GetAsync<string>(requestUri, jsonBase64, clientSecretPayloadHMAC);

                return response;
            }
        }
    }
}
