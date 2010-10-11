using System.Collections;
using System.Data;

namespace DataAccessLayer.DAO
{
    public class Product : TableEntity
    {
        private string name;
        private float price;
        private int unitId;

        public Product()
        {
            tabledef = new TableDefinition("Product");
        }

        public Product(int productId) : base(productId)
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int UnitId
        {
            get { return unitId; }
            set { unitId = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool LoadByCategory(int categoryId)
        {
            return LoadFiltered("CategoryId = " + categoryId);
        }

        public object[] GetUnits()
        {
            Execute("LoadUnitsForProduct", new Hashtable {{"ProductId", base.Id}});
            var ret = new object[Table().Rows.Count];
            var i = 0;
            foreach (DataRow row in Table().Rows)
            {
                var unit = new DataHolder(row[1].ToString());
                unit.Add("Id", row[0].ToString());
                unit.Add("Ratio", row[2].ToString());
                ret[i++] = unit;
            }
            return ret;
        }
    }
}