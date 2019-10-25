using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class Grade
    {
        public string Subject;
        public double Score;

        public override string ToString()
        {
            return $"{Subject} = {Score}";
        }
    }

}
