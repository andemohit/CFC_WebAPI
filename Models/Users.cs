using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        public string firstName { get; set; }
        
        public string lastName { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string password { get; set; }
        
        public string email { get; set; }

        [Required]
        public string role { get; set; }
        
        public DateTime createdAt { get; set; }
        
        public DateTime modifiedAt { get; set; }
    }
}