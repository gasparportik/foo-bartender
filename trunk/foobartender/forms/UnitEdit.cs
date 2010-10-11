using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class UnitEdit : GenericEdit
    {
        public UnitEdit() : base("Measuring units", "Unit", typeof(Unit), EditorType.Generic) { }
    }
}
