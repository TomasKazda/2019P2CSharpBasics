using System;

namespace DisplayHelper
{
    public class Display
    {
        private LabelItem _item;
        int _x, _y, _width, _height;

        public Display(int x = 0, int y = 0, int width = 80, int height = 5)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public void AddItem(LabelItem item)
        {
            _item = item;
        }

        public void Refresh()
        {
            //todo vymazat a namalovat rámeček (private metoda)
            Console.SetCursorPosition(_x + 2, _y + 2);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{_item.Name}: ");
            Console.Write(_item.Value);
        }
    }
}
