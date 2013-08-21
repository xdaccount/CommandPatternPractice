using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.ExecutionHistory
{
    public class ExecutionContext
    {
        public ExecutionContext(Type commandType, string graphicName, object contextBeforeExecution, object contextAfterExecution)
        {
            if (commandType == null)
            {
                throw new ArgumentNullException("commandType");
            }

            if (graphicName == null)
            {
                throw new ArgumentNullException("graphicName");
            }

            if (contextBeforeExecution == null)
            {
                throw new ArgumentNullException("contextBeforeExecution");
            }

            CommandType = commandType;
            GraphicName = graphicName;
            ContextBeforeExecution = contextBeforeExecution;
            ContextAfterExecution = contextAfterExecution;
        }

        public Type CommandType { get; private set; }

        public string GraphicName { get; private set; }

        public object ContextBeforeExecution { get; private set; }

        public object ContextAfterExecution { get; private set; }
    }
}
