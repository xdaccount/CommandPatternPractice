using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public sealed class CreateGraphicCommand : CommandBase
    {
        private GraphicObj _oldObj;

        public CreateGraphicCommand(string graphicName, GraphicsHost graphicsHost)
            : base(graphicName, graphicsHost)
        {
        }

        public override void Execute()
        {
            var graphicObj = new GraphicObj(GraphicName);
            GraphicsHost.AddGraphic(graphicObj);
            Console.WriteLine("Create graphic {0}.", GraphicName);
        }

        public override void Undo()
        {
            _oldObj = GraphicsHost.RemoveGraphic(GraphicName);
            Console.WriteLine("Undo creating graphic {0}.", GraphicName);
        }

        public override void Redo()
        {
            GraphicsHost.AddGraphic(_oldObj);
            Console.WriteLine("Redo creating graphic {0}.", GraphicName);
        }
    }
}
