using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Models
{
    public class Match
    {
        public string Id { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}
