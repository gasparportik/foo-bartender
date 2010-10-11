using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class Constraints
    {
        private static Constraints instance;

        private readonly Dictionary<string, string> columnFormats;
        private readonly Dictionary<string, string> columnNames;
        private readonly Dictionary<string, string> columnAutoJoins;

        private Constraints()
        {
            columnNames = new Dictionary<string, string> {{"Sale.AccountId", "Waiter"}};
            columnFormats = new Dictionary<string, string>
                                {
                                    {"Account.AccessLevel", "s0->error\ns1->admin\ns2->accountant\ns3->waiter"},
                                    {"Sale.Status", "sOCC->Occupied\nsWAI->Waiting\nsDON->Released"}
                                };
            columnAutoJoins = new Dictionary<string, string> { { "CreatedBy", "Account" }, { "SectionFrom", "Section" }, { "SectionTo", "Section" } };
        }

        public static Constraints Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Constraints();
                }
                return instance;
            }
        }

        public string GetColumnName(string table, string column)
        {
            string name = column;
            if (columnNames.Keys.Contains(table + "." + column))
            {
                name = columnNames[table + "." + column];
            }
            else if (columnNames.Keys.Contains(column))
            {
                name = columnNames[column];
            }
            return name;
        }

        public string GetColumnFormat(string table, string column)
        {
            string format = null;
            if (columnFormats.Keys.Contains(table + "." + column))
            {
                format = columnFormats[table + "." + column];
            }
            else if (columnFormats.Keys.Contains(column))
            {
                format = columnFormats[column];
            }
            return format;
        }

        public void SetAutoJoin(ColumnDefinition column)
        {
            if (columnAutoJoins.Keys.Contains(column.tableName + "." + column.id))
            {
                column.joinTableName = columnAutoJoins[column.tableName + "." + column.id];
            } else 
                if (columnAutoJoins.Keys.Contains(column.id))
                {
                    column.joinTableName = columnAutoJoins[column.id];
                } else
                {
                    return;
                }
            column.joinColumnName = "Name";
            column.colName = column.joinTableName + column.joinColumnName;
        }
    }
}