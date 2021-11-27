using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Dtos
{
    public class TeamsInfoDto
    {
        public PlayerDto[] FirstTeam { get; set; }
        public PlayerDto[] SecondTeam { get; set; }
    }
}
