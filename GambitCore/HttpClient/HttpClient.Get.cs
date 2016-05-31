namespace GambitCore
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class HttpClient
    {
        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation 
        /// with client secret HMAC Payload and cancellation token
        /// </summary>
        /// <typeparam name="T">Type of the response object</typeparam>
        /// <param name="requestUri">The full destination Url for the request (eg. <example>http://host.com/path</example>)</param>
        /// <param name="jsonBase64">Base 64 JSON string</param>
        /// <param name="clientSecretPayloadHMAC">Secret Payload HMAC of the client</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Return a response in the type that is requested(T) <see cref="Response{T}"/></returns>
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
