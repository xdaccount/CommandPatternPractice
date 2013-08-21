using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandPatternPractice.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected CommandBase(string graphicName, GraphicsHost graphicsHost)
        {
            if (string.IsNullOrEmpty(graphicName))
            {
                throw new ArgumentException("Graphic name can't be null or empty.", "graphicName");
            }

            if (graphicsHost == null)
            {
                throw new ArgumentNullException("graphicsHost");
            }

            GraphicsHost = graphicsHost;
            GraphicName = graphicName;
        }

        public abstract void Execute();

        public abstract void Undo();

        public abstract void Redo();

        protected GraphicsHost GraphicsHost { get; private set; }

        protected string GraphicName { get; private set; }
    }
}
