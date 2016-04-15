namespace GambitData
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Attributes
    {
        public bool IsActive { get; set; }

        public int Gender { get; set; }

        public int MyProperty { get; set; }

    }
}
