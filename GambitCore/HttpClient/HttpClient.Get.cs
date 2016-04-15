namespace GambitCore
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class HttpClient
    {

        public async Task<Response<T>> GetAsync<T>(
           string requestUri,
           string jsonBase64 = null,
           string clientSecretPayloadHMAC = null,
           CancellationToken cancellationToken = default(CancellationToken))
        {

            var response = new Response<T>();

            try
            {
                var httpResponse = await ExecuteAsync(
                    HttpMethod.Get,
                    requestUri,
                    jsonBase64,
                    clientSecretPayloadHMAC,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken);

                response.StatusCode = (int)httpResponse.StatusCode;
                response.IsSuccess = httpResponse.IsSuccessStatusCode;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.Message = httpResponse.ReasonPhrase;
                }
                else {
                    var json = await httpResponse.Content.ReadAsStringAsync();
                    response.RawData = json;
                    response.Result = JsonHelper.ToItem<T>(json);
                }
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
