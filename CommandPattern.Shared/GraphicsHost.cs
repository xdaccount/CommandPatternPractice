using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Shared
{
    public class GraphicsHost
    {
        private readonly Dictionary<string, GraphicObj> _graphicObjs = new Dictionary<string, GraphicObj>();

        public void AddGraphic(GraphicObj graphicObj)
        {
            if (graphicObj == null)
            {
                throw new ArgumentNullException("graphicObj");
            }

            if (_graphicObjs.ContainsKey(graphicObj.Name))
            {
                throw new ArgumentException("Graphic with same name already exits.");
            }

            _graphicObjs.Add(graphicObj.Name, graphicObj);
        }

        public GraphicObj RemoveGraphic(string graphicName)
        {
            if (graphicName == null)
            {
                throw new ArgumentNullException("graphicName");
            }

            if (!_graphicObjs.ContainsKey(graphicName))
            {
                throw new ArgumentException("Specified graphic doesn't exits.");
            }

            var graphicObj = _graphicObjs[graphicName];

            _graphicObjs.Remove(graphicName);

            return graphicObj;
        }

        public double MoveGraphic(string graphicName, double offset)
        {
            if (graphicName == null)
            {
                throw new ArgumentNullException("graphicName");
            }

            if (!_graphicObjs.ContainsKey(graphicName))
            {
                throw new ArgumentException("Specified graphic doesn't exits.");
            }

            var graphicObj = _graphicObjs[graphicName];
            return graphicObj.Move(offset);
        }

        public double RotateGraphic(string graphicName, double rotateAngle)
        {
            if (graphicName == null)
            {
                throw new ArgumentNullException("graphicName");
            }

            if (!_graphicObjs.ContainsKey(graphicName))
            {
                throw new ArgumentException("Specified graphic doesn't exits.");
            }

            var graphicObj = _graphicObjs[graphicName];
            return graphicObj.Rotate(rotateAngle);
        }

        public double ZoomInGraphic(string graphicName, double scale)
        {
            if (graphicName == null)
            {
                throw new ArgumentNullException("graphicName");
            }

            if (!_graphicObjs.ContainsKey(graphicName))
            {
                throw new ArgumentException("Specified graphic doesn't exits.");
            }

            var graphicObj = _graphicObjs[graphicName];
            return graphicObj.ZoomIn(scale);
        }
    }
}
