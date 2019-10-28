using System;
using ArrayUnlimited;

namespace DisplayHelper
{
    public class Display
    {
        private UnlimitedArray _array;
        public Proportion Proportion { get; private set; }

        public Display(int x = 0, int y = 0): this(new Proportion() { Height = 5, Width = 4, TopLeft = new System.Drawing.Point(x, y) }) { }

        public Display(Proportion proportion)
        {
            _array = new UnlimitedArray();
            Proportion = proportion;
        }

        public void AddItem(LabelItem item)
        {
            _array.Add(item);
            if (Proportion.Width - 4 < item.ToString().Length)
            {
                Proportion.Width = item.ToString().Length + 4;
            }

            if (Proportion.Height - 4 < _array.Count)
            {
                Proportion.Height = _array.Count + 4;
            }
        }

        public void Refresh()
        {
            RepaintBorder();

            object[] data = _array.GetAll();
            for (int y = 0; y < data.Length; y++)
            {
                Console.SetCursorPosition(Proportion.TopLeft.X + 2, Proportion.TopLeft.Y + y + 2);
                Console.Write(data[y]);
            }
        }

        private void RepaintBorder()
        {
            Console.SetCursorPosition(Proportion.TopLeft.X, Proportion.TopLeft.Y);
            Console.Write("+");
            for (int i = 0; i < Proportion.Width - 2; i++) { Console.Write("-"); }
            Console.Write("+");

            for (int j = 0; j < Proportion.Height - 2; j++)
            {
                Console.SetCursorPosition(Proportion.TopLeft.X, Proportion.TopLeft.Y + j + 1);
                Console.Write("|");
                for (int i = 0; i < Proportion.Width - 2; i++) { Console.Write(" "); }
                Console.Write("|");
            }

            Console.SetCursorPosition(Proportion.TopLeft.X, Proportion.TopLeft.Y + Proportion.Height - 1);
            Console.Write("+");
            for (int i = 0; i < Proportion.Width - 2; i++) { Console.Write("-"); }
            Console.Write("+");
        }
    }
}
