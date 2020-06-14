using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Memoryspel.WpfCore
{
    public static class RandomHelper
    {
        public static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public static Color NextColor()
        {
            var color = new Color()
            {
                A = 255,
                R = (byte)Random.Next(0, 256),
                G = (byte)Random.Next(0, 256),
                B = (byte)Random.Next(0, 256),
            };

            return color;
        }

        // reference: https://stackoverflow.com/questions/273313/randomize-a-listt
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
