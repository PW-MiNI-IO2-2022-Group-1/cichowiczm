using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace iolab1
{

    public class StringCalculator
    {
        private static readonly string[] d = { ",","\n" };
        public static int CalculateString(string s)
        {
            string[] dd = d;
            string sep="";
            if (string.IsNullOrWhiteSpace(s))
                return 20;
            if (s.StartsWith("//"))
            {
                string[] ss = s.Split('\n', 2);

                dd = dd.Concat( newd(ss[0]) ).ToArray();
               
                s = ss[1];
            }
            if(sep!="")
            {
                int i = s.IndexOf(sep[0]);

            }
            int[] n = s.Split(dd,StringSplitOptions.None)
                .Select(str => Int32.Parse(str)).Where(n => n < 1000).ToArray();
            if (n.Any(a => a < 0)) throw new ArgumentException("Negative number", nameof(s));
            else return n.Sum();
            throw new NotImplementedException();
        }
        private static List<string> newd(string line)
        {
            if (line.ElementAt(2) != '[')
                return new List<string>() { line.Substring(2, 1) };
            else
                return new List<string>() { line[3..^1] };
        }
    }
}
