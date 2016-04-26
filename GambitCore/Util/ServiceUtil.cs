namespace GambitCore.Util
{
    using System;

    /// <summary>
    /// Set of common utilities for the services
    /// </summary>
    public class ServiceUtil
    {
        /// <summary>
        /// Gets the current server date formatted as 2016-01-15T11:54+0000
        /// </summary>
        /// <returns></returns>
        public static string CurrentDate()
        {
            return DateTime.UtcNow.ToString("s") + "+0000";
        }
    }
}
