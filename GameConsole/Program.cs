using gameConsole.Business;
using gameConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringCommandLine = string.Join(" ", args);
            Parser parser = new Parser();

            if (args.Contains("--help"))
            {
                var help = parser.GetHelp();

                Console.WriteLine(help);
                Console.ReadLine();
                return;
            }
            var argumentsList = parser.GetArguments(stringCommandLine, out bool isError, out string errorMessage);
            if (isError)
            {
                Console.WriteLine(errorMessage);
                Console.ReadLine();
                return;
            }

            var fabrique = new Fabric();
            var game = fabrique.FabricGame(argumentsList);
            var gameRunner = new GameRunner();
            var winers = gameRunner.Run(game);
           
            Console.WriteLine($" Bravo {winers[0]} !!");
            Console.WriteLine("Appuyez sur une touche pour fermer le programme");
            Console.ReadLine();
        }
    }
}
