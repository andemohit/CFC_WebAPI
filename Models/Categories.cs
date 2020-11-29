using System.ComponentModel.DataAnnotations;

namespace Categories.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(250)]
        public string categoryName { get; set; }

        public string categoryDesc { get; set; }

        public string imgLink { get; set; }

        public string location { get; set; }

        public string createdDate { get; set; }

        public string lastUpdatedDate { get; set; }
    }
}