namespace GambitCore
{
    using System;
    using SystemHttpClient = System.Net.Http.HttpClient;

    /// <summary>
    /// A class that extends the system <see cref="System.Net.Http.HttpClient"/> class
    /// Handles the execution of HttpRequests
    /// </summary>
    public partial class HttpClient : SystemHttpClient
    {
        /// <summary>
        /// Instance of the <see cref="GambitSettings"/> to be used
        /// </summary>
        private readonly GambitSettings _settings;

        /// <summary>
        /// Constructor for initializing the HttpClient, with the option to receive custom Gambit settings
        /// </summary>
        /// <param name="settings">
        ///     <see cref="GambitSettings"/> to be used. If not passed, the default setttings 
        ///     <see cref="GambitSettings.DefaultSettings"/> will be used
        /// </param>
        public HttpClient(GambitSettings settings = null)
        {
            if (settings == null)
            {
                settings = GambitSettings.DefaultSettings;
            }

            this._settings = settings;

            BaseAddress = new Uri(settings.BaseUrl);

            if (settings.Timeout > 0)
            {
                Timeout = TimeSpan.FromSeconds(settings.Timeout);
            }

            DefaultRequestHeaders.AcceptEncoding.Clear();
            DefaultRequestHeaders.Accept.TryParseAdd("application/json");

            DefaultRequestHeaders.UserAgent.ParseAdd(settings.UserAgent);
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        }
    }
}
