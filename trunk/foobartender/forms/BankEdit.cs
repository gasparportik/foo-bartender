using DataAccessLayer.DAO;

namespace foobartender.forms
{
    public class BankEdit : GenericEdit
    {
        public BankEdit() : base("Bank informations", "Bank", typeof (Bank), EditorType.Generic)
        {
        }
    }
}