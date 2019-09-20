using System;

namespace Grading
{
    class Grade
    {
        public string Subject;
        public double Score;
    }

    class GradeAvg : Grade
    {
        public int Count;

        public GradeAvg(string subject)
        {
            this.Subject = subject;
        }

        public double GetAverage()
        {
            return Score / Count;
        }

        public bool AddGrade(Grade grade)
        {
            if (grade.Subject != Subject) return false;

            Score += grade.Score;
            Count += 1;
            return true;
        }

        public override string ToString()
        {
            return Subject + ": " + Math.Round(GetAverage(), 1);
        }
    }

    class CertificateTable
    {
        GradeAvg[] _gradeTable = new GradeAvg[100];
        int _count = 0;

        public bool AddGrade(Grade grade)
        {
            GradeAvg tempGrade;
            int index = getIndexInArray(grade);
            if (index == -1)
            {
                tempGrade = new GradeAvg(grade.Subject);
                _gradeTable[_count] = tempGrade;
                _count += 1;
            } else
            {
                tempGrade = _gradeTable[index];
            }
            return tempGrade.AddGrade(grade);
        }

        private int getIndexInArray(Grade grade)
        {
            for (int i = 0; i < _count; i++)
            {
                if (grade.Subject == _gradeTable[i].Subject)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string outstr = "";
            for (int i = 0; i < _count; i++)
            {
                outstr += _gradeTable[i] + Environment.NewLine;
            }
            return outstr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CertificateTable table = new CertificateTable();

            Grade[] grades = new Grade[9];
            grades[0] = new Grade() { Subject = "MAT", Score = 1 };
            grades[1] = new Grade() { Subject = "CJL", Score = 4 };
            grades[2] = new Grade() { Subject = "PRG", Score = 1 };
            grades[3] = new Grade() { Subject = "MAT", Score = 2 };
            grades[4] = new Grade() { Subject = "CJL", Score = 5 };
            grades[5] = new Grade() { Subject = "CJL", Score = 3 };
            grades[6] = new Grade() { Subject = "PRG", Score = 1 };
            grades[7] = new Grade() { Subject = "MAT", Score = 2 };
            grades[8] = new Grade() { Subject = "MAT", Score = 2 };

            //ConsoleKeyInfo result;
            //do
            //{
            //    int grade;
            //    string temp;
            //    Console.Write("Předmět: ");
            //    temp = Console.ReadLine();
            //    Console.Write("Známka: ");
            //    int.TryParse(Console.ReadLine(), out grade);

            //    Console.WriteLine("Chceš vložit dalšího? [A]: ");
            //    result = Console.ReadKey();
            //    Console.WriteLine();

            //} while (result.Key == ConsoleKey.A || result.Key == ConsoleKey.Enter);

            foreach (var grade in grades)
            {
                table.AddGrade(grade);
            }
            Console.WriteLine(table);

            Console.ReadKey();
        }
    }
}
