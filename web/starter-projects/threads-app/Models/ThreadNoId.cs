using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace threads_app.Models
{
    public class ThreadNoId
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Message { get; set; }

        public Models.Thread ToThread(){
            return new Models.Thread(){
                Title = Title,
                Author = Author,
                Message = Message
            };
        }
    }
}
