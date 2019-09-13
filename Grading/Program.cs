using System;

namespace Grading
{
    class Grade
    {
        public string Subject;
        public double Score;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Grade[] grades = new Grade[20];
            grades[0] = new Grade() { Subject = "MAT", Score = 1 };
            grades[1] = new Grade() { Subject = "CJL", Score = 4 };
            grades[2] = new Grade() { Subject = "PRG", Score = 1 };
            grades[3] = new Grade() { Subject = "MAT", Score = 2 };
            grades[4] = new Grade() { Subject = "CJL", Score = 5 };
            grades[5] = new Grade() { Subject = "CJL", Score = 3 };
            grades[6] = new Grade() { Subject = "PRG", Score = 1 };
            grades[7] = new Grade() { Subject = "MAT", Score = 2 };
            grades[8] = new Grade() { Subject = "MAT", Score = 2 };

            ConsoleKeyInfo result;
            do
            {
                int grade;
                string temp;
                Console.Write("Předmět: ");
                temp = Console.ReadLine();
                Console.Write("Známka: ");
                int.TryParse(Console.ReadLine(), out grade);
                
                Console.WriteLine("Chceš vložit dalšího? [A]: ");
                result = Console.ReadKey();
                Console.WriteLine();

            } while (result.Key == ConsoleKey.A || result.Key == ConsoleKey.Enter);

            Console.ReadKey();
        }
    }
}
