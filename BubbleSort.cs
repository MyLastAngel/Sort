using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    // Пузырьковая сортировка
    public static class ArrayBubbleSort
    {
        public static void BubbleSort(this int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                // всплываем элементом вверх
                // пока не встретим предыдущий равный или меньше чем текущий
                for (var ii = i; ii > 0 && arr[ii - 1] > arr[ii]; ii--)
                {
                    var v = arr[ii - 1];
                    arr[ii - 1] = arr[ii];
                    arr[ii] = v;
                }
            }
        }
    }
}
