using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BlogApp.Common;

namespace BlogApp.Data.Entity
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Text { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string UserName { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        
    }
}
