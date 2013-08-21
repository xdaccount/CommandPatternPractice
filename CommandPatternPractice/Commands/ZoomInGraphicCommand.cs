using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public class ZoomInGraphicCommand : CommandBase
    {
        private readonly double _newScale;

        private double _oldScale;

        public ZoomInGraphicCommand(string graphicName, double newScale, GraphicsHost graphicsHost) 
            : base(graphicName, graphicsHost)
        {
            _newScale = newScale;
        }

        public override void Execute()
        {
            _oldScale = GraphicsHost.ZoomInGraphic(GraphicName, _newScale);
            Console.WriteLine("ZoomIn graphic {0}.", GraphicName);
        }

        public override void Undo()
        {
            GraphicsHost.ZoomInGraphic(GraphicName, _oldScale);
            Console.WriteLine("Undo zooming graphic {0}.", GraphicName);
        }

        public override void Redo()
        {
            _oldScale = GraphicsHost.ZoomInGraphic(GraphicName, _newScale);
            Console.WriteLine("Redo zooming graphic {0}.", GraphicName);
        }
    }
}
