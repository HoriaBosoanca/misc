using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace threads_app.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string? Content { get; set; }
    }
}
