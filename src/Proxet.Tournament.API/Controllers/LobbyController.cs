using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxet.Tournament.API.Data;
using Proxet.Tournament.API.Dtos;
using Proxet.Tournament.API.Models;
using Proxet.Tournament.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Controllers
{
    [Route("api/v1/lobby")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyRepository _lobbyRepository;
        private readonly AppDbContext _db;

        public LobbyController(ILobbyRepository lobbyRepository, AppDbContext db)
        {
            _lobbyRepository = lobbyRepository;
            _db = db;
        }

        // api/v1/lobby
        [HttpPost]
        public async Task AddPlayerAsync(PlayerDto playerInfo)
        {
            Player player = new()
            {
                Name = playerInfo.Name,
                VehicleType = playerInfo.VehicleType
            };

            await _lobbyRepository.AddPlayerAsync(player);
            await _db.SaveChangesAsync();
        }
    }
}
