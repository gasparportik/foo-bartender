using System;
using System.Data;

namespace DataAccessLayer
{
    public class DataProxy
    {
        private DataRow source;
        private String colName;

        public DataProxy()
        {
        }

        public DataProxy(DataRow source, String colName)
        {
            this.source = source;
            this.colName = colName;
        }

        public DbValue this[string key]
        {
            get
            {
                try
                {
                    return new DbValue(source[key]);
                }
                catch (Exception)
                {
                    return new DbValue(null);
                }
            }
        }

        override public String ToString()
        {
            return source[colName].ToString();
        }
    }
}