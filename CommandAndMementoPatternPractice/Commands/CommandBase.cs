using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public abstract class CommandBase : IStatelessCommand
    {
        protected CommandBase(GraphicsHost graphicsHost)
        {
            if (graphicsHost == null)
            {
                throw new ArgumentNullException("graphicsHost");
            }

            GraphicsHost = graphicsHost;
        }

        public abstract ExecutionContext Execute(ExecutionContext executionContext);

        public abstract void Undo(ExecutionContext executionContext);

        public abstract void Redo(ExecutionContext executionContext);

        protected GraphicsHost GraphicsHost { get; private set; }
    }
}
