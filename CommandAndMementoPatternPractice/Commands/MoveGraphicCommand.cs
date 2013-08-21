using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public sealed class MoveGraphicCommand : CommandBase
    {
        public MoveGraphicCommand(GraphicsHost graphicsHost)
            : base(graphicsHost)
        {
        }

        public override ExecutionContext Execute(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            if (executionContext.ContextBeforeExecution == null)
            {
                throw new ArgumentException("ContextBeforeExecution can't be null.", "executionContext");
            }

            var newPosition = (double)executionContext.ContextBeforeExecution;
            var oldPosition = GraphicsHost.MoveGraphic(executionContext.GraphicName, newPosition);
            Console.WriteLine("Move graphic {0} to position {1}", executionContext.GraphicName, newPosition);

            return new ExecutionContext(GetType(), executionContext.GraphicName, newPosition, oldPosition);
        }

        public override void Undo(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            if (executionContext.ContextAfterExecution == null)
            {
                throw new ArgumentException("ContextAfterExecution can't be null.", "executionContext");
            }

            var oldPosition = (double)executionContext.ContextAfterExecution;
            GraphicsHost.MoveGraphic(executionContext.GraphicName, oldPosition);
            Console.WriteLine("Undo moving graphic {0}, the graphic is moved back to {1}.", executionContext.GraphicName, oldPosition);
        }

        public override void Redo(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            if (executionContext.ContextBeforeExecution == null)
            {
                throw new ArgumentException("ContextBeforeExecution can't be null.", "executionContext");
            }

            var newPosition = (double)executionContext.ContextBeforeExecution;
            GraphicsHost.MoveGraphic(executionContext.GraphicName, newPosition);
            Console.WriteLine("Redo moving graphic {0} to position {1}", executionContext.GraphicName, newPosition);            
        }
    }
}
