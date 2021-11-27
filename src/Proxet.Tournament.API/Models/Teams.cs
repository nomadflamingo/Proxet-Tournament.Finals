using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Models
{
    public class Teams
    {
        public Player[] FirstTeam { get; set; }
        public Player[] SecondTeam { get; set; }
    }
}
