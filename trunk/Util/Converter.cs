using System;

namespace Util
{
    public static class Converter
    {
        private const int DECIMAL_PRECISION = 2;

        public static float ToFloat(object o)
        {
            return ToFloat(o.ToString());
        }

        public static string ReFormat(string s)
        {
            return ToString(ToDouble(s));
        }

        public static string ReFormat(object o)
        {
            return ToString(ToDouble(o));
        }

        public static float ToFloat(string s)
        {
            return (float)ToDouble(s);
        }

        public static double ToDouble(string s)
        {
            var f = 0F;
            try
            {
                s = s.Replace(",", "");
                f = float.Parse(s);
                if (f == float.NaN)
                {
                    f = 0;
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                //Logger.Instance.Exception(null,ex);
                //error expected
            }
            return f;
        }

        public static double ToDouble(object o)
        {
            return ToDouble(o.ToString());
        }

        public static string ToString(float f)
        {
            return ToString((double)f);
        }

        public static string ToString(double f)
        {
            var format = "{0:0.";
            for (var i = DECIMAL_PRECISION; i > 0; --i)
            {
                format += "0";
            }
            format += "}";
            var s = string.Format(format, f);
            if (s.Equals("NaN"))
            {
                s = "0.00";
            }
            return s;
        }
    }
}