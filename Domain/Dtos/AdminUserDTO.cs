using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class AdminUserDTO
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
