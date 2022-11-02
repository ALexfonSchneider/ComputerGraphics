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
            //this.outbox.AppendText(text + '\n');

            var p1 = new Point(0, 0);
            var p2 = new Point(5, 0);
            var p3 = new Point(5, 5);
            var p4 = new Point(0, 5);

            var poly = new Polygon(new List<Point> { p1, p2, p3, p4 });

            var A = new Point(0, 0);
            var B = new Point(10, 10);

            var map = CG.PolyClip(A, B, poly, (100, 100));
        }

        private void Output_Shown(object sender, EventArgs e)
        {
            append_text("");
        }
    }
}
