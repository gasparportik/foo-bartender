using System;
using System.Linq;

namespace foobartender
{
    public static class ValueFormatter
    {
        public static string Format(string pattern, object value)
        {
            if (pattern == null || value == null)
            {
                return (value != null) ? value.ToString() : "";
            }
            object formatted = value;
            string[] patterns = pattern.Split('\n');
            foreach (string p in patterns)
            {
                string op = p.Substring(0, 1);
                string with = p.Substring(1);
                if (op.Equals("p"))
                {
                    formatted = with.Replace("%", formatted.ToString());
                }
                else if (op.Equals("s"))
                {
                    string[] bla = {"->"};
                    string[] fromto = with.Split(bla, StringSplitOptions.None);
                    if (fromto.Length == 2)
                    {
                        formatted = formatted.ToString().Replace(fromto[0], fromto[1]);
                    }
                }
            }
            return formatted.ToString();
        }

        public static bool FormatHidesValue(string pattern)
        {
            if (pattern == null)
            {
                return false;
            }
            string[] patterns = pattern.Split('\n');
            foreach (string p in patterns)
            {
                string op = p.Substring(0, 1);
                string with = p.Substring(1);
                if (op.Equals("p") && !with.Contains('%'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}