using System.Collections;

namespace DataAccessLayer.DAO
{
    public class Reception : SubItem
    {
        public Reception()
        {
            tabledef = new TableDefinition("Reception");
            subTableDef = new TableDefinition("ReceptionItem");
        }

        public override bool Commit()
        {
            return Execute("DeliverReception", new Hashtable {{"@ReceptionId", Id}});
        }
    }
}