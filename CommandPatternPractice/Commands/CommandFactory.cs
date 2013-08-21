using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public class CommandFactory
    {
        private GraphicsHost _graphicsHost;

        public CommandFactory()
        {
            _graphicsHost = new GraphicsHost();
        }

        public ICommand GetCreateGraphicCommand(string graphicName)
        {
            var createCommand = new CreateGraphicCommand(graphicName, _graphicsHost);

            return createCommand;
        }

        public ICommand GetRemoveGraphicCommand(string graphicName)
        {
            var removeCommand = new RemoveGraphicCommand(graphicName, _graphicsHost);

            return removeCommand;
        }

        public ICommand GetMoveGraphicCommand(string graphicName, double offset)
        {
            var moveCommand = new MoveGraphicCommand(graphicName, offset, _graphicsHost);

            return moveCommand;
        }

        public ICommand GetRotateGraphicCommand(string graphicName, double angle)
        {
            var rotateCommand = new RotateGraphicCommand(graphicName, angle, _graphicsHost);

            return rotateCommand;
        }

        public ICommand GetZoomInGraphicCommand(string graphicName, double scale)
        {
            var zoomInCommand = new ZoomInGraphicCommand(graphicName, scale, _graphicsHost);

            return zoomInCommand;
        }
    }
}
