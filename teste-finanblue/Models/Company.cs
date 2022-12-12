using System.ComponentModel.DataAnnotations;

namespace teste_finanblue.Models
{
    public class Company
    {
        public void setCompanyCreator(int id)
        {
            creatorId = id;
        }

        public int id { get; set; }

        [Required]
        public string? name { get; set; }
        public DateTime createDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int creatorId { get; private set; }
    }
}
