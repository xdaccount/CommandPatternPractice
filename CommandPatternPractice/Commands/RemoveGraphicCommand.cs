using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public sealed class RemoveGraphicCommand : CommandBase
    {
        private GraphicObj _removedGraphicObj;

        public RemoveGraphicCommand(string graphicName, GraphicsHost graphicsHost)
            : base(graphicName, graphicsHost)
        {
            _removedGraphicObj = null;
        }

        public override void Execute()
        {
            _removedGraphicObj = GraphicsHost.RemoveGraphic(GraphicName);
            Console.WriteLine("Reomve graphic {0} degree.", GraphicName);
        }

        public override void Undo()
        {
            GraphicsHost.AddGraphic(_removedGraphicObj);
            Console.WriteLine("Undo reomving graphic {0} degree.", GraphicName);
        }

        public override void Redo()
        {
            _removedGraphicObj = GraphicsHost.RemoveGraphic(GraphicName);
            Console.WriteLine("Redo reomving graphic {0} degree.", GraphicName);
        }
    }
}
