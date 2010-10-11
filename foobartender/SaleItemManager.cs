using System.Windows.Forms;
using foobartender.forms;
using foobartender.GUI;

namespace foobartender
{
    class SaleItemManager : ItemManager
    {
        public SaleItemManager(OrderForm parent, Panel container, ItemEditor header) : base(parent, container, header)
        {
        }

        public override void Insert(ItemEditor caller)
        {
            ((OrderForm)parent).DeliverItem(caller);
        }
    }
}
