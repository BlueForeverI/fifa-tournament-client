using FifaTournamentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Services
{
    public class MatchesService
    {
        private GraphHelper graphHelper;

        public MatchesService(GraphHelper graphHelper)
        {
            this.graphHelper = graphHelper;
        }

        public Task<List<Match>> GetMatchesAsync()
        {
            var query = @"
                matches {
                    id
                    score1
                    score2
                    player1 {
                        id
                        firstName
                        lastName
                        score
                        teamLogoUrl
                    }
                    player2 {
                        id
                        firstName
                        lastName
                        score
                        teamLogoUrl
                    }
                }
            ";

            return graphHelper.GetObject<List<Match>>(query, "matches");
        }

        public Task<Match> CreateMatch(CreateMatchModel match)
        {
            var query = @"
                mutation {{
                    createMatch(data: {{
                        player1Id: \""{0}\"",
                        player2Id: \""{1}\"",
                        score1: {2},
                        score2: {3}
                    }}) {{ 
                        id 
                    }}
                }}
            ";
            var withParams = string.Format(
                query, match.Player1Id, match.Player2Id, match.Score1, match.Score2);
            return graphHelper.ExecuteMutation<Match>(withParams, "createMatch");
        }
    }
}
