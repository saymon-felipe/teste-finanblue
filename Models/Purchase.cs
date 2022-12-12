using System.ComponentModel.DataAnnotations;

namespace teste_finanblue.Models
{
    public class Purchase
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int clientId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public int companyId { get; set; }
    }
}
