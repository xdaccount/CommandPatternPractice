using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public class RotateGraphicCommand : CommandBase
    {
        private readonly double _newAngle;
        private double _oldAngle;

        public RotateGraphicCommand(string graphicName, double newAngle, GraphicsHost graphicsHost) 
            : base(graphicName, graphicsHost)
        {
            _newAngle = newAngle;
        }

        public override void Execute()
        {
            _oldAngle = GraphicsHost.RotateGraphic(GraphicName, _newAngle);
            Console.WriteLine("Rotate graphic {0} {1} degree.", GraphicName, _newAngle);
        }

        public override void Undo()
        {
            GraphicsHost.RotateGraphic(GraphicName, _oldAngle);
            Console.WriteLine("Undo rotating graphic {0} degree.", GraphicName);
        }

        public override void Redo()
        {
            _oldAngle = GraphicsHost.RotateGraphic(GraphicName, _newAngle);
            Console.WriteLine("Redo rotating graphic {0} {1} degree.", GraphicName, _newAngle);
        }
    }
}
