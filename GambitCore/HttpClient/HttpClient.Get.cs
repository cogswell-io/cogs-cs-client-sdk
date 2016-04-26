namespace GambitCore
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Handling the HTTP GET method sending
    /// </summary>
    public partial class HttpClient
    {
        /// <summary>
        /// Gets a message
        /// </summary>
        /// <typeparam name="T">Type of the response object</typeparam>
        /// <param name="requestUri">Destination Uri for the request</param>
        /// <param name="jsonBase64">Base 64 JSON</param>
        /// <param name="clientSecretPayloadHMAC">Secret Payload HMAC of the client</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Return response in the type that is requested(T)</returns>
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
                else
                {
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
