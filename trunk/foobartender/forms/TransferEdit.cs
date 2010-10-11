using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class TransferEdit : GenericEdit
    {
        public TransferEdit() : base("Stock transfers", "Transfer", typeof(Transfer), EditorType.SubItems) { }
    }
}
