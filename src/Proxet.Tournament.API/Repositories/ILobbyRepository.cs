using Proxet.Tournament.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxet.Tournament.API.Repositories
{
    public interface ILobbyRepository
    {
        Task<Player> GetPlayerAsync(Guid id);
        IEnumerable<Player> GetSortedPlayers();
        Task AddPlayerAsync(Player player);
        void DeletePlayer(Player player);
    }
}