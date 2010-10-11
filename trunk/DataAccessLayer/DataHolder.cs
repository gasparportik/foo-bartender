using System.Collections;

namespace DataAccessLayer
{
    public class DataHolder
    {
        public static readonly DataHolder NullValue = new DataHolder("");
        private Hashtable objects;
        private string representation;

        static DataHolder()
        {
            NullValue.Add("value", null);
        }

        public DataHolder(string representation)
        {
            this.representation = representation;
            objects = new Hashtable();
        }

        public object this[string key]
        {
            get { return objects[key]; }
        }

        public void Add(string key, object obj)
        {
            objects.Add(key, obj);
        }

        public override string ToString()
        {
            return representation;
        }
    }
}