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
	public partial class MainForm : Form
	{
		Graphics g;
		List<Polygon> polygons;

		Output console;

        public int grafic_width { get; private set; }
		public int grafic_height { get; private set; }

		public MainForm()
		{
			InitializeComponent();

			g = draw_panel.CreateGraphics();

			grafic_width = draw_panel.Width;
			grafic_height = draw_panel.Height;

			console = new Output();
			console.Show();

			//polygons = Polygon.ReadPolygons("polygons.txt");
		}
		void Draw_Random_Lines(int count_of_rand_point)
		{
			Random rand = new Random();

			int bound_x = grafic_width / 2 - 1;
			int bound_y = grafic_height / 2 - 1;

			for (int i = 0; i < count_of_rand_point; i++)
			{
				var rand_value_x1 = rand.Next(-bound_x, bound_x);
				var rand_value_y1 = rand.Next(-bound_y, bound_y);

				var rand_value_x2 = rand.Next(-bound_x, bound_x);
				var rand_value_y2 = rand.Next(-bound_y, bound_y);

				var map = CG.Brethenhem_algoritm(new Point(rand_value_x1, -rand_value_y1),
					new Point(rand_value_x2, -rand_value_y2), (grafic_width, grafic_height));

				g.DrawImage(map, 0, 0);
			}
		}
		private void draw_button_Click(object sender, EventArgs e)
		{
			int X1 = (int)(X1_numericUpDown.Value);
			int Y1 = (int)(Y1_numericUpDown.Value);

			int X2 = (int)(X2_numericUpDown.Value);
			int Y2 = (int)(Y2_numericUpDown.Value);

			var p1 = new Point(X1, -Y1);
			var p2 = new Point(X2, -Y2);

			var panel_size = (grafic_width, grafic_height);

			Bitmap map = null;

			if (bouds_checkBox.Checked)
			{
				int x_min = (int)x_min_numericUpDown.Value;
				int x_max = (int)x_max_numericUpDown.Value;
				int y_min = (int)y_min_numericUpDown.Value;
				int y_max = (int)y_max_numericUpDown.Value;

				map = CG.middle_point_clip(p1, p2, x_min, x_max, y_min, y_max, panel_size);

				if (map == null) return;
			}
			else
			{
				map = CG.Brethenhem_algoritm(p1, p2, panel_size);
			}

			g.DrawImage(map, 0, 0);
		}
		private void random_button_Click(object sender, EventArgs e)
		{
			int count_of_rand_point = (int)count_of_rand_points_numericUpDown.Value;

			Draw_Random_Lines(count_of_rand_point);
		}
		private void clear_button_Click(object sender, EventArgs e)
		{
			g.Clear(Color.WhiteSmoke);
		}
        private void draw_poly_button_Click(object sender, EventArgs e)
        {
			foreach (var poly in polygons)
			{
				var map = CG.FillPolygon(poly, (draw_panel.Width, draw_panel.Height));

				g.DrawImage(map, 0, 0);
			}
		}
        private void cbouds_heckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}