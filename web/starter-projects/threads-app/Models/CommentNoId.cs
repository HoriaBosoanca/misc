using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace threads_app.Models
{
    public class CommentNoId
    {
        public string? Content { get; set; }

        public Comment ToComment(){
            return new Comment { 
                Content = Content
            };
        }
    }
}
