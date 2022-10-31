using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
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
        public Edge(Point A, Point B, int number = -1)
        {
            this.A = A;
            this.B = B;

            this.number = number;
        }
    }
    class Polygon
    {
        public List<Point> points;
        public List<Edge> edges;
        public int N
        {
            get
            {
                return (points == null) ? 0 : points.Count;
            }
        }

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
        public static Bitmap FillPolygon(Polygon polygon, (int w, int h) panel_size)
        {
            Bitmap map = new Bitmap(panel_size.w, panel_size.h);

            var QUERY_all_points_groped_by_Y_coordinate = from edge in polygon.edges
                                                          from point in GetPoint(edge.A, edge.B, panel_size)
                                                          orderby point.y, point.x
                                                          group new { edge_index = edge.number, point } by point.y;

            foreach (var line_y in QUERY_all_points_groped_by_Y_coordinate)
            {
                var line_y_list = line_y.ToList();

                for (int i = 0; i < line_y_list.Count; i++)
                {
                    var point1 = line_y_list[i];

                    if (line_y_list.Count - i >= 2)
                    {
                        var point2 = line_y_list[i + 1];

                        if ((point1.edge_index == point2.edge_index - 1 || point1.edge_index == point2.edge_index + 1) ||
                            (point1.edge_index == 0 && point2.edge_index == polygon.edges.Count - 1))
                        {

                            for (int j = point1.point.x; j < point2.point.x; j++)
                            {
                                map.SetPixel(j, point1.point.y, Color.Red);
                            }

                            i += 2;
                        }
                    }
                }
            }

            return map;
        }
    }
}


//public static Bitmap FillPolygon(Polygon polygon, (int w, int h) panel_size)
//{
//    Bitmap map = new Bitmap(panel_size.w, panel_size.h);

//    var QUERY_all_points_groped_by_Y_coordinate = from edge in polygon.edges
//                                                  from point in GetPoint(edge.A, edge.B, panel_size)
//                                                  group new { edge_index = edge.number, point } by point.y;

//    foreach (var line_y in QUERY_all_points_groped_by_Y_coordinate)
//    {
//        var query2 = from point1 in line_y
//                     from point2 in line_y
//                     where point1.edge_index == point2.edge_index + 1 ||
//                           point1.edge_index == point2.edge_index - 1
//                     select new { point1 = point1.point, point2 = point2.point };

//        foreach (var nightboors in query2)
//        {
//            for (int i = nightboors.point1.x; i < nightboors.point2.x; i++)
//            {
//                map.SetPixel(i, nightboors.point1.y, Color.Red);
//            }
//        }
//    }

//    return map;
//}