using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Output : Form
    {
        public Output()
        {
            InitializeComponent();
        }

        public void append_text(string text)
        {
            this.outbox.AppendText(text + "\n\t");
        }

        private void Output_Shown(object sender, EventArgs e)
        {
            append_text("");
        }
    }
}
