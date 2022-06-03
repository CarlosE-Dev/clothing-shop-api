using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class UserDTO
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
