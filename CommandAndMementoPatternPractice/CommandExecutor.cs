using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using CommandAndMementoPatternPractice.Commands;
using CommandAndMementoPatternPractice.ExecutionHistory;

namespace CommandAndMementoPatternPractice
{
    public class CommandExecutor
    {
        private Dictionary<Type, IStatelessCommand> _commands;
        private readonly List<ExecutionContext> _executionContextList = new List<ExecutionContext>();
        private int _currentIndex = -1;

        public CommandExecutor()
        {
            _commands = CommandFactory.Createommands();
        }

        public void CreateGraphic(string graphicName)
        {
            var executionContext = new ExecutionContext(typeof(CreateGraphicCommand), graphicName, graphicName, null);
            ExecuteCommand(executionContext);
        }

        public void RemoveGraphic(string graphicName)
        {
            var executionContext = new ExecutionContext(typeof(RemoveGraphicCommand), graphicName, graphicName, null);
            ExecuteCommand(executionContext);
        }

        public void RotateGraphic(string graphicName, double angle)
        {
            var executionContext = new ExecutionContext(typeof(RotateGraphicCommand), graphicName, angle, null);
            ExecuteCommand(executionContext);
        }

        public void MoveGraphic(string graphicName, double offset)
        {
            var executionContext = new ExecutionContext(typeof(MoveGraphicCommand), graphicName, offset, null);
            ExecuteCommand(executionContext);
        }

        public void ZoomInGraphic(string graphicName, double scale)
        {
            var executionContext = new ExecutionContext(typeof(ZoomInGraphicCommand), graphicName, scale, null);
            ExecuteCommand(executionContext);
        }

        public void Undo()
        {
            if (_currentIndex == -1)
            {
                return;
            }

            var undoContext = _executionContextList[_currentIndex];
            var command = GetCommand(undoContext.CommandType);
            command.Undo(undoContext);
            _currentIndex--;
        }

        public void Redo()
        {
            if (_currentIndex == _executionContextList.Count - 1)
            {
                return;
            }

            var redoContext = _executionContextList[_currentIndex + 1];
            var command = GetCommand(redoContext.CommandType);
            command.Redo(redoContext);
            _currentIndex++;
        }

        private void ExecuteCommand(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            var createCommand = GetCommand(executionContext.CommandType);
            var newContext = createCommand.Execute(executionContext);

            AddToExecutionContextList(newContext);            
        }

        private IStatelessCommand GetCommand(Type commadType)
        {
            if (!_commands.ContainsKey(commadType))
            {
                throw new ArgumentException("Can't find specified command.");
            }

            return _commands[commadType];
        }

        private void AddToExecutionContextList(ExecutionContext executionContext)
        {
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }

            if ((_currentIndex != -1) && (_currentIndex != (_executionContextList.Count - 1)))
            {
                _executionContextList.RemoveRange(_currentIndex + 1, _executionContextList.Count - _currentIndex - 1);
            }

            _executionContextList.Add(executionContext);
            _currentIndex++;            
        }
    }
}
