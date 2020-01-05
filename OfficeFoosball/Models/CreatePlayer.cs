using System.ComponentModel.DataAnnotations;

namespace OfficeFoosball.Models
{
    public class CreatePlayer
    {
        [Required]
        public string Name { get; set; }
    }
}
