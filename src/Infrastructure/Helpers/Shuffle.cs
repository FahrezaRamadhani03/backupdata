// <copyright file="Shuffle.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Garuda.Infrastructure.Helpers
{
    public static class Shuffle
    {
        public static void Shuffles<T>(this IList<T> list)
        {
            Random _rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
