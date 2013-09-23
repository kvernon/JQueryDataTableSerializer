using System.Collections.Generic;

namespace CubedElement.DataTable.Contracts
{
    /// <summary>
    /// Provides a way for a serialized class, to provide column names, or property names for the dataTables
    /// </summary>
    public interface IDataTableSerializer
    {
        /// <summary>
        /// Provides a way to serialize your class as an object array, which makes it like <c>["value", something, 3]</c>
        /// </summary>
        /// <returns></returns>
        object[] ToObjectArray();

        /// <summary>
        /// Returns a collection of columns, which is used in JQuery DataTables. Note, this is 
        /// typically the property names of your class 
        /// <remarks>if going through the <see cref="ToObjectArray"/>, then you'll want to make sure 
        /// the order of these column / property names match the order of how you lay out the object array.</remarks>
        /// </summary>
        /// <returns></returns>
        IList<string> ColumnNames();
    }
}