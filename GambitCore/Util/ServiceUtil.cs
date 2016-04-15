namespace GambitCore.Util
{
    using System;

    public class ServiceUtil
    {
        public static string CurrentDate()
        {
            return DateTime.UtcNow.ToString("s") + "+0000"; //2016-01-15T11:54+0000
        }
    }
}
