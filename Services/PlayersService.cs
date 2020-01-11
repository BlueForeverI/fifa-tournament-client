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
                    teamLogoUrl
                }
            ";
            return graphHelper.GetObject<List<Player>>(query, "players");
        }

        public Task<Player> CreatePlayer(Player player)
        {
            var query = @"
                mutation {{
                    createPlayer(data: {{
                        firstName: \""{0}\"",
                        lastName: \""{1}\"",
                        teamLogoUrl: \""{2}\"",
                        score: {3}
                    }}) {{ 
                        id 
                    }}
                }}
            ";
            var withParams = string.Format(
                query, player.FirstName, player.LastName, player.TeamLogoUrl, player.Score);

            return graphHelper.ExecuteMutation<Player>(withParams, "createPlayer");
        }

        public Task<Player> DeletePlayer(string playerId)
        {
            var query = @"
                mutation {{
                    deletePlayer(id: \""{0}\"") {{
                        id 
                    }}
                }}
            ";
            var withParams = string.Format(query, playerId);

            return graphHelper.ExecuteMutation<Player>(withParams, "deletePlayer");
        }
    }
}
