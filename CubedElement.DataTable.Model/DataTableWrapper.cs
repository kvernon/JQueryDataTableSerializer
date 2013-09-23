/*
    JQuery DataTables Service Serializer Framework
    Copyright (C) 2013 Kelly Vernon

    http://www.cubedelement.com

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Contracts.Extensions;
using CubedElement.DataTable.Model.Constants;

namespace CubedElement.DataTable.Model
{
    /// <summary>
    /// As the output class, DataTableWrapper provides a way to take a collection of items, that you probably have applied a <see cref="DataContract"/> to, and 
    /// have them implementing <see cref="IDataTableSerializer"/> where they're wrapped in a way where JQuery DataTables plug in can read.
    /// <remarks>
    /// The reference to the server side usage: http://www.datatables.net/usage/server-side
    /// </remarks>-
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Name = DataItemPropertyNamesFrontEnd.DataTableWrapper)]
    public class DataTableWrapper<T> where T : IDataTableSerializer
    {
        private readonly IDataTableRequestCollection _dataTableRequestCollection;

        private readonly IList<T> _collection;

        /// <summary>
        /// In put a populated <see cref="DataTableRequestCollection"/> and a collection of <see cref="IDataTableSerializer"/>
        /// </summary>
        /// <param name="dataTableRequestCollection"></param>
        /// <param name="collection"></param>
        public DataTableWrapper(IDataTableRequestCollection dataTableRequestCollection, IList<T> collection)
        {
            _dataTableRequestCollection = dataTableRequestCollection;
            _collection = collection;
        }

        private bool IsDataTableCollectionNull()
        {
            return _dataTableRequestCollection == null;
        }

        private bool SerializeAsDataContract()
        {
            return !IsDataTableCollectionNull() && _dataTableRequestCollection.SerializeAsDataContract();
        }

        /// <summary>
        /// An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is 
        /// basically a draw count) - so it is important that this is implemented. Note that it strongly recommended 
        /// for security reasons that you 'cast' this parameter to an integer in order to prevent 
        /// Cross Site Scripting (XSS) attacks. In this case, we cast internally, and the send back as a string. 
        /// If there are problems (and the default) it will return "-1"
        /// </summary>
        [DataMember(Name = DataItemPropertyNamesFrontEnd.Echo)]
        public int Echo
        {
            get
            {
                const int de = -1;

                if (IsDataTableCollectionNull())
                {
                    return de;
                }

                if (string.IsNullOrEmpty(_dataTableRequestCollection.Echo))
                {
                    return de;
                }

                int tr;

                var echo = int.TryParse(_dataTableRequestCollection.Echo, out tr);

                return echo ? tr : de;
            }
            set { }
        }

        /// <summary>
        /// Total records, before filtering (i.e. the total number of records in the database)
        /// </summary>
        [DataMember(Name = DataItemPropertyNamesFrontEnd.TotalRecords)]
        public int TotalRecords { get; set; }

        /// <summary>
        /// Total records, after filtering (i.e. the total number of records after filtering has been 
        /// applied - not just the number of records being returned in this result set)
        /// </summary>
        [DataMember(Name = DataItemPropertyNamesFrontEnd.TotalDisplayRecords)]
        public int TotalDisplayRecords { get; set; }

        /// <summary>
        /// <para>Deprecated Optional - this is a string of column names, comma separated (used in 
        /// combination with sName) which will allow DataTables to reorder data on the client-side 
        /// if required for display. Note that the number of column names returned must exactly match 
        /// the number of columns in the table. For a more flexible JSON format, please consider 
        /// using mData.</para>
        /// <para>
        /// Note that this parameter is deprecated and will be removed in v1.10. Please now use mData. or AKA DataProperties that resides in the implementation of <c>DataTableRequestCollection</c>.
        /// </para>
        /// </summary>
        [DataMember(Name = DataItemPropertyNamesFrontEnd.Columns)]
        public string Columns
        {
            get 
            { 
                return _collection.IsNullOrEmpty() 
                    ? string.Empty
                    : string.Join(",", _collection[0].ColumnNames().ToArray());
            }
            set { }
        }

        /// <summary>
        /// <para>The array of data you have boxed as an object. This could be the serialized string version, or the class 
        /// you've applied a <see cref="DataContract"/> to for serialization.</para>
        /// <para>The data in a 2D array. Note that you can change the name of this parameter with sAjaxDataProp.</para>
        /// <remarks>The logic in here checks to see if <see cref="IDataTableRequestCollection.SerializeAsDataContract"/> contains a 
        /// collection of data. Specifically the DataProperties already shows the breakdown of the object's columns / properties 
        /// names, so if it does have that information, it knows to serialize your collection as <see cref="DataContract"/>s. 
        /// Otherwise, it knows that this is the old way, where you pass <see cref="Columns"/> and get the results 
        /// from <see cref="IDataTableSerializer.ToObjectArray"/>.</remarks>
        /// </summary>
        [DataMember(Name = DataItemPropertyNamesFrontEnd.ArrayData)]
        public object[] Data
        {
            get
            {
                if (_collection.IsNullOrEmpty())
                {
                    return new object[0];
                }

                var result = new object[_collection.Count];
 
                for (var i = 0; i < _collection.Count; i++)
                {
                    result[i] = SerializeAsDataContract() ? (object)_collection[i] : _collection[i].ToObjectArray();
                }
 
                return result;
            }
            set { }
        }
    }
}