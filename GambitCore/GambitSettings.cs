namespace GambitCore
{
    using System;

    /// <summary>
    /// Responsible for managing the Settings of the application
    /// </summary>
    public class GambitSettings
    {
        private const string _baseUrl = "https://api.cogswell.io";
        private const string _socketAddress = "wss://api.cogswell.io:443/push";

        private const int _retryCountValue = 2;
        private const int _timeout = 30;
        private const int _receivedChunkSize = 1024 * 5;
        private const int _defaultMaxSessionIdleTimeout = 300000;

        /// <summary>
        /// The path to the api-docs on the server
        /// </summary>
        public const string DocsPath = "/api-docs";

        /// <summary>
        /// The path to the client secret on the server
        /// </summary>
        public const string ClientSecretPath = "/client_secret";

        /// <summary>
        /// The path where the event requests should be executed
        /// </summary>
        public const string EventPath = "/event";

        /// <summary>
        /// The path on the server for Random UUID generation
        /// </summary>
        public const string RandomUuIdPath = "/random_uuid";

        /// <summary>
        /// The path for the namespace schema to be fetch from
        /// </summary>
        public const string NamespacePath = "/namespace/{0}/schema";

        /// <summary>
        /// The path for getting messages from the server
        /// </summary>
        public const string MessagePath = "/message/{0}";

        /// <summary>
        /// The value of the UserAgent of the request
        /// </summary>
        private const string _userAgent = "GambitTools SDK for CS";

        /// <summary>
        /// A constructor for initializing the class. Default values are assigned
        /// </summary>
        public GambitSettings()
        {
            this.RetryCount = _retryCountValue;
            this.BaseUrl = _baseUrl;
            this.SocketUrl = _socketAddress;
            this.Timeout = _timeout;
            this.UserAgent = _userAgent;
            this.ReceivedChunkSize = _receivedChunkSize;
            this.DefaultMaxSessionIdleTimeout = TimeSpan.FromMilliseconds(_defaultMaxSessionIdleTimeout);
        }

        /// <summary>
        /// A static constructor for initialization of the class before accessing it
        /// </summary>
        static GambitSettings()
        {
            DefaultSettings = new GambitSettings();
        }

        /// <summary>
        /// The default settings that will be used for the application
        /// </summary>
        public static GambitSettings DefaultSettings { get; set; }

        /// <summary>
        /// Gets or sets the BaseUrl that should be used for the HttpClient requests
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the Web socket address where the messages are send/received
        /// </summary>
        public string SocketUrl { get; set; }

        /// <summary>
        /// Gets or sets the User Agent of the request
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the number of times a single request will be execute (in case of fails). 
        /// The default option is 2, meaning if the first request is unsuccessful, it will be resend one more time
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the Timeout (in seconds) of the request. If it is set to zero or less 0, no timeout will be set.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the number of bytes that can be received
        /// </summary>
        public int ReceivedChunkSize { get; set; }

        /// <summary>
        /// Gets or sets the time (in milliseconds) that the websocket should be alive after start.
        /// </summary>
        public TimeSpan DefaultMaxSessionIdleTimeout { get; set; }
    }
}
