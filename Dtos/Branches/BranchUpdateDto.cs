using System.ComponentModel.DataAnnotations;

namespace Branches.Dtos
{
    public class BranchUpdateDto
    {
        [Required]
        public string branchName { get; set; }

        [Required]
        public string branchManager { get; set; }

        [Required]
        public string branchNumber { get; set; }

        [Required]
        public string branchLocation { get; set; }
    }
}