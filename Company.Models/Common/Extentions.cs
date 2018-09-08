using System;
using System.Collections.Generic;

namespace Company.Models.Common
{
    public static class Extentions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}