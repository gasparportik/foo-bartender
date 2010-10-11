using System.Collections;

namespace DataAccessLayer.DAO
{
    public class Transfer : SubItem
    {
        public Transfer()
        {
            tabledef = new TableDefinition("Transfer");
            subTableDef = new TableDefinition("TransferItem");
        }

        public Transfer(string id) : this()
        {
            Id = int.Parse(id);
        }

        public override bool Commit()
        {
            return ExecuteScalar("TransferProducts", new Hashtable { { "@TransferId", Id } }) == 0;
        }
    }
}