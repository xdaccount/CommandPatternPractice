using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandAndMementoPatternPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandExecutor = new CommandExecutor();

            commandExecutor.CreateGraphic("Graphic1");
            commandExecutor.CreateGraphic("Graphic2");
            commandExecutor.CreateGraphic("Graphic3");
            commandExecutor.CreateGraphic("Graphic4");

            commandExecutor.Undo();
            commandExecutor.Undo();

            commandExecutor.MoveGraphic("Graphic1", 20);
            commandExecutor.MoveGraphic("Graphic2", 15);

            commandExecutor.Undo();
            commandExecutor.Undo();

            commandExecutor.Redo();
            commandExecutor.Redo();

            commandExecutor.RotateGraphic("Graphic1", 10);
            commandExecutor.RotateGraphic("Graphic2", 5);

            commandExecutor.Undo();
            commandExecutor.Redo();

            commandExecutor.ZoomInGraphic("Graphic1", 0.5);
            commandExecutor.ZoomInGraphic("Graphic2", 2);

            commandExecutor.Undo();
            commandExecutor.Redo();

            commandExecutor.RemoveGraphic("Graphic1");
            commandExecutor.RemoveGraphic("Graphic2");

            commandExecutor.Undo();
            commandExecutor.Undo();
            commandExecutor.Redo();
            commandExecutor.Redo();

            Console.ReadLine();
        }
    }
}
