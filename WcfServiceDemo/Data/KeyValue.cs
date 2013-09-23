using System.Runtime.Serialization;

namespace WcfServiceDemo.Data
{
    [DataContract]
    public class KeyValue<TK,TV>
    {
        [DataMember(Name = "key")]
        public TK Key { get; set; } 
        
        [DataMember(Name = "value")]
        public TV Value { get; set; } 
    }
}