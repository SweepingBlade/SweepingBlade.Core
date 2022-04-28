using System;
using System.Collections.Generic;
using System.Linq;

namespace SweepingBlade.Linq;

public static class EnumerableExtensions
{
    public static IEnumerable<TResult> Distinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Select(selector).Distinct();
    }

    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action(item);
        }
    }

    public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Select(selector).ToList();
    }
}