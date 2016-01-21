using System;
using System.Collections.Generic;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public static class GenericCollectionsService
    {
        public static List<T> EnsureSize<T>(this List<T> list, int size) where T: new()
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            
            int count = list.Count;
            if (count < size)
            {
                int capacity = list.Capacity;
                if (capacity < size)
                    list.Capacity = Math.Max(size, capacity * 2);

                while (count < size)
                {
                    list.Add(new T());
                    ++count;
                }
            }

            return list;
        }
    }
}
