using System.Collections;

namespace DataAccessLayer.DAO
{
    public class Saloon : TableEntity
    {
        private string name;

        public Saloon() { }

        public Saloon(int id)
            : this()
        {
            this.Id = id;
            Load();
        }

        public string Name
        {
            get { return name; }
        }

        private new void Load()
        {
            if (base.Load())
                name = this["Name"].ToString();
        }

        public bool LoadTables()
        {
            return Execute("LoadTablesForSaloon", new Hashtable { { "SaloonId", Id } });
        }
    }
}