﻿namespace GambitCore
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Responsible for the execution of the HttpRequest
    /// </summary>
    public partial class HttpClient
    {
        /// <summary>
        /// Execute request
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="requestUri">Destination Uri for the request</param>
        /// <param name="json">JSON body</param>
        /// <param name="payloadHMAC">Payload HMAC header</param>
        /// <param name="completionOption">Completion Option</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Return HttpResponseMessage</returns>
        private async Task<HttpResponseMessage> ExecuteAsync(
            HttpMethod method,
            string requestUri,
            string json,
            string payloadHMAC,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            var retry = 0;
            var isReachabilityFailure = false;
            var isAvailabilityFailure = false;

            HttpResponseMessage httpResponse = null;

            do
            {
                try
                {
                    var request = new HttpRequestMessage(method, requestUri);

                    if (method != HttpMethod.Get)
                    {
                        if (json != null)
                        {
                            request.Content = GetContent(json);
                        }
                    }
                    else
                    {
                        if (json != null)
                        {
                            DefaultRequestHeaders.Add("JSON-Base64", json);
                        }
                    }

                    if (payloadHMAC != null)
                    {
                        DefaultRequestHeaders.Add("Payload-HMAC", payloadHMAC);
                    }

                    httpResponse = await SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);

                    if (httpResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        isAvailabilityFailure = true;
                    }
                }
                catch (TaskCanceledException)
                {
                    isReachabilityFailure = true;
                }
                catch (Exception)
                {
                    isReachabilityFailure = false;
                }
                retry++;

            } while ((isReachabilityFailure || isAvailabilityFailure) && retry < this._settings.RetryCount);

            if (httpResponse == null)
            {
                httpResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    ReasonPhrase = "The app server is not reachable"
                };
            }

            return httpResponse;
        }

        public HttpContent GetContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}