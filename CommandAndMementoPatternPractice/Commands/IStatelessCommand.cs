using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandAndMementoPatternPractice.ExecutionHistory;


namespace CommandAndMementoPatternPractice.Commands
{
    public interface IStatelessCommand
    {
        ExecutionContext Execute(ExecutionContext executionContext);

        void Undo(ExecutionContext executionContext);

        void Redo(ExecutionContext executionContext);
    }
}
