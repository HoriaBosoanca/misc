using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace threads_app.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Message { get; set; }
    }
}
