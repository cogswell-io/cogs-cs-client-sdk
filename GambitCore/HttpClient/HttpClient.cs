namespace GambitCore
{
	using System;
	using SystemHttpClient = System.Net.Http.HttpClient;

	public partial class HttpClient : SystemHttpClient
    {
        private readonly GambitSettings _settings;

        public HttpClient(GambitSettings settings = null)
        {
            if (settings == null) { settings = GambitSettings.DefaultSettings; }
            _settings = settings;

            BaseAddress = new Uri(settings.BaseUrl);

            if (settings.Timeout > 0) Timeout = TimeSpan.FromSeconds(settings.Timeout);

            DefaultRequestHeaders.AcceptEncoding.Clear();
            DefaultRequestHeaders.Accept.TryParseAdd("application/json");


            DefaultRequestHeaders.UserAgent.ParseAdd(settings.UserAgent);
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


        }

    }
}
