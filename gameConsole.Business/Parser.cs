using gameConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gameConsole.Business
{
    public class Parser
    {

        public List<Argument> GetArguments(string commandeLine, out bool isError, out string errorMessage)
        {
            // CommandLine game.exe -gamers gamer1 gamer2 -nail 20 -time 30
            List<Argument> ArgumentList = new List<Argument>();
            isError = false;
            errorMessage = "Invalid command! see --help";

            var listGamer = GetArgumentFromCommandLine(commandeLine, "gamers");
            if( listGamer.Count < 2)
            {
                isError = true;
                errorMessage = "Invalid command! gamer's names are required !";
                return null;
            }
            var nailList = GetArgumentFromCommandLine(commandeLine, "nail");
            if (nailList.Count != 1 || !int.TryParse(nailList[0], out int nailSize))
            {
                isError = true;
                errorMessage = "Invalid command! one and only one numeric is required!";
                return null;
            }
            var timeList = GetArgumentFromCommandLine(commandeLine, "time");
            if (timeList.Count > 1 || (timeList.Count == 1 && !int.TryParse(timeList[0], out int timeSeconds)))
            {
                isError = true;
                errorMessage = "Invalid command! one and only one numeric is required!";
                return null;
            }

            Argument argument1 = new Argument("gamers", listGamer);
            ArgumentList.Add(argument1);
            Argument argument2 = new Argument("nail", nailList);
            ArgumentList.Add(argument2);
            if (timeList.Count == 1)
            {
                Argument argument3 = new Argument("time", timeList);
                ArgumentList.Add(argument3);
            }

            //int nailSizeTmp = argument2.GetValues<int>()[0];

            return ArgumentList;
        }

        public string GetHelp()
        {
            string message = $"Usage : GameConsole.exe [OpTIONS] {Environment.NewLine}";
            message += $"OPTIONS : {Environment.NewLine}";
            message += $"-gamers gamer1 gamer2{Environment.NewLine}";
            message += $"-nail 20 (compulsory) nail's size{Environment.NewLine}";
            message += $"-time 30 (optional) maximum game duration";
            return message;
        }

        private List<string> GetArgumentFromCommandLine(string commandeLine, string argumentName)
        {
            var regex = new Regex($"\\-{argumentName}([^\\-]+)");
            var match = regex.Match(commandeLine);
            if (!match.Success)
            {
                return new List<string>();
            }
           
            var res = match.Groups[1].Value.Split(' ').Select(m => m.Trim()).Where(m => m != "").ToList();


            return res;
        }

    }
}
