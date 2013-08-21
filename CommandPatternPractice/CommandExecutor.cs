using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPatternPractice.Commands;

namespace CommandPatternPractice
{
    public class CommandExecutor
    {
        private readonly ExecutionHistory _executionHistory;

        private readonly CommandFactory _commandFactory;

        public CommandExecutor()
        {
            _executionHistory = new ExecutionHistory();
            _commandFactory = new CommandFactory();
        }

        public void CreateGraphic(string graphicName)
        {
            var createCommand = _commandFactory.GetCreateGraphicCommand(graphicName);
            createCommand.Execute();
            _executionHistory.Add(createCommand);
        }

        public void RemoveGraphic(string graphicName)
        {
            var removeCommand = _commandFactory.GetRemoveGraphicCommand(graphicName);
            removeCommand.Execute();
            _executionHistory.Add(removeCommand);
        }

        public void RotateGraphic(string graphicName, double angle)
        {
            var rotateCommand = _commandFactory.GetRotateGraphicCommand(graphicName, angle);
            rotateCommand.Execute();
            _executionHistory.Add(rotateCommand);
        }

        public void MoveGraphic(string graphicName, double offset)
        {
            var moveCommand = _commandFactory.GetMoveGraphicCommand(graphicName, offset);
            moveCommand.Execute();
            _executionHistory.Add(moveCommand);
        }

        public void ZoomInGraphic(string graphicName, double scale)
        {
            var zoomInCommand = _commandFactory.GetZoomInGraphicCommand(graphicName, scale);
            zoomInCommand.Execute();
            _executionHistory.Add(zoomInCommand);
        }

        public void Undo()
        {
            _executionHistory.Undo();
        }

        public void Redo()
        {
            _executionHistory.Redo();
        }
    }
}
