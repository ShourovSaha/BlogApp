using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Common;

namespace BlogApp.Data.Entity
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string UserName { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
