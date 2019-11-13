using System;
using ArrayUnlimited;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using static System.Console;

namespace ArrayEfficiencyTest
{
    class Program
    {
        static readonly int count = 100000;
        static object[] array = new object[count];
        static UnlimitedArray uArray = new UnlimitedArray(count);
        static List<object> list = new List<object>(1000);
        static Random rnd = new Random();
        
        public static void ExecuteTest<T>(Action<int, int> dataAdd, T data, int cnt) where T : IEnumerable
        {
            int sum;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < cnt; i++)
            {
                dataAdd(rnd.Next(), i);
            }
            WriteLine($"{sw.ElapsedTicks} tick");
            sw.Restart();
            sum = 0;
            foreach (var item in data)
            {
                sum += (int)item;
            }
            WriteLine($"{sw.ElapsedTicks} tick");
            WriteLine($"suma: {sum}{Environment.NewLine}");
        }

        static void Main(string[] args)
        {
            WriteLine("Kolekce - List");
            ExecuteTest((val, pos) => list.Add(val), list, count);

            WriteLine("UnlimitedArray");
            ExecuteTest((val, pos) => array.SetValue(val, pos), array, count);

            WriteLine("Vanilla Array");
            ExecuteTest((val, pos) => uArray.Insert(val, pos), uArray, count);
        }
    }
}
