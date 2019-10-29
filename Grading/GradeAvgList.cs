using System;
using System.Collections.Generic;
using System.Text;

namespace Grading
{
    class GradeAvgList : ICustomList
    {
        private GradeAvg[] _gt;
        private readonly int maxcnt;

        public GradeAvgList(int maxcnt)
        {
            _gt = new GradeAvg[maxcnt];
            this.maxcnt = maxcnt;
        }

        public int Count { 
            get {
                for (int i = 0; i < _gt.Length; i++)
                {
                    if (_gt[i] is null) return i;
                } 
                return _gt.Length;
            } 
        }

        public int Length { 
            get {
                return _gt.Length;
            }
        }

        /// <summary>
        ///   Metoda přidá novou známku do souhrnu známek
        /// </summary>
        /// <param name="g">známka</param>
        public GradeAvg Add(Grade g)
        {
            // 1)  zjistíme, zda předmět je již v _gt (a získáme index)
            // 2)  pokud ne, vytvoříme nový pomocí Add(GradeAvg) (a získáme index)
            // 3)  přes Get() získáme referenci na souhrnnou známku a aktualizujeme ji pomocí "g"
            return Get(Add(new GradeAvg(g.Subject) { Count = 1, Score = g.Score }));
        }

        /// <summary>
        ///   Vloží nové souhrnné hodnocení, nebo doplní (přepíše?) stávající
        /// </summary>
        /// <param name="g">souhrnná známka</param>
        /// <returns>index nově vložené známky</returns>
        public int Add(GradeAvg g)
        {
            //přidáváme nový GradeAvg a případně předtím zvětšíme pole: ResizeArray(ref _gt, maxcnt)
            int idx = IndexOf(g);
            if (idx == -1)
            {
                idx = Count;
                if (idx == Length) ResizeArray(ref _gt, maxcnt);
                _gt[idx] = g;
            } else
            {
                _gt[idx].Count += g.Count;
                _gt[idx].Score += g.Score;
            }

            return idx;
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
            return _gt[position];
        }

        public GradeAvg[] GetAll()
        {
            var result = new GradeAvg[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _gt[i];
            }
            return result;
        }

        public int IndexOf(GradeAvg g)
        {
            return IndexOf(g.Subject);
        }

        public int IndexOf(string subject)
        {
            for (int i = 0; i < Count; i++)
            {
                if (subject == _gt[i].Subject)
                {
                    return i;
                }
            }

            return -1;
        }

        private static void ResizeArray(ref GradeAvg[] oldArray, int growUp)
        {
            if (growUp < 0) throw new ArgumentOutOfRangeException("growUp", "Parametr musí být kladné číslo.");

            GradeAvg[] newGradeAvgs = new GradeAvg[oldArray.Length + growUp];
            for (int i = 0; i < oldArray.Length; i++)
            {
                newGradeAvgs[i] = oldArray[i];
            }
            oldArray = newGradeAvgs;
        }
    }
}
