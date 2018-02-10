using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public  virtual ICollection<Post> Posts { get; set; }
    }
}
