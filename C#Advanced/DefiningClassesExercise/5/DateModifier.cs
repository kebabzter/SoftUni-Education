using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public static int GetDiff(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.Parse(dateOne);
            DateTime secondDate = DateTime.Parse(dateTwo);
            TimeSpan diff = secondDate - firstDate;
            return Math.Abs(diff.Days);
        }

    }
}
