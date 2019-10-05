using System;

namespace PeopleArray
{
    class Person
    {
        public int Age;
        public double Weight = 66;
        public string Gendre;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Person man1 = new Person() { Age = 30, Gendre = "M", Weight = 82 };

            Person[] people = new Person[10];

            int i = 1;
            ConsoleKeyInfo result;
            do
            {
                int agetemp;
                string gendretemp;
                Console.Write("{0}. člověk - věk: ", i);
                int.TryParse(Console.ReadLine(), out agetemp);
                Console.Write("{0}. člověk - pohlaví: ", i);
                gendretemp = Console.ReadLine();

                people[i - 1] = new Person() { Age = agetemp, Gendre = gendretemp };
                i += 1;

                Console.WriteLine("Chceš vložit dalšího? [A]: ");
                result = Console.ReadKey();
                Console.WriteLine();

            } while (result.Key == ConsoleKey.A || result.Key == ConsoleKey.Enter);

            Console.ReadKey();
        }
    }
}
