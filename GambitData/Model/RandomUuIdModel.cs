namespace GambitData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The random uu id post body.
    /// </summary>
    [DataContract]
    public class RandomUuIdModel : IRandomUuIdPostBody
    {
        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Validates the required properties and throws an exception if some of the fields is not entered
        /// </summary>
        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Proparty AccessKey is required from RandomUuIdPostBody class");
            }

            if (string.IsNullOrEmpty(this.Timestamp))
            {
                throw new ArgumentException("Proparty Timestamp is required from RandomUuIdPostBody class");
            }
        }
    }
}
