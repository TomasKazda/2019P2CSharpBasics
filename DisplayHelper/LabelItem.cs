using System;
using System.Collections.Generic;
using System.Text;

namespace DisplayHelper
{
    public class LabelItem
    {
        private string _name; //např. "Věk"
        private object _value; //např. 22

        public LabelItem(string name, object value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Value
        {
            get { return _value.ToString(); }
        }
    }
}
