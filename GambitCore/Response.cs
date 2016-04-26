namespace GambitCore
{
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// Response of type T. It is used everywhere where the response from the server is received (Event, Namespace, Message)
    /// </summary>
    /// <typeparam name="T">Type of the response</typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// The result of the response where T is the response if the desired type
        /// </summary>
        public T Result { get; set; }
    }

    /// <summary>
    /// Base response from the server
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Base constructor for initializing the response
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Constructor for initializint the response, knowing the message and the status code
        /// </summary>
        /// <param name="response">Message of the response</param>
        /// <param name="code">Http Status Code</param>
        public Response(string response, int code)
        {
            Message = response;
            StatusCode = code;

            try
            {
                Object = JObject.Parse(response);
                IsSuccess = true;
            }
            catch (Exception e)
            {
                //bad response
                IsSuccess = false;
                ErrorCode = "UNKNOWN";
                ErrorDetails = e.Message + ": " + response;
            }
        }

        /// <summary>
        /// Gets or sets the message of the response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Http Status Code of the response
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the status of the request
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message string in JSON format
        /// </summary>
        public JObject Object { get; set; }

        /// <summary>
        /// Gets or sets the ErrorCode of the request. Used in case of exception
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the details of the error if some. Used in case of exception
        /// </summary>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the Raw content of the response
        /// </summary>
        public string RawData { get; set; }
    }
}
