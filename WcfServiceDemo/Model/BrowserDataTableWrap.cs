using System.Collections.Generic;
using System.Runtime.Serialization;
using CubedElement.DataTable.Contracts;

namespace WcfServiceDemo.Model
{
    [DataContract]
    public class BrowserDataTableWrap : IBrowser, IDataTableSerializer
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

        /// <summary>
        /// Provides a way to serialize your class as an object array, which makes it like <c>["value", something, 3]</c>
        /// </summary>
        /// <returns></returns>
        public object[] ToObjectArray()
        {
            return new object[] { Engine, Name, Platform, Version, Grade };
        }

        /// <summary>
        /// Returns a collection of columns, which is used in JQuery DataTables. Note, this is 
        /// typically the property names of your class 
        /// <remarks>if going through the <see cref="ToObjectArray"/>, then you'll want to make sure 
        /// the order of these column / property names match the order of how you lay out the object array.</remarks>
        /// </summary>
        /// <returns></returns>
        public IList<string> ColumnNames()
        {
            return new List<string>
                {
                    "engine",
                    "name",
                    "platform",
                    "version",
                    "grade"
                };
        }
    }
}