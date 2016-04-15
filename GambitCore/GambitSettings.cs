namespace GambitCore
{
    using System;

    public class GambitSettings
    {
        private const string _baseUrl = "https://api.cogswell.io";
        private const string _socketAddress = "wss://api.cogswell.io:443/push";

        private const int _retryCountValue = 2;
        private const int _timeout = 30;
        private const int _receivedChunkSize = 1024 * 5;
        private const int _defaultMaxSessionIdleTimeout = 300000;


        public const string DocsPath = "/api-docs";
        public const string ClientSecretPath = "/client_secret";
        public const string EventPath = "/event";
        public const string RandomUuIdPath = "/random_uuid";
        public const string NamespacePath = "/namespace/{0}/schema";
        public const string MessagePath = "/message/{0}";

        private const string _userAgent = "GambitTools SDK for CS";

        public GambitSettings()
        {
            RetryCount = _retryCountValue;
            BaseUrl = _baseUrl;
            SocketUrl = _socketAddress;
            Timeout = _timeout;
            UserAgent = _userAgent;
            ReceivedChunkSize = _receivedChunkSize;
            DefaultMaxSessionIdleTimeout = TimeSpan.FromMilliseconds(_defaultMaxSessionIdleTimeout);
        }

        static GambitSettings()
        {
            DefaultSettings = new GambitSettings();
        }

        public static GambitSettings DefaultSettings { get; set; }

        public string BaseUrl { get; set; }

        public string SocketUrl { get; set; }

        public string UserAgent { get; set; }

        public int RetryCount { get; set; }

        public int Timeout { get; set; }

        public int ReceivedChunkSize { get; set; }

        public TimeSpan DefaultMaxSessionIdleTimeout { get; set; }

    }
}
