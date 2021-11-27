using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxet.Tournament.API.Data;
using Proxet.Tournament.API.Dtos;
using Proxet.Tournament.API.Extensions;
using Proxet.Tournament.API.Models;
using Proxet.Tournament.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Controllers
{
    [Route("api/v1/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly ILobbyRepository _lobbyRepository;
        private readonly AppDbContext _db;


        public TeamsController(ILobbyRepository lobbyRepository, AppDbContext db)
        {
            _lobbyRepository = lobbyRepository;
            _db = db;
        }

       // api/v1/teams/generate
       [HttpGet("generate")]
        public TeamsInfoDto GenerateTeams()
        {
            Teams teams = new() 
            { 
                FirstTeam = new Player[9], 
                SecondTeam = new Player[9] 
            };

            Player[] eligiblePlayers = new Player[18];
            int[] countersForEachVehicleType = new int[3];

            IEnumerable<Player> sortedPlayers =  _lobbyRepository.GetSortedPlayers();

            // Add players to eligible players array
            foreach (Player player in sortedPlayers)
            {
                int vehicleType = player.VehicleType;
                int count = countersForEachVehicleType[vehicleType - 1]++;
                if (count < 6)
                {
                    // players with vehicle type n will get slots {0(n-1), 1(n-1), ... , 5(n-1)} in eligiblePlayers array
                    eligiblePlayers[(vehicleType - 1) * 6 + count] = player;
                }
            }

            // Delete players from lobby
            foreach (Player player in eligiblePlayers)
            {
                _lobbyRepository.DeletePlayer(player);
            }

            // Add players to their teams
            for (int i = 0; i < eligiblePlayers.Length; i++)
            {
                Player player = eligiblePlayers[i];
                // for team1 pick 3 first players for each vehicle type i.e. 0, 1, 2, 6, 7, 8, 12, 13, 14
                // for team2 pick the rest of the players
                if ((i / 3) % 2 == 0)
                {
                    // convert indexes of picked players and add them to the team
                    teams.FirstTeam[i - 3 * (i / 6)] = player;
                }
                else
                {
                    teams.SecondTeam[i - 3 * (i / 6) - 3] = player;
                }
            }

            return teams.AsDto();


        }
    }
}
