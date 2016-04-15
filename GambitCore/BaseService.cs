namespace GambitCore
{
    public abstract class BaseService
    {
        readonly GambitSettings _settings;

        public BaseService(GambitSettings settings = null) {
            _settings = settings ?? GambitSettings.DefaultSettings;
        }

        public GambitSettings GambitSettings {
            get { return _settings; }
        }
    }
}
