using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class CertificateTable
    {
        const int MAXCNT = 2;
        GradeAvgList _gradeTable = new GradeAvgList(MAXCNT);

        public GradeAvg AddGrade(Grade grade)
        {
            return _gradeTable.Add(grade);
        }

        public GradeAvg[] GetAllGrades() => _gradeTable.GetAll();

        public override string ToString()
        {
            string outstr = "";
            foreach (var gradeAvg in _gradeTable.GetAll())
            {
                outstr += gradeAvg + Environment.NewLine;
            }
            return outstr;
        }
    }
}
