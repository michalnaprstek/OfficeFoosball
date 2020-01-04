using System.ComponentModel.DataAnnotations;

namespace OfficeFoosball.Models
{
    public class CreateTeam
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Player1Id { get; set; }
        [Required]
        public int? Player2Id { get; set; }
    }
}
