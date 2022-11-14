using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{

	class a { };
	class b : a { };

	public delegate float Function(float arg);

	public class Pixel
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pixel(int x, int y)
		{
			this.x = x;
			this.y = y;


			a A = new a();
			b? B = new b();

			B = A as b;
		}
	}
	class Line
	{
		public int number { get; private set; }

		public Pixel A;
		public Pixel B;

		public Function fx;
		public Function fy;

		public float lengthX { get; }
		public float lengthY { get; }
		public float tan { get; }

		public Line(Pixel A, Pixel B, int number = -1)
		{
			this.A = A;
			this.B = B;

			lengthX = B.x - A.x;
			lengthY = B.y - A.y;
			tan = lengthY / lengthX;

			fx = delegate (float x)
			{
				return A.y + tan * x - tan*A.x;
			};

			fy = delegate (float y)
			{
				return (y - A.y) / tan + A.x;
			};

			this.number = number;
		}

		public Pixel? intersection_point(Line p2)
		{
			var x = ((this.A.y - this.tan * this.A.x) - (p2.A.y - p2.tan * p2.A.x)) / (p2.tan - this.tan);

			var y = this.fx(x);

			(int y1, int y2)= (A.y < B.y) ? (A.y, B.y) : (B.y, A.y);

			if(y >= y1 && y <= y2) return new Pixel((int)x, (int)y);
			else return null;
		}

		public bool is_point_below(Pixel p1)
		{
			var x = (int)fy(p1.y);
			var y = (int)fx(p1.x);

			if (p1.x == x && p1.y == y) return true;
			else return false;
		}
	}
	class Polygon
	{
		public List<Pixel> points;
		public List<Line> edges;
		public Polygon(List<Pixel> points)
		{
			int edge_index = 0;
			this.edges = new List<Line>();
			this.points = new List<Pixel>();

			points.ForEach(p => this.points.Add(new Pixel(p.x, p.y)));

			for (int i = 0; i < this.points.Count; i++)
			{
				if (i != this.points.Count - 1)
				{
					edges.Add(new Line(this.points[i], this.points[i + 1], edge_index++));
				}
				else
				{
					edges.Add(new Line(this.points[i], this.points[0], edge_index++));
				}
			}
		}

		public static List<Polygon> ReadPolygons(string filename)
		{
			List<Polygon> polygons = new List<Polygon>();

			string[] content = File.ReadAllLines(filename);

			List<Pixel>? points = null;

			for (int i = 0; i < content.Length; i++)
			{
				string data = content[i].Trim(new char[] { ' ', '<', '>' });

				string[] subs = data.Split(' ');

				if (subs.Length == 1)
				{
					if (points != null)
					{
						polygons.Add(new Polygon(points));
					}
					points = new List<Pixel>();
				}
				else
				{
					int x = (int)Convert.ToDouble(subs[0]);
					int y = (int)Convert.ToDouble(subs[1]);

					points.Add(new Pixel(x, y));
				}
			}

			polygons.Add(new Polygon(points));

			return polygons;
		}

		public Bitmap GetBounds((int w, int h) panel_size)
		{
			List<Pixel> bounds = new List<Pixel>();

			foreach(var edge in this.edges)
			{
				var points = CG.GetPoint(edge.A, edge.B, panel_size);

				bounds.AddRange(points);
			}

			Bitmap map = new Bitmap(panel_size.w, panel_size.h);

			foreach(var p in bounds)
			{
				map.SetPixel(p.x, p.y, Color.Black);
			}

			return map;
		}

		public List<Line>? CutLine(Line line)
        {
			object CutMutex = new object();
			List<Pixel> points = new List<Pixel>();
			List<Task> tasks = new List<Task>();

			foreach(var edge in edges)
            {
				var task = new Task(
					() =>
					{
						lock (CutMutex)
						{

							var point = edge.intersection_point(line);

							if (point != null) points.Add(point);
						}
					}
				);

				tasks.Add(task);

				task.Start();
            }

			foreach(var task in tasks)
            {
				task.Wait();
            }

			if (points.Count == 0) return null;

			var p1 = line.A;
			var p2 = line.B;

			(p1, p2) = (p1.x < p2.x) ? (p1, p2) : (p2, p1);

			List<Pixel> points_in_line_x_zone = new List<Pixel>();
			List<Pixel> points_not_in_line_x_zone = new List<Pixel>();

			foreach (var point in points)
            {
				if (point.x <= p2.x && point.x >= p1.x)
                {
					points_in_line_x_zone.Add(point);
                }
				else
                {
					points_not_in_line_x_zone.Add(point);
                }
            }

			var query_sort_by_x = from point in points_in_line_x_zone orderby point.x select point;

			points_in_line_x_zone = query_sort_by_x.AsParallel().ToList();

			List<Line> lines = new List<Line>();
			for (int i = 0; i < points_in_line_x_zone.Count; i++)
			{
				Line line1;

				if (points_in_line_x_zone.Count - i > 1)
				{
					var p3 = points_in_line_x_zone[i];
					var p4 = points_in_line_x_zone[i + 1];

					(p3, p4) = (p3.x < p4.x) ? (p3, p4) : (p4, p3);

					line1 = new Line(p3, p4);

					lines.Add(line1);

					i++;
					continue;
				}
				else if (points_in_line_x_zone.Count - i == 1)
				{
					var p_out = points_not_in_line_x_zone[0];

					var p3 = points_in_line_x_zone[i];

					if (p_out.x < p1.x)
					{
						line1 = new Line(p1, p3);
					}
					else
					{
						line1 = new Line(p3, p2);
					}

					lines.Add(line1);
				}
			}

			return lines;
        }
    }
	static class CG
	{
		public static Pixel FromPixelDegreeToPoint(Pixel p, (int w, int h) panel_size)
		{
			Pixel center_coords = new Pixel(panel_size.w / 2, panel_size.h / 2);
			Pixel point = new Pixel(p.x + 1 + center_coords.x, p.y + 1 - center_coords.y);
			return point;
		}
		public static List<Pixel> GetPoint(Pixel point1_d, Pixel point2_d, (int w, int h) panel_size)
		{
			Pixel center_coords = new Pixel(panel_size.w / 2, panel_size.h / 2);
			Pixel point1 = new Pixel(center_coords.x + point1_d.x, center_coords.y + point1_d.y);
			Pixel point2 = new Pixel(center_coords.x + point2_d.x, center_coords.y + point2_d.y);

			int difference_x = point2.x - point1.x;
			int difference_y = point2.y - point1.y;

			int directionY = (difference_y) > 0 ? 1 : -1;
			int directionX = (difference_x) > 0 ? 1 : -1;

			double LengthX = Math.Abs(difference_x);
			double LengthY = Math.Abs(difference_y);

			List<Pixel> points = new List<Pixel>();

			int x = point1.x;
			int y = point1.y;
			double err = 0;

			if (LengthX > LengthY)
			{
				double t = LengthY / LengthX;

				for (; LengthX >= 0; LengthX--)
				{
					if (err >= 1)
					{
						y += 1 * directionY;
						err -= 1;
					}

					points.Add(new Pixel(x, y));

					x += directionX;
					err += t;
				}
			}
			else
			{
				double t = LengthX / LengthY;

				for (; LengthY >= 0; LengthY--)
				{
					if (err >= 1)
					{
						x += 1 * directionX;
						err -= 1;
					}

					points.Add(new Pixel(x, y));

					y += directionY;
					err += t;
				}
			}

			return points;
		}
		public static Bitmap Brethenhem_algoritm(Pixel point1_d, Pixel point2_d, (int w, int h) panel_size)
		{
			var points = GetPoint(point1_d, point2_d, panel_size);

			Bitmap bitmap = new Bitmap(panel_size.w, panel_size.h);

			foreach (var p in points)
			{
				bitmap.SetPixel(p.x, p.y, Color.Black);
			}

			return bitmap;
		}

		public static Bitmap Brethenhem_algoritm(List<Pixel> points, (int w, int h) panel_size)
		{
			Bitmap bitmap = new Bitmap(panel_size.w, panel_size.h);

			foreach (var p in points)
			{
				bitmap.SetPixel(p.x, p.y, Color.Black);
			}

			return bitmap;
		}

		public static Bitmap FillPolygon(Polygon polygon, (int w, int h) panel_size)
		{
			Bitmap map = new Bitmap(panel_size.w, panel_size.h);

			List<Pixel> points = new List<Pixel>();

			foreach (var edge in polygon.edges)
			{
				var edge_points = GetPoint(edge.A, edge.B, panel_size);

				var QUERY_sort_by_x = from point in edge_points
									  group point by point.y;

				var edge_points_grooped_by_y = QUERY_sort_by_x.ToList();

                foreach (var groope in edge_points_grooped_by_y)
                {
                    var groope_list = groope.ToList();

                    for (int i = 0; i < groope_list.Count - 1; i++)
                    {
                        edge_points.Remove(groope_list[i]);
                    }
                }

                points.AddRange(edge_points);
			}

			var QUERY_groop_by_y = from point in points
								   orderby point.x
								   group point by point.y;


			foreach (var groop_y in QUERY_groop_by_y)
			{
				var line_y = groop_y.ToList();

				var filter = from point1 in line_y
                             from point2 in line_y
                             where point1.x != point2.x
                             select point1;

                line_y = filter.ToList();

                for (int i = 0; i < line_y.Count - 1; i += 2)
				{
					var point1 = line_y[i];
					var point2 = line_y[i + 1];

					for (int x = point1.x; x < point2.x; x++)
					{
						map.SetPixel(x, point1.y, Color.Red);
					}
				}
			}

			return map;
		}
		public static bool any_in_bounds(Pixel p1, Pixel p2, int x_min, int x_max, int y_min, int y_max)
		{
			if((p1.x < x_min && p2.x < x_min) || (p1.x > x_max && p2.x > x_max))
            {
				return false;
            }
			if((p1.y < y_min && p2.y < y_min) || (p1.y > y_max && p2.y > y_max))
            {
				return false;
            }

			return true;
		}
		public static bool all_in_bounds(Pixel p1, Pixel p2, int x_min, int x_max, int y_min, int y_max)
		{
			if((p1.y >= y_min && p1.y <= y_max && p1.x >= x_min && p1.x <= x_max) &&
				(p2.y >= y_min && p2.y <= y_max && p2.x >= x_min && p2.x <= x_max))
			{
				return true;
			}
			return false;
		}
		public static Bitmap? PolyClip(Pixel p1, Pixel p2, Polygon bounds, (int w, int h) panel_size)
		{
			var lines = bounds.CutLine(new Line(p1, p2));

			if (lines == null || lines.Count == 0) return null;

			Bitmap map = new Bitmap(panel_size.w, panel_size.h);

			List<Pixel> line_pixels = new List<Pixel>();

			foreach(var line in lines)
            {
				line_pixels.AddRange(GetPoint(line.A, line.B, panel_size));
            }

			return Brethenhem_algoritm(line_pixels, panel_size);
		}
		public static void middle_point_clip(Graphics g, Pixel p1, Pixel p2, int x_min, int x_max, int y_min, int y_max, (int w, int h) panel_size)
		{
			int lengthX = Math.Abs(p2.x - p1.x);
			int lengthY = Math.Abs(p2.y - p1.y);

			if (lengthX <= 1 || lengthY <= 1) return;
			if (!any_in_bounds(p1, p2, x_min, x_max, y_min, y_max)) return;
			if(all_in_bounds(p1, p2 ,x_min, x_max, y_min, y_max))
			{
				lock (g)
				{
					var map = Brethenhem_algoritm(p1, p2, panel_size);
					map.RotateFlip(RotateFlipType.RotateNoneFlipY);
					g.DrawImage(map, 0, 0);
					return;
				}
			}

			Task.Factory.StartNew(() => middle_point_clip(g, p1, new Pixel((p1.x + p2.x) / 2, (p1.y + p2.y) / 2), 
				x_min, x_max, y_min, y_max, panel_size));

			Task.Factory.StartNew(() => middle_point_clip(g, new Pixel((p1.x + p2.x) / 2, (p1.y + p2.y) / 2), p2, 
				x_min, x_max, y_min, y_max,  panel_size));
		}
	}
}

//	<5>
//<39 348>
//<68 300>
//<277 148>
//<350 298>
//<231 314>
//<5>
//<0 0>
//<0 50>
//<200 200>
//<50 0>


//<5>
//<0 80>
//<25 35>
//<75 25>
//<40 -10>
//<50 -60>
//<0 -40>
//<-50 -60>
//<-40 -10>
//<-75 25>
//<-25 35>