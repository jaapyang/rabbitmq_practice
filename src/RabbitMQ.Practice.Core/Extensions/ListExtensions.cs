﻿using System.Collections.Generic;
using System.Linq;

namespace RabbitMQ.Practice.Core.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
    }
}