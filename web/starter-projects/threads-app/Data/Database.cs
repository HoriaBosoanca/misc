using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using threads_app.Models;

namespace threads_app.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Models.Thread> ThreadTable { get; set; }
        public DbSet<Models.Comment> CommentTable { get; set; }
    }
}
