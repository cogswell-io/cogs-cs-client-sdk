namespace GambitCore
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class HttpClient
    {
        public async Task<Response<T>> PostAsync<T>(
            string requestUri,
            string clientSecretJson,
            string clientSecretPayloadHMAC,
            GambitSettings settings = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            var response = new Response<T>();
            try
            {
                var httpResponse = await ExecuteAsync(
                    HttpMethod.Post,
                    requestUri,
                    clientSecretJson,
                    clientSecretPayloadHMAC,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken);
                
                response.StatusCode = (int)httpResponse.StatusCode;
                response.IsSuccess = httpResponse.IsSuccessStatusCode;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.Message = httpResponse.ReasonPhrase;
                    return response;
                }

                
                var json = await httpResponse.Content.ReadAsStringAsync();
                response.RawData = json;
                response.Result = JsonHelper.ToItem<T>(json);

                response.Message = "Success";

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

      
    }
}
