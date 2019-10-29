using System;
using System.Collections;
using System.Text;

namespace ArrayUnlimited
{
    public class UnlimitedArray : IDynamicArray, IEnumerable
    {
        private object[] _array;
        private const int GROW = 1;

        public UnlimitedArray()
        {
            _array = new object[GROW];
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var item in _array)
                {
                    if (!(item is null)) count++;
                }
                return count;
            }
        }
        
        public int Length => _array.Length;

        /// <summary>
        ///   Zvětší nebo zmenší pole prvků
        /// </summary>
        /// <param name="oldArray">pole, které bude zvětšeno nebo zmenšeno</param>
        /// <param name="newSize">velikost pole po zvětšení / zmenšení</param>
        private static void ResizeArray(ref object[] oldArray, int newSize)
        {
            if (newSize <= 0) throw new ArgumentOutOfRangeException("newSize", "Parametr musí být kladné číslo.");

            object[] newArr = new object[newSize];
            for (int i = 0; i < Math.Min(oldArray.Length, newArr.Length); i++)
            {
                newArr[i] = oldArray[i];
            }
            oldArray = newArr;
        }

        private static int GetFirstIndexOfNull(object[] array, int fromIndex = 0)
        {
            for (int i = fromIndex; i < array.Length; i++)
            {
                if (array[i] is null) return i;
            }
            return -1;
        }

        public object Get(int position)
        {
            //if (position < 0 || position >= Length) return null; efficiency issue
            return _array[position];
        }

        public object[] GetAll()
        {
            object[] result = new object[Count];
            int i = 0;
            foreach (var item in this)
            {
                result[i++] = item;
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _array)
            {
                if (!(item is null)) yield return item;
            }
        }

        public void Add(object value)
        {
            int insertPosition = GetFirstIndexOfNull(_array);
            if (insertPosition == -1) insertPosition = Length;
            Insert(value, insertPosition);
        }

        public void Insert(object value, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position", "Parametr musí být kladné číslo.");

            if (position >= Length) ResizeArray(ref _array, position + GROW);

            if (Get(position) != null) ShiftItems(position);
            _array[position] = value;
        }

        public void ShiftItems(int indexFrom)
        {
            if (indexFrom >= Length || indexFrom < 0) return;

            int idx = GetFirstIndexOfNull(_array, indexFrom + 1);
            if (idx == -1)
            {
                idx = Length;
                ResizeArray(ref _array, Length + GROW);
            }

            for (int i = idx; i > indexFrom; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[indexFrom] = null;
        }

        public bool Delete(object value)
        {
            bool result = false;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(value))
                {
                    result = true;
                    _array[i] = null;
                }
            }

            return result;
        }

        public void Delete(int position)
        {
            if (position < 0 || position >= Length) return;

            _array[position] = null;
        }
    }
}
