using System;

namespace Users.Dtos
{
    public class UserReadDto
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
    }
}