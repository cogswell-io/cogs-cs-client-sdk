namespace GambitCore
{
    /// <summary>
    /// The Base service class. All services derive from this class
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Readonly instance of the GambitSettings
        /// </summary>
        readonly GambitSettings _settings;

        /// <summary>
        /// The constructor for initializing a service
        /// </summary>
        /// <param name="settings">A GambitSettings instance. If not provided, the default settings will be used</param>
        public BaseService(GambitSettings settings = null)
        {
            this._settings = settings ?? GambitSettings.DefaultSettings;
        }

        /// <summary>
        /// Gets or sets the GambitSettings for the service instance
        /// </summary>
        public GambitSettings GambitSettings
        {
            get { return this._settings; }
        }
    }
}
