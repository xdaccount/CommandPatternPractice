using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandPattern.Shared;

namespace CommandAndMementoPatternPractice.Commands
{
    public static class CommandFactory
    {
        public static Dictionary<Type, IStatelessCommand> Createommands()
        {
            var commands = new Dictionary<Type, IStatelessCommand>();
            var graphicHost = new GraphicsHost();

            IStatelessCommand command = new CreateGraphicCommand(graphicHost);
            commands.Add(command.GetType(), command);

            command = new RemoveGraphicCommand(graphicHost);
            commands.Add(command.GetType(), command);

            command = new MoveGraphicCommand(graphicHost);
            commands.Add(command.GetType(), command);

            command = new RotateGraphicCommand(graphicHost);
            commands.Add(command.GetType(), command);

            command = new ZoomInGraphicCommand(graphicHost);
            commands.Add(command.GetType(), command);

            return commands;
        }
    }
}
