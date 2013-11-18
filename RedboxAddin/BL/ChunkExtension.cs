using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedboxAddin.BL
{
    static class ChunkExtension
    {
        public static IEnumerable<T[]> Chunkify<T>(
            this IEnumerable<T> source, int size)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (size < 1) throw new ArgumentOutOfRangeException("size");
            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var chunk = new T[size];
                    chunk[0] = iter.Current;
                    for (int i = 1; i < size && iter.MoveNext(); i++)
                    {
                        chunk[i] = iter.Current;
                    }
                    yield return chunk;
                }
            }
        }
    }
}
