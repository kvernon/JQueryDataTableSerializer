using System.Runtime.Serialization;
using WcfServiceDemo.Data;

namespace WcfServiceDemo.Model
{
    [DataContract(Name = "browserItem")]
    public class Browser : IBrowser
    {
        [DataMember(Name = "engine", Order = 1)]
        public string Engine { get; set; }

        [DataMember(Name = "browser", Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "platform", Order = 3)]
        public string Platform { get; set; }

        [DataMember(Name = "version", Order = 4)]
        public string Version { get; set; }

        [DataMember(Name = "grade", Order = 5)]
        public string Grade { get; set; }
    }
}