using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public sealed class CreateGraphicCommand : CommandBase
    {
        public CreateGraphicCommand(GraphicsHost graphicsHost)
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
            var graphicObj = new GraphicObj(graphicName);
            GraphicsHost.AddGraphic(graphicObj);
            Console.WriteLine("Create graphic {0}.", graphicName);

            return new ExecutionContext(GetType(), graphicName, graphicName, graphicObj);
        }

        public override void Undo(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            var graphicName = executionContext.GraphicName;
            GraphicsHost.RemoveGraphic(graphicName);
            Console.WriteLine("Undo adding graphic {0}.", graphicName);
        }

        public override void Redo(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            if (executionContext.ContextAfterExecution == null)
            {
                throw new ArgumentException("ContextAfterExecution can't be null.", "executionContext");
            }

            var objToAdd = executionContext.ContextAfterExecution as GraphicObj;
            if (objToAdd == null)
            {
                throw new ArgumentException("ContextAfterExecution should be GraphicObj type.", "executionContext");
            }

            GraphicsHost.AddGraphic(objToAdd);
            Console.Write("Redo adding graphic {0}.", executionContext.GraphicName);
        }
    }
}
