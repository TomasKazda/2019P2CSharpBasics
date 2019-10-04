using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class GradeAvgList : ICustomList
    {
        private GradeAvg[] _gt;
        private readonly int maxcnt;
        int _count = 0;
        public GradeAvgList(int maxcnt)
        {
            _gt = new GradeAvg[maxcnt];
            this.maxcnt = maxcnt;
        }

        public void Add(GradeAvg g)
        {
            throw new NotImplementedException();
        }

        public bool Delete(GradeAvg g)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int position)
        {
            throw new NotImplementedException();
        }

        public GradeAvg Get(int position)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(GradeAvg g)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(string subject)
        {
            for (int i = 0; i < _gt.Length; i++)
            {
                if (subject == _gt[i].Subject)
                {
                    return i;
                }
            }

            return -1;
        }

        //private int getIndexInArray(Grade grade)
        //{
        //    for (int i = 0; i < _count; i++)
        //    {
        //        if (grade.Subject == _gradeTable[i].Subject)
        //        {
        //            return i;
        //        }
        //    }

        //    return -1;
        //}

        public bool Insert(GradeAvg g, int position)
        {
            throw new NotImplementedException();
        }

        private void ResizeArray(ref GradeAvg[] oldArray, int growCount)
        {

        }
    }
}
