using System.Collections.Generic;

namespace Dna
{
    /// <summary>
    /// Extension methods for Arrays
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Append the given objects to original source array
        /// </summary>
        /// <typeparam name="T">Type of Array</typeparam>
        /// <param name="source">Source Array</param>
        /// <param name="toAdd">Array to add to source Array</param>
        /// <returns>Returns Array with appended elements</returns>
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            var list = new List<T>(source);
            list.AddRange(toAdd);

            return list.ToArray();
        }

        /// <summary>
        /// Prepend the given objects to original source array
        /// </summary>
        /// <typeparam name="T">Type of Array</typeparam>
        /// <param name="source">Source Array</param>
        /// <param name="toPrepend">Array to prepend to source Array</param>
        /// <returns>Returns Array with prepended elements to it</returns>
        public static T[] Prepend<T>(this T[] source, params T[] toPrepend)
        {
            var list = new List<T>(toPrepend);
            list.AddRange(source);

            return list.ToArray();
        }

    }
}
