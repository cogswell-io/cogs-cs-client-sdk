namespace GambitCore
{
    /// <summary>
    /// The Base service class. All services derive from this class
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The constructor for initializing a service
        /// </summary>
        /// <param name="settings">A <see cref="GambitCore.GambitSettings"/> instance. If not provided, the default settings will be used</param>
        protected BaseService(GambitSettings settings = null)
        {
            this.GambitSettings = settings ?? GambitSettings.DefaultSettings;
        }

        /// <summary>
        /// Returns the <see cref="GambitCore.GambitSettings"/> for the service instance
        /// </summary>
        public GambitSettings GambitSettings { get; private set; }
    }
}
