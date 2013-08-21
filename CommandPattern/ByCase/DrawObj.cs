using System;

namespace CommandPattern.ByCase
{
    public class DrawObj : ICloneable
    {
        public string Name { get; private set; }
        public double Offset { get; set; }
        public double RotateAngle { get; set; }
        public double ZoomScale { get; set; }

        public DrawObj(string name)
        {
            Name = name;
            Offset = 0.0f;
            RotateAngle = 0.0f;
            ZoomScale = 0.0f;
        }

        public object Clone()
        {
            var other = new DrawObj(Name)
            {
                Offset = Offset, 
                RotateAngle = RotateAngle, 
                ZoomScale = ZoomScale
            };
            return other;
        }
    }
}
