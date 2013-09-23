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