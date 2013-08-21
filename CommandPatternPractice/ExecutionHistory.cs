using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

using CommandPatternPractice.Commands;

namespace CommandPatternPractice
{
    public class ExecutionHistory
    {
        private readonly List<ICommand> _executionList = new List<ICommand>();

        private int _currentIndex = -1;
 
        public void Add(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if ((_currentIndex != -1) && (_currentIndex != (_executionList.Count - 1)))
            {
                _executionList.RemoveRange(_currentIndex + 1, _executionList.Count - _currentIndex - 1);
            }

            _executionList.Add(command);
            _currentIndex++;
        }

        public void Undo()
        {
            if (_currentIndex == -1)
            {
                return;
            }

            _executionList[_currentIndex].Undo();
            _currentIndex--;
        }

        public void Redo()
        {
            if (_currentIndex == _executionList.Count - 1)
            {
                return;
            }

            var commandToRedo = _currentIndex + 1;
            _executionList[commandToRedo].Redo();
            _currentIndex++;
        }
    }
}
