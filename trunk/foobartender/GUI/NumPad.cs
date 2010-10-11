using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace foobartender.GUI
{
    public partial class NumPad : UserControl
    {
        private Control attachedTo;
        public static bool beeping;
        private Timer timer;

        public NumPad()
        {
            InitializeComponent();
            SetupComponent();
        }

        private void SetupComponent()
        {
            timer = new Timer { Interval = 500 };
            timer.Tick += HidePad;
            BorderStyle = BorderStyle.FixedSingle;
            var chars = new Dictionary<string, string>
                            {
                                { "1", "1" },
                                { "2", "2" },
                                { "3", "3" },
                                { "4", "4" },
                                { "5", "5" },
                                { "6", "6" },
                                { "7", "7" },
                                { "8", "8" },
                                { "9", "9" },
                                { "0", "0" },
                                { ".", "." },
                                { "<-", "\b"},
                                { "<", "LEFT" },
                                { "C", "C" },
                                { ">", "RIGHT"}
                            };
            foreach (var c in chars)
            {
                var button = new Button
                                 {
                                     Font = new Font("monospace", 20F),
                                     Size = new Size(50, 50),
                                     Text = c.Key,
                                     Tag = c.Value,
                                     Margin = new Padding(0),
                                     FlatStyle = FlatStyle.Flat
                                 };
                panButtons.Controls.Add(button);
                button.Click += ButtonClicked;
            }
            Location = new Point(2000,2000);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (attachedTo == null) return;
            var c = ((Button)sender).Tag.ToString();
            if (c.Equals("C"))
            {
                attachedTo.Text = "";
            }
            else
            {
                SendKeys.Send("{" + c + "}");
            }
            if (beeping)
            {
                new Thread(Beep).Start();
            }
            attachedTo.Focus();
        }

        static void Beep()
        {
            Console.Beep();
        }

        public static void WaitClose()
        {
            Thread.Sleep(1000);
        }

        public void HidePad(object state, EventArgs e)
        {
            if (attachedTo.Focused) return;
            Visible = false;
        }

        public void Attach(Control control)
        {
            control.Enter += ControlEntered;
            control.Leave += ControlLeft;
        }

        private void ControlLeft(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void ControlEntered(object sender, EventArgs e)
        {
            attachedTo = (Control)sender;
            Location = GetPrecisePopupLocation(attachedTo);
            Visible = true;
        }

        private static Point GetPrecisePopupLocation(Control control)
        {
            var p = new Point(control.Location.X, control.Location.Y + control.Size.Height);
            while (!control.Parent.GetType().IsSubclassOf(typeof(Form)))
            {
                control = control.Parent;
                p.X += control.Location.X;
                p.Y += control.Location.Y;
            }
            return p;
        }

        public void Detach(Control control)
        {
            control.Enter -= ControlEntered;
            control.Leave -= ControlLeft;
        }
    }
}