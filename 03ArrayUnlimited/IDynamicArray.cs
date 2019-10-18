using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayUnlimited
{
    interface IDynamicArray
    {
        object Get(int position);
        void Insert(object value, int position);
        void ShiftItems(int idexFrom);
        int Count { get; }
        int Length { get; }
    }
}
