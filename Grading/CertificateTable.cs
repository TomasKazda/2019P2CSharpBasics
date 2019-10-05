using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class CertificateTable
    {
        const int MAXCNT = 2;
        GradeAvgList _gradeTable = new GradeAvgList(MAXCNT);

        public void AddGrade(Grade grade)
        {
            _gradeTable.Add(grade);
        }
       
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
