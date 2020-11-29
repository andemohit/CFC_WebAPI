using System.ComponentModel.DataAnnotations;

namespace Categories.Data
{
    public class CategoryUpdateDto
    {
        [Required]
        public string categoryName { get; set; }

        public string categoryDesc { get; set; }

        public string imgLink { get; set; }

        public string location { get; set; }

        [Required]
        public string lastUpdatedDate { get; set; }
    }
}