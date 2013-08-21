using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Shared
{
    public class GraphicObj
    {
        public string Name { get; private set; }
        public double Offset { get; private set; }
        public double Angle { get; private set; }
        public double ZoomScale { get; private set; }

        public GraphicObj(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
            Offset = 0.0f;
            Angle = 0.0f;
            ZoomScale = 0.0f;
        }

        public double Move(double newOffSet)
        {
            var oldOffset = Offset;

            Offset = newOffSet;

            return oldOffset;
        }

        public double Rotate(double newAngle)
        {
            var oldAngle = Angle;

            Angle = newAngle;

            return oldAngle;
        }

        public double ZoomIn(double newScale)
        {
            var oldScale = ZoomScale;

            ZoomScale = newScale;

            return oldScale;
        }
    }
}
