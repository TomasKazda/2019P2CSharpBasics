using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    interface ICustomList
    {
        void Add(Grade g);
        void Add(GradeAvg g);
        bool Insert(GradeAvg g, int position);
        bool Delete(GradeAvg g);
        bool Delete(int position);
        GradeAvg Get(int position);
        int IndexOf(GradeAvg g);
        int IndexOf(string subject);
    }
}
