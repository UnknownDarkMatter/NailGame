using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameConsole.Entities
{
    public class Game
    {
        public List<Gamer> Gamers { get; set; }
        public int NailSize { get; set; }
        
        public TimeSpan Time { get; set; }
    }
}
