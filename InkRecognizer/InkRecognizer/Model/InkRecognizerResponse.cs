using System;
using System.Collections.Generic;

namespace InkRecognizer.Model
{
    public class Alternate
    {
        public string category { get; set; }
        public string recognizedString { get; set; }
    }

    public class BoundingRectangle
    {
        public double height { get; set; }
        public double topX { get; set; }
        public double topY { get; set; }
        public double width { get; set; }
    }

    public class RotatedBoundingRectangle
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class RecognitionUnit
    {
        //public IList<Alternate> alternates { get; set; }
        public BoundingRectangle boundingRectangle { get; set; }
        public string category { get; set; }
        public string Class { get; set; }
        public int id { get; set; }
        public int parentId { get; set; }
        public string recognizedText { get; set; }
        public IList<RotatedBoundingRectangle> rotatedBoundingRectangle { get; set; }
        public IList<int> strokeIds { get; set; }
        public IList<int> childIds { get; set; }
    }

    public class InkRecognizerResponse
    {
        public IList<RecognitionUnit> recognitionUnits { get; set; }
    }

}
