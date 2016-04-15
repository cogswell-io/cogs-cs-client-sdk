namespace GambitData
{
    using System.Runtime.Serialization;

    [DataContract]
    public class RandomUuIdResponse : IRandomUuIdResponseCode200
    {
        [DataMember(Name = "uuid")]
        public string UuId { get; set; }
    }
}
