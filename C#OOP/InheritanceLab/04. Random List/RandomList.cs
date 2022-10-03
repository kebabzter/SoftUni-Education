using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        public string RandomString()
        {
            string result = string.Empty;
            Random rnd = new Random();
            int index = rnd.Next();
            result = this[index];
            this.RemoveAt(index);
            return result;
        }
    }
}
