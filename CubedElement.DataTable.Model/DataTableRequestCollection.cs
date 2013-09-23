using System.Collections.Generic;
using System.Runtime.Serialization;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Contracts.Extensions;
using CubedElement.DataTable.Model.Constants;

namespace CubedElement.DataTable.Model
{
    /// <summary>
    /// As an input class, DataTableRequestRequestCollection helps provide a way to organize the data received from JQuery DataTables plug in, so 
    /// you can just focus on grabbing information from the database system
    /// <remarks>The reference to the server side usage: http://www.datatables.net/usage/server-side
    /// </remarks>
    /// </summary>
    public class DataTableRequestCollection : IDataTableRequestCollection
    {
        /// <summary>
        /// 'sEcho'
        /// </summary>
        public string Echo { get; set; }

        /// <summary>
        /// 'sSearch'
        /// </summary>
        public string GlobalSearch { get; set; }

        /// <summary>
        /// 'iDisplayLength'
        /// </summary>
        public int DisplayLength { get; set; }

        /// <summary>
        /// 'iDisplayStart'
        /// </summary>
        public int DisplayStart { get; set; }

        /// <summary>
        /// 'iColumns'
        /// </summary>
        public int ColumnsDisplayedCount { get; set; }

        /// <summary>
        /// True if the global filter should be treated as a regular expression for advanced filtering, false if not.
        /// </summary>
        public bool Regex { get; set; }

        /// <summary>
        /// 'iSortCol_(int)'
        /// </summary>
        public int ColumnSorted { get; set; }

        /// <summary>
        /// These are the collection of properties, think getter / setter or DataTable column name. They are usually bound by "mDataProp_(int)." 
        /// </summary>
        public IDictionary<string, string> DataProperties { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="DataProperties"/> by index. If no key exists, then it will return <c>string.Empty</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetDataPropertyValue(int index)
        {
            return GetValue(DataProperties, DataItemCollectionNames.MdataProp, index, string.Empty);
        }

        ///<summary>
        ///A collection where the key starts with 'sSearch_(int)' and increments where '(int)' is located.
        /// </summary>
        public IDictionary<string, string> ColumnSearch { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="ColumnSortDirection"/> by index. If no key exists, then it will return <c>string.Empty</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetColumnSearchValue(int index)
        {
            return GetValue(ColumnSearch, DataItemCollectionNames.SSearch, index, string.Empty);
        }

        ///<summary>
        ///A collection where the key starts with 'sSortDir_(int)' and increments where '(int)' is located.
        /// </summary>
        public IDictionary<string, string> ColumnSortDirection { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="ColumnSortDirection"/> by index. If no key exists, then it will return <c>string.Empty</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetColumnSortDirectionValue(int index)
        {
            return GetValue(ColumnSortDirection, DataItemCollectionNames.SSortDir, index, string.Empty);
        }

        ///<summary>
        ///A collection where the key starts with 'bRegex_(int)' and increments where '(int)' is located.
        /// </summary>
        public IDictionary<string, bool> ColumnRegExpression { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="ColumnRegExpression"/> by index. If no key exists, then it will return <c>false</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetColumnRegExpressionValue(int index)
        {
            return GetValue(ColumnRegExpression, DataItemCollectionNames.BRegex, index, false);
        }

        ///<summary>
        ///A collection where the key starts with 'bSortable_(int)' and increments where '(int)' is located.
        ///</summary>
        public IDictionary<string, bool> ColumnSortable { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="ColumnSortable"/> by index. If no key exists, then it will return <c>false</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetColumnSortableValue(int index)
        {
            return GetValue(ColumnSortable, DataItemCollectionNames.SSortCol, index, false);
        }

        /// <summary>
        /// A collection where the key starts with 'bSearchable_(int)' and increments where '(int)' is located.
        /// </summary>
        public IDictionary<string, bool> ColumnSearchable { get; set; }

        /// <summary>
        /// Provides a fast way to look up a value inside <see cref="ColumnSearchable"/> by index. If no key exists, then it will return <c>false</c>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetColumnSearchableValue(int index)
        {
            return GetValue(ColumnSearchable, DataItemCollectionNames.SSearchable, index, false);
        }

        /// <summary>
        /// Generic helper method to retreive a value
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="pattern"></param>
        /// <param name="index"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValue<T>(IDictionary<string, T> collection, string pattern, int index, T defaultValue)
        {
            if (collection.IsNullOrEmpty() || index < 0)
            {
                return defaultValue;
            }

            foreach (var kv in collection)
            {
                var key = kv.Key.Replace(pattern, string.Empty);

                if (string.IsNullOrEmpty(key))
                {
                    return defaultValue;
                }

                int keyIndex;
                
                if (!int.TryParse(key, out keyIndex))
                {
                    continue;
                }
                
                if (keyIndex.Equals(index))
                {
                    return kv.Value;                        
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetDataPropertyValue"/> to get the result. 
        /// </summary>
        public string SortedColumnSearchName
        {
            get
            {
                return GetDataPropertyValue(ColumnSorted);
            }
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetColumnSearchValue"/> to get the result. 
        /// </summary>
        public string SortedColumnSearchValue
        {
            get
            {
                return GetColumnSearchValue(ColumnSorted);
            }
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetColumnRegExpressionValue"/> to get the result. 
        /// </summary>
        public bool SortedColumnRegExpressionValue
        {
            get
            {
                return GetColumnRegExpressionValue(ColumnSorted);
            }
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetColumnSearchableValue"/> to get the result. 
        /// </summary>
        public bool SortedColumnSearchableValue
        {
            get
            {
                return GetColumnSearchableValue(ColumnSorted);
            }
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetColumnSortDirectionValue"/> to get the result. 
        /// </summary>
        public string SortedColumnDirectionValue
        {
            get
            {
                return GetColumnSortDirectionValue(ColumnSorted);
            }
        }

        /// <summary>
        /// A wrapper method, so you don't need to combine items <see cref="ColumnSorted"/> value with <see cref="GetColumnSortableValue"/> to get the result. 
        /// </summary>
        public bool SortedColumnSortableValue
        {
            get
            {
                return GetColumnSortableValue(ColumnSorted);
            }
        }
    
        /// <summary>
        /// Determines if the output should be serialized as a <see cref="DataContract"/> or an <c>object[]</c>
        /// </summary>
        /// <returns></returns>
        public bool SerializeAsDataContract()
        {
            return !DataProperties.IsNullOrEmpty();
        }
    }
}