using System.Windows.Forms;

namespace foobartender.GUI
{
    public partial class InputBox : UserControl
    {
        private InputBoxStyle style;

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBoxStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                UpdateStyle();
            }
        }

        private void UpdateStyle()
        {
            switch (style)
            {
                case InputBoxStyle.Label:

                    break;
            }
        }
    }

    public enum InputBoxStyle
    {
        Label,
        Text,
        TextReadOnly,
        DropDown,
        Combobox,
        Numeric,
        NumericInteger,
    }
}
