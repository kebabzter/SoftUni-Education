using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeupleGeneric
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst firstEl, TSecond secondEl, TThird thirdEl)
        {
            FirstElement = firstEl;
            SecondElement = secondEl;
            ThirdElement = thirdEl;
        }
        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }

        public TThird ThirdElement { get; private set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
