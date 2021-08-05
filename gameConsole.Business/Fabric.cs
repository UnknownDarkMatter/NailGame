using gameConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameConsole.Business
{
    public class Fabric
    {

        public Game FabricGame(List<Argument> listArgument)
        {
            Game game = new Game();
            game.Gamers = listArgument.First(m => m.Name == "gamers").Values.Select(m => new Gamer() { Pseudo = m }).ToList();

            game.NailSize = listArgument.First(m => m.Name == "nail").GetValues<int>()[0];

            var timeValue = listArgument.FirstOrDefault(m => m.Name == "time");
            game.Time = new TimeSpan(0, 0, 0);
            if(timeValue != null)
            {
                game.Time = new TimeSpan(0, 0, timeValue.GetValues<int>()[0]);
            }

            return game;
        }
    }
}
