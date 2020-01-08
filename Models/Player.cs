using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}
