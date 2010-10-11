using DataAccessLayer.DAO;

namespace foobartender.forms
{
    public class SaleEdit : GenericEdit
    {
        public SaleEdit() : base("Sales", "Sale", typeof(Sale), EditorType.ListOnly) { }
    }
}
