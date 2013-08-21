using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public sealed class ZoomInGraphicCommand : CommandBase
    {
        public ZoomInGraphicCommand(GraphicsHost graphicsHost)
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

            var newScale = (double)executionContext.ContextBeforeExecution;
            var oldScale = GraphicsHost.ZoomInGraphic(executionContext.GraphicName, newScale);
            Console.WriteLine("Rotate graphic {0} to scale {1}", executionContext.GraphicName, newScale);

            return new ExecutionContext(GetType(), executionContext.GraphicName, newScale, oldScale);
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

            var oldScale = (double)executionContext.ContextAfterExecution;
            GraphicsHost.ZoomInGraphic(executionContext.GraphicName, oldScale);
            Console.WriteLine("Undo zooming graphic {0}, the graphic is rotated back to {1}.", executionContext.GraphicName, oldScale);
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

            var newScale = (double)executionContext.ContextBeforeExecution;
            GraphicsHost.ZoomInGraphic(executionContext.GraphicName, newScale);
            Console.WriteLine("Redo zooming graphic {0} to scale {1}", executionContext.GraphicName, newScale);
        }
    }
}
