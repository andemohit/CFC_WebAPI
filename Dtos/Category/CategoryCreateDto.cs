using System;
using System.ComponentModel.DataAnnotations;

namespace Categories.Data
{
    public class CategoryCreateDto
    {
        [Required]
        public string categoryName { get; set; }

        public string categoryDesc { get; set; }

        public string imgLink { get; set; }

        public string location { get; set; }

        [Required]
        public string createdDate { get; set; }

        public string lastUpdatedDate { get; set; }
    }
}