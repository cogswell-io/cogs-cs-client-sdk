namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The RandomUuIdResponse
    /// </summary>
    [DataContract]
    public class RandomUuIdResponse : IRandomUuIdResponseCode200
    {
        /// <summary>
        /// Gets or sets the uu id.
        /// </summary>
        [DataMember(Name = "uuid")]
        public string UuId { get; set; }
    }
}
