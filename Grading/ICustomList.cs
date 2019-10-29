using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    interface ICustomList
    {
        GradeAvg Add(Grade g);
        int Add(GradeAvg g);
        bool Delete(GradeAvg g);
        bool Delete(int position);
        GradeAvg Get(int position);
        GradeAvg[] GetAll();
        int IndexOf(GradeAvg g);
        int IndexOf(string subject);
        int Count { get; }
        int Length { get; }
    }
}
