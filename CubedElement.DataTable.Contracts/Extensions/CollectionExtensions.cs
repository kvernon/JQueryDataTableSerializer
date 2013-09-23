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
//        /// <summary>
//        /// It simply provides a way to to know if the dictionary is null or empty; meaning it will return <c>true</c> if <c>null</c> or if the <see cref="IDictionary{TK, TV}.Count"/> is <c>0</c>.
//        /// </summary>
//        /// <typeparam name="TV"></typeparam>
//        /// <typeparam name="TK"></typeparam>
//        /// <param name="dictionary"></param>
//        /// <returns></returns>
//        public static bool IsNullOrEmpty<TK, TV>(this IDictionary<TK, TV> dictionary)
//        {
//            return ((ICollection<KeyValuePair<TK, TV>>)dictionary).IsNullOrEmpty();
//        }

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