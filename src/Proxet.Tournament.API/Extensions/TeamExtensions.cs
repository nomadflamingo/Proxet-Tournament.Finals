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
            PlayerDto[] firstTeam = new PlayerDto[9];
            TeamsInfoDto teamsDto = new();

            for (int i = 0; i < firstTeam.Length; i++)
            {
                Player firstTeamPlayer = teams.FirstTeam[i];
                PlayerDto firstTeamPlayerDto = new()
                {
                    Name = firstTeamPlayer.Name,
                    VehicleType = firstTeamPlayer.VehicleType,
                };
                teamsDto.FirstTeam[i] = firstTeamPlayerDto;

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
