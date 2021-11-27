using Proxet.Tournament.API.Dtos;
using Proxet.Tournament.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Extensions
{
    public static class TeamExtensions
    {
        public static TeamsInfoDto AsDto(this Teams teams)
        {
            TeamsInfoDto teamsDto = new();
            teamsDto.FirstTeam = new PlayerDto[9];
            teamsDto.SecondTeam = new PlayerDto[9];

            for (int i = 0; i < teamsDto.FirstTeam.Length; i++)
            {
                Player firstTeamPlayer = teams.FirstTeam[i];
                PlayerDto firstTeamPlayerDto = new()
                {
                    Name = firstTeamPlayer.Name,
                    VehicleType = firstTeamPlayer.VehicleType,
                };
                teamsDto.FirstTeam[i] = firstTeamPlayerDto;
            }

            for (int i = 0; i < teamsDto.SecondTeam.Length; i++)
            {
                Player secondTeamPlayer = teams.SecondTeam[i];
                PlayerDto secondTeamPlayerDto = new()
                {
                    Name = secondTeamPlayer.Name,
                    VehicleType = secondTeamPlayer.VehicleType,
                };
                teamsDto.SecondTeam[i] = secondTeamPlayerDto;
            }
            

            return teamsDto;
        }
    }
}
