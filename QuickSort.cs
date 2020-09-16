using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public static class ArrayQuickSort
    {
        /// <summary>Алгоритм Быстрой сортировки</summary>
        public static int[] QuickSort(this int[] array)
        {
            QuickSortPartition(array, 0, array.Length - 1);
            return array;

            //var indexes = new int[array.Length];
            //for (var i = 0; i < array.Length; i++)
            //    indexes[i] = i;
            //log(indexes, -1, -1, -1, -1, -1);

            //var deep = 0;
            //QuickSort(array, 0, array.Length - 1, deep);
            //return array;
        }

        static void QuickSort(int[] array, int start, int end, int deep)
        {
            // Цикл пока индекс начала, меншье индекса конца.
            do
            {
                Console.WriteLine();
                log(array, start, end, -1, -1, -1);

                // Получаем центр относительно которого сортируем
                //var center = (start + end) / 2;
                
                int left = start, right = end;
                var center = left + ((right - left) >> 1);

                // Проверка на значения в предельных точках
                if (array[start] > array[end])
                {
                    Swap(ref array[start], ref array[end]);

                    log(array, start, end, center, left, right);
                }
                if (array[center] > array[end])
                {
                    Swap(ref array[center], ref array[end]);

                    log(array, start, end, center, left, right);
                }
                if (array[center] < array[start])
                {
                    Swap(ref array[center], ref array[start]);

                    log(array, start, end, center, left, right);
                }


                // Двигаемся от start к center и от end к center
                // если есть элементы в позиции left со значением > чем в позиции center
                // и есть элементы в позиции rigth со значением < чем в позиции center
                // то меняем left  и rigth местами
                do
                {
                    // Ищем со start - элемент, который больше чем центр
                    while (array[center] > array[left])
                        left++;

                    // Ищем с end - элемент, который меньше чем центр
                    while (array[center] < array[right])
                        right--;

                    if (left > right)
                        break;

                    // наши счетчики в промежутке, то меняем их местами
                    // тк. старт > чем центр а конец < чем центр
                    if (left < right)
                    {
                        Swap(ref array[right], ref array[left]);

                        log(array, start, end, center, left, right);
                    }

                    // смещаем позиции
                    left++;
                    right--;

                } while (left <= right);


                if (right - start <= end - left)
                {
                    if (start < right)
                        QuickSort(array, start, right, deep);

                    start = left;
                }
                else
                {
                    if (left < end)
                        QuickSort(array, left, end, deep);

                    end = right;
                }


            } while (start < end);
        }


        static void log(int[] array, int start, int end, int center, int left, int right)
        {
            var format = "D2";
            var c = Console.ForegroundColor;
            Console.WriteLine("");

            for (var i = 0; i < array.Length; i++)
            {
                Console.ForegroundColor = c;

                if (i == center)
                    Console.ForegroundColor = ConsoleColor.White;
                if (i == start)
                    Console.ForegroundColor = ConsoleColor.Red;
                if (i == end)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                if (i == left)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (i == right)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.Write(array[i].ToString(format));
                Console.Write(" ");
            }

            Console.ForegroundColor = c;
        }


        static void QuickSortPartition(int[] array, int start, int end)
        {
            // Если у нас нет промежутка - завершаем сортировку
            if (start >= end)
                return;

            var pivotIndex = Partition(array, start, end);

            // Рекурсивно сорируем левую часть относительно опорного элемента
            QuickSortPartition(array, start, pivotIndex - 1);

            // Рекурсивно сорируем правую часть относительно опорного элемента
            QuickSortPartition(array, pivotIndex + 1, end);

        }
        static int Partition(int[] array, int start, int end)
        {
            var pivot = start - 1;
            for (var i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[end]);
            return pivot;
        }


        static void Swap(ref int first, ref int second)
        {
            var v = first;
            first = second;
            second = v;
        }
    }
}
