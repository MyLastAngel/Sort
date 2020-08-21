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
            // Создаем count случайных точек
            var count = 100000;
            var arr = CreateRandom(count);

            Call("MergeSort", arr, (aArray) =>
            {
                return aArray.MergeSort();
            });

            Call("HeapSort ", arr, (aArray) =>
            {
                aArray.HeapSort();
                return aArray;
            });

            Call("Array.Sort (QuickSort)", arr, (aArray) =>
            {
                Array.Sort(aArray);
                return aArray;
            });

            Console.WriteLine($"Нажмите `y` для запуска пузырьковой сортировки (Очень долго): ");
            var key = Console.ReadKey();
            if (key.KeyChar == 'y')
            {
                Call("BubbleSort", arr, (aArray) =>
                {
                    aArray.BubbleSort();
                    return aArray;
                });
            }
            else
                Console.WriteLine($"Правильный выбор ;)");

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

            Console.WriteLine($"{t.Elapsed.TotalMilliseconds} - [{sAlgorithm}] - Отсортировали '{arr.Length}' элементов");

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
