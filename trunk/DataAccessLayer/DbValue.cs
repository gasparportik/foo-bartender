using System;
using Util;

namespace DataAccessLayer
{
    public class DbValue
    {
        private readonly object value;

        public DbValue(object value)
        {
            this.value = value == null ? value : value.GetType().Equals(GetType()) ? ((DbValue)value).value : value;
        }

        public static DbValue operator +(DbValue a, object b)
        {
            return new DbValue(b);
        }

        public override string ToString()
        {
            return ToString(value);
        }

        public int ToInt()
        {
            return ToInt(value);
        }

        public double ToDouble()
        {
            return value == null ? 0D : double.Parse(value.ToString());
        }

        public bool ToBoolean()
        {
            return value == null ? false : (value.GetType().Equals(true)) ? (bool)value : bool.Parse(value.ToString());
        }

        public object ToDb()
        {
            return value;
        }

        public static implicit operator int(DbValue obj)
        {
            return obj.ToInt();
        }

        public static implicit operator string(DbValue obj)
        {
            return obj.ToString();
        }

        public static string ToString(object value)
        {
            return value == null ? "" : value.ToString();
        }

        public static int ToInt(object value)
        {
            try
            {
                return value == null ? 0 : int.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                Logger.Instance.ExpectedException(null, ex);
                return 0;
            }
        }
    }
}