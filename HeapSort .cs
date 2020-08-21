using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Sort
{
    public static class ArrayHeapSort
    {
        /// <summary>Алгоритм сортировки слиянием</summary>
        public static void HeapSort(this int[] array)
        {
            // Строим кучу, чтобы в массиве родительские элементы были больше чем потомки
            // в итоге получаем в 0 элементе максимальное число
            var index = (int)array.Length / 2 - 1;
            while (index >= 0)
                Sort(array, index--, array.Length);

            // сортируем
            // в 0 позиции всегда будет максимум
            // поэтому 0 переносим в конец, строим кучу из массива на 1 меньше
            index = array.Length - 1;
            while (index > 0)
            {
                var v = array[index];
                array[index] = array[0];
                array[0] = v;

                Sort(array, 0, index);

                index--;
            }

        }

        static void Sort(int[] array, int index, int length)
        {
            if (index >= length)
                return;

            int max = index,
                left = index * 2 + 1, // +1 элемент в массиве будет левым узлом 
                right = left + 1; // +2 элемент в массиве будет правым узлом

            // Проверяем - является ли левый элемент меньше че родитель
            if (left < length && array[left] > array[max])
                max = left;

            if (right < length && array[right] > array[max])
                max = right;

            // Если в куче все ок, то выходим
            if (max == index)
                return;

            // Меняем местами максимальный с индексом
            var v = array[index];
            array[index] = array[max];
            array[max] = v;

            Sort(array, max, length);
        }
    }
}
