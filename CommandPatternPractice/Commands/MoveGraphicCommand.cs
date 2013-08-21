using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public sealed class MoveGraphicCommand : CommandBase
    {
        private double _newOffset;

        private double _oldOffset;

        public MoveGraphicCommand(string graphicName, double newOffset, GraphicsHost graphicsHost)
            : base(graphicName, graphicsHost)
        {
            _newOffset = newOffset;
        }

        public override void Execute()
        {
            _oldOffset = GraphicsHost.MoveGraphic(GraphicName, _newOffset);
            Console.WriteLine("Move graphic {0} to {1} position.", GraphicName, _newOffset);
        }

        public override void Undo()
        {
            GraphicsHost.MoveGraphic(GraphicName, _oldOffset);
            Console.WriteLine("Undo moving graphic {0} to {1} position.", GraphicName, _newOffset);
        }

        public override void Redo()
        {
            _oldOffset = GraphicsHost.MoveGraphic(GraphicName, _newOffset);
            Console.WriteLine("Redo moving graphic {0} to {1} position.", GraphicName, _newOffset);
        }
    }
}
