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

			polygons = Polygon.ReadPolygons("../../../poly.txt");
		}
		public void Draw_Random_Lines(int count_of_rand_point)
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

				DrawLine(new Pixel(rand_value_x1, -rand_value_y1),
					new Pixel(rand_value_x2, -rand_value_y2), (grafic_width, grafic_height));
			}
		}

		public void DrawLine(Pixel p1, Pixel p2, (int w, int h) panel_size)
        {
			if (boudns_off.Checked)
			{
				var map = CG.Brethenhem_algoritm(p1, p2, panel_size);
				g.DrawImage(map, 0, 0);
			}
			else
			{
				Polygon poly = null;

				if (bounds_middle.Checked)
				{
					int x_min = (int)x_min_numericUpDown.Value;
					int x_max = (int)x_max_numericUpDown.Value;
					int y_min = -(int)y_min_numericUpDown.Value;
					int y_max = -(int)y_max_numericUpDown.Value;

					poly = new Polygon(new List<Pixel>() { new Pixel(x_min, y_min),
					new Pixel(x_min, y_max), new Pixel(x_max, y_max), new Pixel(x_max, y_min) });

					CG.middle_point_clip(g, p1, p2, x_min, x_max, y_min, y_max, panel_size);
				}
				else if (bounds_poly.Checked)
				{
					try
					{
						poly = polygons[0];

						var map = CG.PolyClip(p1, p2, poly, panel_size);

						g.DrawImage(map, 0, 0);
					}
					catch { }
				}
				if (poly == null) return;

				var map_boudns = poly.GetBounds(panel_size);
				g.DrawImage(map_boudns, 0, 0);
			}
			
		}

		private void draw_button_Click(object sender, EventArgs e)
		{
			int X1 = (int)(X1_numericUpDown.Value);
			int Y1 = (int)(Y1_numericUpDown.Value);

			int X2 = (int)(X2_numericUpDown.Value);
			int Y2 = (int)(Y2_numericUpDown.Value);

			//X1 = Y1 = -100;
			//X2 = Y2 = 100;

			var p1 = new Pixel(X1, -Y1);
			var p2 = new Pixel(X2, -Y2);

			var panel_size = (grafic_width, grafic_height);

			DrawLine(p1, p2, panel_size);
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
				var map = CG.FillPolygon(poly, (draw_panel.Width, draw_panel.Height), console, g);

				g.DrawImage(map, 0, 0);
			}
		}

        private void bounds_button_Click(object sender, EventArgs e)
        {
			int x_min = (int)x_min_numericUpDown.Value;
			int x_max = (int)x_max_numericUpDown.Value;
			int y_min = -(int)y_min_numericUpDown.Value;
			int y_max = -(int)y_max_numericUpDown.Value;

			var poly = new Polygon(new List<Pixel>() { new Pixel(x_min, y_min),
					new Pixel(x_min, y_max), new Pixel(x_max, y_max), new Pixel(x_max, y_min) });

			var bounds = poly.GetBounds((grafic_width, grafic_height));

			g.DrawImage(bounds, 0, 0);
        }
    }
}