using gameConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameConsole.Business
{
    public class GameRunner
    {


        public List<string> Run(Game game)
        {
            var sizeOfNail = game.NailSize;
            var winers = new List<string>();
            var gamersList = game.Gamers;
            while (sizeOfNail > 1)
            {
                foreach (var gamer in gamersList)
                {
                    Console.WriteLine($"Joueur {gamer.Pseudo}, veuillez entrer une force pour planter le clou");

                    var forceAsString = Console.ReadLine();
                    // var force = Convert.ToInt32(forceAsString);
                    if (int.TryParse(forceAsString, out int force))
                    {
                        sizeOfNail -= force;
                        switch (sizeOfNail)
                        {
                            case 1:
                                {
                                    winers.Add(gamer.Pseudo);
                                    break;
                                }
                            case 0:
                                {
                                    winers = gamersList.Select(m => m.Pseudo).Where(s => s != gamer.Pseudo).ToList();
                                    break;
                                }
                        }

                    }
                }
            }
            return winers;
        }
    }
}
