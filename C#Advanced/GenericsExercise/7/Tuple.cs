using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Tuple<TFirst,TSecond>
    {
        public Tuple(TFirst firstEl, TSecond secondEl)
        {
            FirstElement = firstEl;
            SecondElement = secondEl;
        }
        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}
