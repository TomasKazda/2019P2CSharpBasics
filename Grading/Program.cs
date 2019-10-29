using System;
using DisplayHelper;

namespace Grading
{
 
    class Program
    {
        static void Main(string[] args)
        {
            CertificateTable table = new CertificateTable();

            Display displayGrading = new Display(new Proportion() { Width = 40, TopLeft = new System.Drawing.Point(20, 3) });
            displayGrading.AddItem(new LabelItem("-- Vysvědčení --"));
            displayGrading.AddItem(new LabelItem(""));
            Display displayInput = new Display(new Proportion() { Width = 30, TopLeft = new System.Drawing.Point(25, 3) });
            displayInput.AddItem(new LabelItem("---- zadávání předmětu ----"));
            displayInput.AddItem(new LabelItem("Předmět", ""));
            Display displayInput2 = new Display(new Proportion() { Width = 30, TopLeft = new System.Drawing.Point(25, 10) });
            displayInput2.AddItem(new LabelItem("---- zadávání známky ----"));
            displayInput2.AddItem(new LabelItem("Známka", ""));
            Display displayConfirm = new Display(new Proportion() { Width = 30, TopLeft = new System.Drawing.Point(25, 18) });
            displayConfirm.AddItem(new LabelItem("Chceš vložit dalšího? [A]", ""));

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

            ConsoleKeyInfo result;
            do
            {
                int grade;
                string temp;
                displayInput.Refresh();
                temp = Console.ReadLine();
                displayInput2.Refresh();
                int.TryParse(Console.ReadLine(), out grade);
                if (temp.Length == 3 && grade < 6 && grade > 0) table.AddGrade(new Grade() { Score = grade, Subject = temp });

                displayConfirm.Refresh();
                result = Console.ReadKey();
                Console.Clear();

            } while (result.Key == ConsoleKey.A || result.Key == ConsoleKey.Enter);

            foreach (var grade in grades)
            {
                GradeAvg ga = table.AddGrade(grade);
            }

            foreach (var item in table.GetAllGrades())
            {
                displayGrading.AddItem(new LabelItem(item.Subject, item.GetAverage()));
            }

            Console.Clear();
            displayGrading.Refresh();


            Console.ReadKey();
        }
    }
}
