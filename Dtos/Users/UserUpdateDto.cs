using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Data
{
    public class UserUpdateDto
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public DateTime modifiedAt { get; set; }
    }
}