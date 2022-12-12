using System.ComponentModel.DataAnnotations;

namespace teste_finanblue.Models
{
    public class Product
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public float? price { get; set; }
    }
}
