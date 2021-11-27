using Proxet.Tournament.API.Data;
using Proxet.Tournament.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Repositories
{
    public class MSSQLLobbyRepository : ILobbyRepository
    {
        private readonly AppDbContext _db;

        public MSSQLLobbyRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            return await _db.Lobby.FindAsync(id);
        } 

        public async Task AddPlayerAsync(Player player)
        {
            await _db.Lobby.AddAsync(player);
        }

        public IEnumerable<Player> GetSortedPlayers()
        {
            return _db.Lobby.OrderBy(player => player.Id).ToList();
        }

        public void DeletePlayer(Player player)
        {
            _db.Lobby.Remove(player);
        }
    }
}
