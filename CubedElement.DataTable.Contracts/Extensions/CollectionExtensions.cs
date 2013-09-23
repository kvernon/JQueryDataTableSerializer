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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CubedElement.DataTable.Contracts.Extensions
{
    /// <summary>
    /// A collection of extensions to make working with the <see cref="IDictionary{TKey,TValue}" /> easier.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// It simply provides a way to to know if the list is null or empty; meaning it will return <c>true</c> if <c>null</c> or if the <see cref="IList{T}.Count"/> is <c>0</c>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="descending"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> OrderByDirection<TSource, TKey>(this IEnumerable<TSource> source,
                                                                                  Func<TSource, TKey> keySelector,
                                                                                  bool descending)
        {
            return descending
                       ? source.OrderByDescending(keySelector)
                       : source.OrderBy(keySelector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="descending"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static IOrderedQueryable<TSource> OrderByDirection<TSource, TKey>(this IQueryable<TSource> source,
                                                                                 Expression<Func<TSource, TKey>>
                                                                                     keySelector,
                                                                                 bool descending)
        {
            return descending
                       ? source.OrderByDescending(keySelector)
                       : source.OrderBy(keySelector);
        }
    }
}