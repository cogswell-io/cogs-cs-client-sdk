namespace GambitCore
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class HttpClient
    {
        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation 
        /// with client secret json and HMAC Payload with cancellation token
        /// </summary>
        /// <typeparam name="T">Type of the response</typeparam>
        /// <param name="requestUri">The full destination Url for the request (eg. <example>http://host.com/path</example>)</param>
        /// <param name="clientSecretJson">Client Secret in JSON format</param>
        /// <param name="clientSecretPayloadHMAC">>Secret Payload HMAC of the client</param>
        /// <param name="settings">GambitSettings instance</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Return a response in the type that is requested(T) <see cref="Response{T}"/></returns>
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
