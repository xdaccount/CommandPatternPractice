using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public sealed class RotateGraphicCommand : CommandBase
    {
        public RotateGraphicCommand(GraphicsHost graphicsHost)
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

            var newAngle = (double)executionContext.ContextBeforeExecution;
            var oldAngle = GraphicsHost.RotateGraphic(executionContext.GraphicName, newAngle);
            Console.WriteLine("Rotate graphic {0} to angle {1}", executionContext.GraphicName, newAngle);

            return new ExecutionContext(GetType(), executionContext.GraphicName, newAngle, oldAngle);
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

            var oldAngle = (double)executionContext.ContextAfterExecution;
            GraphicsHost.RotateGraphic(executionContext.GraphicName, oldAngle);
            Console.WriteLine("Undo rotating graphic {0}, the graphic is rotated back to angle {1}.", executionContext.GraphicName, oldAngle);
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

            var newAngle = (double)executionContext.ContextBeforeExecution;
            GraphicsHost.RotateGraphic(executionContext.GraphicName, newAngle);
            Console.WriteLine("Redo rotating graphic {0} to angle {1}", executionContext.GraphicName, newAngle);
        }
    }
}
