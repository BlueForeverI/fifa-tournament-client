using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FifaTournamentClient.Models
{
    public class Player
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First Name is too long")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First Name is too long")]
        public string LastName { get; set; }
        public int Score { get; set; }

        [Required]
        public string TeamLogoUrl { get; set; }
    }
}
