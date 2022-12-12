using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste_finanblue.Models
{
    public class User
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }

        [Required]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }
    }
}
