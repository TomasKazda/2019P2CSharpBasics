using System;
using ArrayUnlimited;

namespace DisplayHelper
{
    public class Display
    {
        private UnlimitedArray _array;
        const int PADDING = 1;
        const int BORDER = 1;
        public Proportion Proportion { get; private set; }

        public Display(int x = 0, int y = 0, int width = 2 * (BORDER+PADDING), int height = 2 * (BORDER + PADDING)) : this(new Proportion() { Height = height, Width = width, X = x, Y = y }) { }

        public Display(Proportion proportion)
        {
            _array = new UnlimitedArray();
            Proportion = proportion;
        }

        public void AddItem(LabelItem item)
        {
            _array.Add(item);
            if (Proportion.Width - 2*(PADDING + BORDER) < item.ToString().Length)
            {
                Proportion.Width = item.ToString().Length + 2 * (PADDING + BORDER);
            }

            if (Proportion.Height - 2 * (PADDING + BORDER) < _array.Count)
            {
                Proportion.Height = _array.Count + 2 * (PADDING + BORDER);
            }
        }

        public void Refresh()
        {
            RepaintBorder();

           
            for (int y = 0; y < _array.Count; y++)
            {
                Console.SetCursorPosition(Proportion.X + (PADDING + BORDER), Proportion.Y + y + (PADDING + BORDER));
                if (((LabelItem)_array[y]).Value == null) Console.Write(addCenteredPadding(_array[y].ToString())); //explicit typing issue
                else Console.Write(_array[y]);
            }
        }

        private string addCenteredPadding(string s)
        {
            if (s.Length >= Proportion.Width - 2 * (PADDING + BORDER)) { return s; }
            int leftPadding = (Proportion.Width - 2 * (PADDING + BORDER) - s.Length) / 2;
            return new string(' ', leftPadding) + s;
        }

        private void RepaintBorder()
        {
            Console.SetCursorPosition(Proportion.X, Proportion.Y);
            Console.Write("+");
            for (int i = 0; i < Proportion.Width - 2*BORDER; i++) { Console.Write("-"); }
            Console.Write("+");

            for (int j = 0; j < Proportion.Height - BORDER; j++)
            {
                Console.SetCursorPosition(Proportion.X, Proportion.Y + j + BORDER);
                Console.Write("|");
                for (int i = 0; i < Proportion.Width - 2*BORDER; i++) { Console.Write(" "); }
                Console.Write("|");
            }

            Console.SetCursorPosition(Proportion.X, Proportion.Y + Proportion.Height - 1);
            Console.Write("+");
            for (int i = 0; i < Proportion.Width - 2*BORDER; i++) { Console.Write("-"); }
            Console.Write("+");
        }
    }
}
