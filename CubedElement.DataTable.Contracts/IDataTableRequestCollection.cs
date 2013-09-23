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
namespace CubedElement.DataTable.Contracts
{
    /// <summary>
    /// IDataTableRequestCollection is a contract that is used to help provide a way to organize the data received from JQuery DataTables plug in, so 
    /// you can just focus on grabbing information from the database system
    /// </summary>
    public interface IDataTableRequestCollection
    {
        /// <summary>
        /// 'sEcho'
        /// </summary>
        string Echo { get; set; }

        /// <summary>
        /// Determines if the output should be serialized as a <c>DataContract</c> or an <c>object[]</c>
        /// </summary>
        /// <returns></returns>
        bool SerializeAsDataContract();
    }
}