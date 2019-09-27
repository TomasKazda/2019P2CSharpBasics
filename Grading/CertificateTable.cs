using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class CertificateTable
    {
        const int MAXCNT = 2;
        GradeAvg[] _gradeTable = new GradeAvg[MAXCNT];
        int _count = 0;

        public bool AddGrade(Grade grade)
        {
            GradeAvg tempGrade;
            int index = getIndexInArray(grade);
            if (index == -1)
            {
                tempGrade = new GradeAvg(grade.Subject);

                if (_gradeTable.Length == _count)
                    ResizeArray(ref _gradeTable, MAXCNT);

                _gradeTable[_count] = tempGrade;
                _count += 1;
            }
            else
            {
                tempGrade = _gradeTable[index];
            }
            return tempGrade.AddGrade(grade);
        }

        private void ResizeArray(ref GradeAvg[] oldArray, int growCount)
        {

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
}
