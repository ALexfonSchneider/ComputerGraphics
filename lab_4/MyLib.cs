using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
	public delegate float Function(float arg);

	class Point
	{
		public int x { get; set; }
		public int y { get; set; }

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
	class Edge
	{
		public int number { get; private set; }

		public Point A;
		public Point B;

		public Function fx;
		public Function fy;

		public float lengthX { get; }
		public float lengthY { get; }
		public float tan { get; }

		public Edge(Point A, Point B, int number = -1)
		{
			this.A = A;
			this.B = B;

			lengthX = B.x - A.x;
			lengthY = B.y - A.y;
			tan = lengthY / lengthX;

			fx = delegate (float x)
			{
				return A.y + tan * x - tan*A.x; // y - tan * x = A.y - tan*A.x
			};

			fy = delegate (float y)
			{
				return (y - A.y) / tan + A.x;
			};

			this.number = number;
		}

		public Point intersection_point(Edge p2)
		{
			var x = ((this.A.y - this.tan * this.A.x) - (p2.A.y - p2.tan * p2.A.x)) / (p2.tan - this.tan);

			var y = this.fx(x);

			return new Point((int)x, (int)y);
		}

		public bool is_point_below(Point p1)
		{
			var x = (int)fy(p1.y);
			var y = (int)fx(p1.x);

			if (p1.x == x && p1.y == y) return true;
			else return false;
		}
	}
	class Polygon
	{
		public List<Point> points;
		public List<Edge> edges;
		public Polygon(List<Point> points)
		{
			int edge_index = 0;
			this.edges = new List<Edge>();
			this.points = new List<Point>();

			points.ForEach(p => this.points.Add(new Point(p.x, p.y)));

			for (int i = 0; i < this.points.Count; i++)
			{
				if (i != this.points.Count - 1)
				{
					edges.Add(new Edge(this.points[i], this.points[i + 1], edge_index++));
				}
				else
				{
					edges.Add(new Edge(this.points[i], this.points[0], edge_index++));
				}
			}
		}

		public static List<Polygon> ReadPolygons(string filename)
		{
			List<Polygon> polygons = new List<Polygon>();

			string[] content = File.ReadAllLines(filename);

			List<Point> points = null;

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
					points = new List<Point>();
				}
				else
				{
					int x = Convert.ToInt32(subs[0]);
					int y = -Convert.ToInt32(subs[1]);

					points.Add(new Point(x, y));
				}
			}

			polygons.Add(new Polygon(points));

			return polygons;
		}

		public Bitmap GetBounds((int w, int h) panel_size)
		{
			List<Point> bounds = new List<Point>();

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
	}

	static class CG
	{
		public static Point FromPixelDegreeToPoint(Point p, (int w, int h) panel_size)
		{
			Point center_coords = new Point(panel_size.w / 2, panel_size.h / 2);
			Point point = new Point(p.x + 1 + center_coords.x, p.y + 1 - center_coords.y);
			return point;
		}
		public static List<Point> GetPoint(Point point1_d, Point point2_d, (int w, int h) panel_size)
		{
			Point center_coords = new Point(panel_size.w / 2, panel_size.h / 2);
			Point point1 = new Point(center_coords.x + point1_d.x - 1, center_coords.y + point1_d.y - 1);
			Point point2 = new Point(center_coords.x + point2_d.x - 1, center_coords.y + point2_d.y - 1);

			int difference_x = point2.x - point1.x;
			int difference_y = point2.y - point1.y;

			int directionY = (difference_y) > 0 ? 1 : -1;
			int directionX = (difference_x) > 0 ? 1 : -1;

			int LengthX = Math.Abs(difference_x);
			int LengthY = Math.Abs(difference_y);

			List<Point> points = new List<Point>();

			int x = point1.x;
			int y = point1.y;
			double err = 0;

			if (LengthX > LengthY)
			{
				double t = (double)LengthY / LengthX;

				for (; LengthX >= 0; LengthX--)
				{
					if (err >= 1)
					{
						y += 1 * directionY;
						err -= 1;
					}

					points.Add(new Point(x, y));

					x += directionX;
					err += t;
				}
			}
			else
			{
				double t = (double)LengthX / LengthY;

				for (; LengthY >= 0; LengthY--)
				{
					if (err >= 1)
					{
						x += 1 * directionX;
						err -= 1;
					}

					points.Add(new Point(x, y));

					y += directionY;
					err += t;
				}
			}

			return points;
		}
		public static Bitmap Brethenhem_algoritm(Point point1_d, Point point2_d, (int w, int h) panel_size)
		{
			var points = GetPoint(point1_d, point2_d, panel_size);

			Bitmap bitmap = new Bitmap(panel_size.w, panel_size.h);

			foreach (var p in points)
			{
				bitmap.SetPixel(p.x, p.y, Color.Black);
			}

			return bitmap;
		}
		public static Bitmap FillPolygon(Polygon polygon, (int w, int h) panel_size, Output console=null, Graphics g=null)
		{
			Bitmap map = new Bitmap(panel_size.w, panel_size.h);

			List<Point> points = new List<Point>();

			foreach(var edge in polygon.edges)
			{
				var edge_points = GetPoint(edge.A, edge.B, panel_size);

				edge_points.RemoveAt(edge_points.Count - 1);

				if(edge_points.Count <= 2) continue;

				var QUERY_sort_by_x = from point in edge_points
									  group point by point.y;

				var edge_points_grooped_by_y = QUERY_sort_by_x.ToList();
				
				foreach(var groope in edge_points_grooped_by_y)
				{
					var groope_list = groope.ToList();

					for(int i = 0; i < groope_list.Count - 1;i++)
					{
						edge_points.Remove(groope_list[i]);

						if(groope.Key == 101)
						{
							var a = 1;
						}
					}
				}

				points.AddRange(edge_points);
			}

			var QUERY_groop_by_y = from point in points
								   orderby point.x
								   group point by point.y;

			foreach(var groop_y in QUERY_groop_by_y)
			{
				var line_y = groop_y.ToList();
				for(int i = 0; i < line_y.Count - 1;i += 2)
				{
					var point1 = line_y[i];
						var point2 = line_y[i+1];

						for(int x = point1.x;x < point2.x;x++)
						{
							map.SetPixel(x, point1.y, Color.Red);
						}
				}
			}

			return map;
		}
		public static void Swap<T>(ref T obj1, ref T obj2) where T : class
		{
			var temp = obj1;
			obj1 = obj2;
			obj2 = temp;
		}

		public static bool any_in_bounds(Point p1, Point p2, int x_min, int x_max, int y_min, int y_max)
		{
			if (p1.y <= y_min && p2.y <= y_min ||
			   p1.y >= y_max && p2.y >= y_max ||
			   p1.x <= x_min && p2.x <= x_min ||
			   p1.x >= x_max && p2.x >= x_max) return false;

			return true;
		}

		public static bool all_in_bounds(Point p1, Point p2, int x_min, int x_max, int y_min, int y_max)
		{
			if((p1.y >= y_min && p1.y <= y_max && p1.x >= x_min && p1.x <= x_max) && (p2.y >= y_min && p2.y <= y_max && p2.x >= x_min && p2.x <= x_max))
			{
				return true;
			}
			return false;
		}

		public static Bitmap PolyClip(Point p1, Point p2, Polygon bounds, (int w, int h) panel_size)
		{
			Edge line = new Edge(p1, p2);

			foreach(var edge in bounds.edges)
			{
				var interseption_point = line.intersection_point(edge);

				if(edge.is_point_below(interseption_point))
				{
					p1.x = interseption_point.x;
					p1.y = interseption_point.y;
				}
			}

			return Brethenhem_algoritm(p1, p2, panel_size);
		}

		public static Bitmap? middle_point_clip(Point p1, Point p2, int x_min, int x_max, int y_min, int y_max, (int w, int h) panel_size)
		{
			int lengthX = Math.Abs(p2.x - p1.x);
			int lengthY = Math.Abs(p2.y - p1.y);

			if (lengthX < 0 || lengthY < 0) return null;
			if (!any_in_bounds(p1, p2, x_min, x_max, y_min, y_max)) return null;
			if(all_in_bounds(p1 , p2 , x_min, x_max, y_min, y_max))
			{
				return Brethenhem_algoritm(p1, p2, panel_size);
			}

			var bitmap = middle_point_clip(p1, new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2), 
				x_min, x_max, y_min, y_max, panel_size);

			if (bitmap != null) return bitmap;

			bitmap = middle_point_clip(new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2), p2, 
				x_min, x_max, y_min, y_max,  panel_size);

			return bitmap;
		}
	}
}
