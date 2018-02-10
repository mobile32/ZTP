using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
