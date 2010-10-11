using System.Data;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    public class ColumnDefinition
    {
        public string colName;
        public object defaultValue;
        public string format;
        public string id;
        public string joinColumnName;
        public string joinTableName;
        public int length;
        public bool listed = true;
        public string name;
        public bool nullable;
        public string tableName;
        public string type;


        public ColumnDefinition(string tableName, string name, string type, bool nullable, object defaultValue,
                                int length)
        {
            id = name;
            colName = name;
            if (name.EndsWith("Id") && name.Length > 2)
            {
                this.name = name.Replace("Id", "");
                joinTableName = this.name;
                joinColumnName = "Name";
                colName = joinTableName + joinColumnName;
            } else
            {
                this.name = name;
            }
            Constraints.Instance.SetAutoJoin(this);
            this.type = type;
            this.defaultValue = defaultValue;
            this.nullable = nullable;
            this.length = length;
            this.tableName = tableName;
            this.name = Constraints.Instance.GetColumnName(this.tableName, this.name);
            format = Constraints.Instance.GetColumnFormat(this.tableName, id);
        }

        public object[] GetItems()
        {
            var tbl = Database.RunQuery("SELECT Id, " + joinColumnName + " FROM " + joinTableName);
            var ret = new object[tbl.Rows.Count];
            var i = 0;
            foreach (DataRow row in tbl.Rows)
            {
                var h = new DataHolder(row[1].ToString());
                h.Add("value", row[0].ToString());
                ret[i++] = h;
            }
            return ret;
        }

        public Regex GetRegex()
        {
            switch (type)
            {
                case "int":
                case "tinyint":
                    return new Regex("[0-9]+");
                case "char":
                case "varchar":
                    return new Regex("^.{" + (nullable ? "0" : "1") + "," + length + "}$");
                default:
                    return new Regex(nullable ? ".*" : ".+");
            }
        }
    }
}