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

namespace CubedElement.DataTable.Model.Constants
{
    /// <summary>
    /// These are constants for the UI / JavaScript Layer
    /// <c>http://www.datatables.net/usage/server-side</c>
    /// </summary>
    public class DataItemPropertyNamesFrontEnd
    {
        /// <summary>
        /// It provides the name "sEcho."
        /// </summary>
        public const string Echo = "sEcho";

        /// <summary>
        /// It provides the name "iTotalRecords."
        /// </summary>
        public const string TotalRecords = "iTotalRecords";

        /// <summary>
        /// It provides the name "iDisplayStart."
        /// </summary>
        public const string DisplayStart = "iDisplayStart";

        /// <summary>
        /// It provides the name "iDisplayLength."
        /// </summary>
        public const string DisplayLength = "iDisplayLength";

        /// <summary>
        /// It provides the name "iTotalDisplayRecords."
        /// </summary>
        public const string TotalDisplayRecords = "iTotalDisplayRecords";

        /// <summary>
        /// Note: this is a depricated field since v1.10. It provides the name "sColumns."
        /// </summary>
        public const string Columns = "sColumns";

        /// <summary>
        /// It provides the name "aaData."
        /// </summary>
        public const string ArrayData = "aaData";

        /// <summary>
        /// Just the name of the class, "dataTableSerializer," but really there is no meaning to this
        /// </summary>
        public const string DataTableWrapper = "dataTableSerializer";
    }
}
