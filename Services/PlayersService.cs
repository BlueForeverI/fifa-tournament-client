using FifaTournamentClient.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Services
{
    public class PlayersService
    {
        public async Task<List<Player>> GetPlayersAsync()
        {
            var req = new GraphQLRequest
            {
                Query = @"
                    query players {
                        id
                        firstName
                        lastName
                        score
                    }
                "
            };

            var graphQLClient = new GraphQLClient("https://fifa-tournament-graph-api.herokuapp.com/");
            var graphQLResponse = await graphQLClient.PostAsync(req);
            return graphQLResponse.GetDataFieldAs<List<Player>>("players");
        }
    }
}
