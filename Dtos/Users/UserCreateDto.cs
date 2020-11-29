using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string password { get; set; }

        public string email { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        [Required]
        public DateTime modifiedAt { get; set; }
    }
}