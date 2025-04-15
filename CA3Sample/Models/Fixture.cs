using System;
using System.ComponentModel.DataAnnotations;

namespace CA3Sample.Models
{ 
    public class Fixture
    {
        public int MatchId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Venue")]
        public string Venue { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Opponent Team")]
        public string OpponentTeam { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime DateTime { get; set; }

        [Range(0, 100)]
        [Display(Name = "Goals For")]
        public int? GoalsFor { get; set; }

        [Range(0, 100)]
        [Display(Name = "Goals Against")]
        public int? GoalsAgainst { get; set; }
    }

}
