using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public sealed class RemoveGraphicCommand : CommandBase
    {
        public RemoveGraphicCommand(GraphicsHost graphicsHost)
            : base(graphicsHost)
        {
        }

        public override ExecutionContext Execute(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            var graphicName = executionContext.GraphicName;
            var removedObj = GraphicsHost.RemoveGraphic(graphicName);
            Console.WriteLine("Remove graphic {0}.", graphicName);

            return new ExecutionContext(GetType(), graphicName, graphicName, removedObj);
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

            var removedObj = executionContext.ContextAfterExecution as GraphicObj;
            if (removedObj == null)
            {
                throw new ArgumentException("ContextAfterExecution should be GraphicObj type.", "executionContext");
            }

            GraphicsHost.AddGraphic(removedObj);
            Console.WriteLine("Undo removing graphic {0}.", executionContext.GraphicName);
        }

        public override void Redo(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            var graphicName = executionContext.GraphicName;
            GraphicsHost.RemoveGraphic(graphicName);
            Console.WriteLine("Redo removing graphic {0}.", graphicName);
        }
    }
}
