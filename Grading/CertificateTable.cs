using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class CertificateTable
    {
        const int MAXCNT = 2;
        //        GradeAvg[] _gradeTable = new GradeAvg[MAXCNT];
        GradeAvgList _gradeTable = new GradeAvgList(MAXCNT);

        public void AddGrade(Grade grade)
        {
            _gradeTable.Add(grade);
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
}
