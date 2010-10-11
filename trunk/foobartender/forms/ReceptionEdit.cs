using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class ReceptionEdit : GenericEdit
    {
        public ReceptionEdit() : base("Receptions", "Reception", typeof(Reception), EditorType.SubItems) { }
    }
}
