using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Sort
{
    class Program
    {
        delegate int[] AnonymousFunction(int[] arr);

        static void Main(string[] args)
        {
            var count = 10000;

            // Создаем 10к случайных точек
            var arr = CreateRandom(count);

            Call("MergeSort", arr, (aArray) =>
            {
                return aArray.MergeSort();
            });

            Call("MergeSort v2", arr, (aArray) =>
            {
                return aArray.MergeSort_v2();
            });

            Call("BubbleSort", arr, (aArray) =>
            {
                aArray.BubbleSort();
                return aArray;
            });

            Call("Array.Sort (QuickSort)", arr, (aArray) =>
            {
                Array.Sort(aArray);
                return aArray;
            });

            Console.WriteLine($"Any key to exit...");
            Console.ReadKey();
        }

        // Обобщенный вызов 
        static void Call(string sAlgorithm, int[] arr, AnonymousFunction f)
        {
            var clone = (int[])arr.Clone(); // делаем клон массива для чистоты эксперимента
            var t = Stopwatch.StartNew();

            var result = f(clone);

            t.Stop();

            Console.WriteLine($"[{sAlgorithm}] - Отсортировали '{arr.Length}' элементов за: {t.Elapsed}");

            Check(result);
        }

        // Формируем массив случайных чисел
        static int[] CreateRandom(int count)
        {
            var result = new int[count];

            var random = new Random(count);
            for (var i = 0; i < count; i++)
                result[i] = random.Next(0, count);

            return result;
        }

        // проверка сортировки массива
        static void Check(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    var c = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка алгоритма");
                    Console.ForegroundColor = c;
                    return;
                }
            }
        }
    }
}
