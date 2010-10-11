using System.Collections;

namespace DataAccessLayer.DAO
{
    public class Invoice : SubItem
    {
        public Invoice()
        {
            tabledef = new TableDefinition("Invoice");
            subTableDef = new TableDefinition("InvoiceItem");
        }

        public Invoice(int id) : this()
        {
            ((TableEntity) this).Id = id;
            Load();
        }

        public override bool Commit()
        {
            return (Execute("DeliverInvoice", new Hashtable {{"@InvoiceId", ((TableEntity) this).Id}}));
        }
    }
}