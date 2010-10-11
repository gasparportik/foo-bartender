using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class SectionEdit : GenericEdit
    {
        public SectionEdit() : base("Sections", "Section", typeof(Section), EditorType.Generic) { }
    }
}
