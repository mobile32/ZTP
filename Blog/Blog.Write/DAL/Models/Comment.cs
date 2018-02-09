using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Write.DAL.Models
{
    class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Author { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
