﻿using System.Linq;
using System.Collections.Generic;

namespace Pagansoft.Functional
{
    public static class EnumerableWithOptionExtensions
    {
        /// <summary>
        /// Returns the values from all elements with a value
        /// </summary>
        /// <returns>The values of all elements with a value.</returns>
        /// <param name="options">The list of options.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<T> OptionValues<T>(this IEnumerable<Option<T>> options)
        {
            foreach (var option in options.Where(o => o.IsSome))
                yield return option.Value;
        }

        /// <summary>
        /// Returns the values from all elements with all nones replaced by the given <paramref name="defaultValue"/>,
        /// </summary>
        /// <returns>The values of all elements with a value.</returns>
        /// <param name="options">The list of options.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<T> OptionValues<T>(this IEnumerable<Option<T>> options, T defaultValue)
        {
            foreach (var option in options)
                yield return option.ReturnValueOr(defaultValue);
        }
    }
}

