using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class GradeAvg : Grade
    {
        public int Count;

        public GradeAvg(string subject)
        {
            this.Subject = subject;
        }

        public double GetAverage()
        {
            return Math.Round(Score / Count, 1);
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
            return Subject + ": " + GetAverage() + " (" + Count + ")";
        }
    }
}
