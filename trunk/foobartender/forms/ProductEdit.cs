using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class ProductEdit : GenericEdit
    {
        public ProductEdit() : base("Products", "Product", typeof(Product),EditorType.Generic)
        {
            AddAction("Export to XML", "xmlexport");
        }

        protected override void CustomCommand(string command)
        {
            switch (command)
            {
                case "xmlexport":
                    if (lstData.SelectedItems.Count > 0)
                    {
                        var x = lstData.SelectedItems;
                    } else
                    {
                        System.Windows.Forms.MessageBox.Show("Select at least one item!");
                    }
                    break;
            }
        }
    }
}
