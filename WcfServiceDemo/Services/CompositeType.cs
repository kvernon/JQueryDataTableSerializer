using System.Runtime.Serialization;

namespace WcfServiceDemo.Services
{
    [DataContract]
    public class CompositeType
    {
        [DataMember(Name = "boolValue")]
        public bool BoolValue { get; set; }

        [DataMember(Name = "stringValue")]
        public string StringValue { get; set; }
    }
}