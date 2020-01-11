using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Models
{
    public class CreateMatchModel
    {
        [Required]
        public string Player1Id { get; set; }
        [Required]
        public string Player2Id { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Invalid score (0-100)")]
        public int Score1 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Invalid score (0-100)")]
        public int Score2 { get; set; }
    }
}
