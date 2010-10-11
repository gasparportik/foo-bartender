using System;
using System.Data;
using System.Collections;

namespace DataAccessLayer
{
    public class Database : DAL
    {
        private static Database instance;
        private static string connectionString;

        public static Database Instance
        {
            get {
                if (instance == null)
                {
                    SetLogin("DbDescriber", "f00B4rt3nd3r", ref connectionString);
                    instance = new Database();
                }
                return instance;
            }
        }

        private Database()
        {

        }

        public DataTable GetTableStructure(String tableName)
        {
            Select("SELECT column_name AS Name, data_type AS Type, column_default AS DefaultValue, is_nullable AS Nullable, character_maximum_length AS MaxLen FROM information_schema.columns WHERE table_name = '" + tableName + "'");
            return Table();
        }

        public DataTable GetBalance()
        {
            Select("SELECT CC.Date, CC.Total AS Income, P.Total AS Expense FROM CashClosing CC " +
                "LEFT JOIN Production P ON YEAR(P.Date) = YEAR(CC.Date) AND MONTH(P.Date) = MONTH(CC.Date) AND " +
                "DAY(P.Date) = DAY(CC.Date) ORDER BY CC.Date DESC");
            foreach (DataRow i in Table().Rows)
            {
                if (!i.IsNull("Expense"))
                {
                    i["Income"] = int.Parse(i["Income"].ToString()) - int.Parse(i["Expense"].ToString());
                }
            }
            return Table();
        }

        public static DataTable RunQuery(string query)
        {
            Database b = new Database();
            b.Select(query);
            return b.Table();
        }

        public static void CallProcedure(string name, Hashtable param)
        {
            Database b = new Database();
            b.Execute(name, param);
        }
    }
}
