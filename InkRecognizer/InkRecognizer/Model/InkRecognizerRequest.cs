using System;
using System.Collections.Generic;

namespace InkRecognizer.Model
{

    public static class RequestExtensions
    {
        public static List<Point> ToModelPoints(this List<Xamarin.Forms.Point> points)
        {
            var result = new List<Point>();

            points.ForEach(point => result.Add(new Point { x = point.X, y = point.Y }));
            return result;
        }
    }

    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Stroke
    {
        public int id { get; set; }
        public string kind { get; set; } = "inkWriting";
        public List<Point> points { get; set; }
    }

    public class InkRecognizerRequest
    {
        public string language { get; set; } = "en-US";
        public IList<Stroke> strokes { get; set; } = new List<Stroke>();
    }

}
