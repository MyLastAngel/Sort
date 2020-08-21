using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sort
{

    //https://ru.wikipedia.org/wiki/%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0_%D1%81%D0%BB%D0%B8%D1%8F%D0%BD%D0%B8%D0%B5%D0%BC


    public static class ArrayMergeSort
    {
        /// <summary>Алгоритм сортировки слиянием</summary>
        public static int[] MergeSort(this int[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }
        static int[] Sort(int[] arr, int start, int end)
        {
            int[] result = null;

            // если у нас 1 элемент то он считается отсортированным
            if (end == start)
            {
                result = new int[] { arr[end] };
                return result;
            }

            var half = (int)(start + end) / 2;

            var aLeft = Sort(arr, start, half);// Сортируем левую часть
            var aRight = Sort(arr, half + 1, end);// сортируем правую часть

            result = new int[aLeft.Length + aRight.Length];

            int current_right = 0,
                current_left = 0;

            for (var i = 0; i < result.Length; i++)
            {
                // если у нас левая часть и правая часть
                if (current_left < aLeft.Length && current_right < aRight.Length)
                {
                    if (aLeft[current_left] > aRight[current_right])
                    {
                        result[i] = aRight[current_right];
                        current_right++;
                    }
                    else
                    {
                        result[i] = aLeft[current_left];
                        current_left++;
                    }
                }
                // Если у нас не прошло условие что есть все индексы в пределах выравниваемого лимита
                // то проверяем какой индекс еще не записан и записываем
                else if (current_right < aRight.Length)
                {
                    result[i] = aRight[current_right];
                    current_right++;
                }
                else
                {
                    result[i] = aLeft[current_left];
                    current_left++;
                }
            }

            return result;
        }
    }
}
