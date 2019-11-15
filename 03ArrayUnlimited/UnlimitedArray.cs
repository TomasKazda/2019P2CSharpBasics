using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayUnlimited
{
    public class UnlimitedArray<T> : IDynamicArray<T>, IEnumerable<T> where T : class
    {
        private T[] _array;
        private readonly int _grow;

        public UnlimitedArray(int grow = 10)
        {
            _grow = grow;
            _array = new T[_grow];
        }

        public static UnlimitedArray<T> operator +(UnlimitedArray<T> first, UnlimitedArray<T> second)
        {
            UnlimitedArray<T> temp = new UnlimitedArray<T>(first.Count + second.Count);
            int i = 0;
            foreach (var item in first)
            {
                temp.Insert(item, i++);
            }
            foreach (var item in second)
            {
                temp.Insert(item, i++);
            }
            return temp;
        }

        public static UnlimitedArray<T> operator +(UnlimitedArray<T> array, T item)
        {
            UnlimitedArray<T> temp = new UnlimitedArray<T>(array.Count + 1);
            int i = 0;
            foreach (var element in array)
            {
                temp.Insert(element, i++);
            }
            temp.Insert(item, i);
            return temp;
        }

        public T this[int index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Delete(index);
                Insert(value, index);
            }
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
        private static void ResizeArray(ref T[] oldArray, int newSize)
        {
            if (newSize <= 0) throw new ArgumentOutOfRangeException("newSize", "Parametr musí být kladné číslo.");

            T[] newArr = new T[newSize];
            for (int i = 0; i < Math.Min(oldArray.Length, newArr.Length); i++)
            {
                newArr[i] = oldArray[i];
            }
            oldArray = newArr;
        }

        private static int GetFirstIndexOfNull(T[] array, int fromIndex = 0)
        {
            for (int i = fromIndex; i < array.Length; i++)
            {
                if (array[i] is null) return i;
            }
            return -1;
        }

        public T Get(int position)
        {
            //if (position < 0 || position >= Length) return null; efficiency issue
            return _array[position];
        }

        public T[] GetAll()
        {
            T[] result = new T[Count];
            int i = 0;
            foreach (var item in this)
            {
                result[i++] = item;
            }
            return result;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
            {
                if (!(item is null)) yield return item;
            }
        }

        public void Add(T value)
        {
            int insertPosition = GetFirstIndexOfNull(_array);
            if (insertPosition == -1) insertPosition = Length;
            Insert(value, insertPosition);
        }

        public void Insert(T value, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position", "Parametr musí být kladné číslo.");

            if (position >= Length) ResizeArray(ref _array, position + _grow);

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
                ResizeArray(ref _array, Length + _grow);
            }

            for (int i = idx; i > indexFrom; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[indexFrom] = null;
        }

        public bool Delete(T value)
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

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is T)) return base.Equals(obj);

        //    var other = obj.GetAll();

        //    int i = 0;
        //    foreach (var item in this)
        //    {
        //        if (!item.Equals(other[i])) return false;
        //    }

        //    return true;
        //}

        public override string ToString()
        {
            string result = "";
            foreach (var item in this)
            {
                result += item.ToString() + "; ";
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
