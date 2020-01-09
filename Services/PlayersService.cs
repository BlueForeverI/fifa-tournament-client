using FifaTournamentClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FifaTournamentClient.Services
{
    public class PlayersService
    {
        private GraphHelper graphHelper;

        public PlayersService(GraphHelper graphHelper)
        {
            this.graphHelper = graphHelper;
        }

        public Task<List<Player>> GetPlayersAsync()
        {
            var query = @"
                players {
                    id
                    firstName
                    lastName
                    score
                }
            ";
            return graphHelper.GetObject<List<Player>>(query, "players");
        }
    }
}
