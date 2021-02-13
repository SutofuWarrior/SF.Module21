using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SF.Module21.Task1
{
    class Program
    {
        static void Main()
        {
            string text = File.ReadAllText("/Users/pdn/Desktop/Text.txt");
            var words = text.Split(" ");

            var list = new List<string>();

            var testResults = new double[2][];
            testResults[0] = new double[words.Length];
            testResults[1] = new double[words.Length];

            var watcher = Stopwatch.StartNew();

            for (int i = 0; i < words.Length; i++)
            {
                list.Add(words[i]);

                testResults[0][i] = watcher.Elapsed.TotalMilliseconds;
                watcher.Restart();
            }

            var linkedList = new LinkedList<string>();

            watcher.Restart();
            for (int i = 0; i < words.Length; i++)
            {
                linkedList.AddLast(words[i]);

                testResults[1][i] = watcher.Elapsed.TotalMilliseconds;
                watcher.Restart();
            }

            watcher.Stop();

            Console.WriteLine("List");
            ShowResults(testResults[0]);

            Console.WriteLine();

            Console.WriteLine("LinkedList");
            ShowResults(testResults[1]);

            Console.ReadKey();
        }

        static void ShowResults(double[] array)
        {
            Console.WriteLine("Минимум: " + Min(array));
            Console.WriteLine("Максимум: " + Max(array));
            double total = Total(array);
            Console.WriteLine("Итого: " + total);
            Console.WriteLine("Среднее: " + total / array.Length);
        }

        static double Min(double[] array)
        {
            double min = 0;

            for (int i = 0; i < array.Length; i++)
                if (min > array[i])
                    min = array[i];

            return min;
        }

        static double Max(double[] array)
        {
            double max = 0;

            for (int i = 0; i < array.Length; i++)
                if (max < array[i])
                    max = array[i];

            return max;
        }

        static double Total(double[] array)
        {
            double total = 0;

            for (int i = 0; i < array.Length; i++)
                total += array[i];

            return total;
        }
    }
}