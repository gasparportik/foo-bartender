using DataAccessLayer.DAO;

namespace foobartender.forms
{
    internal class InvoiceEdit : GenericEdit
    {
        public InvoiceEdit() : base("Invoices", "Invoice", typeof (Invoice), EditorType.SubItems)
        {
        }
    }
}