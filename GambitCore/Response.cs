namespace GambitCore
{
    using Newtonsoft.Json.Linq;
    using System;

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }

    public class Response
    {
        public Response() {
        }

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

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public JObject Object { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorDetails { get; set; }

        public string RawData { get; set; }

    }
}
