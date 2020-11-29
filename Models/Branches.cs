using System.ComponentModel.DataAnnotations;

namespace Branches.Models
{
    public class Branch
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(250)]
        public string branchName { get; set; }

        [Required]
        public string branchManager { get; set; }

        [Required]
        public string branchNumber { get; set; }

        [Required]
        public string branchLocation { get; set; }
    }
}