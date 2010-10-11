using System.Windows.Forms;
using System.Data;

namespace foobartender.forms
{
    class DataView : InnerForm
    {
        private DataTable data;
        private ColumnHeader[] headers;
        private ListView viewer;

        public DataView(DataTable data, ColumnHeader[] headers)
        {
            this.data = data;
            this.headers = headers;
            Text = "View details";
            SetupComponent();
        }

        private void SetupComponent()
        {
            viewer = new ListView {View = View.Details, Dock = DockStyle.Fill};
            Controls.Add(viewer);
            foreach (var i in headers)
            {
                viewer.Columns.Add(i);
            }
            foreach (DataRow i in data.Rows)
            {
                var item = new ListViewItem(i[0].ToString());
                for (var j = 1; j < i.ItemArray.Length; ++j)
                {
                    item.SubItems.Add(i[j].ToString());
                }
                viewer.Items.Add(item);
            }
        }
    }
}
