using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using threads_app.Data;
using Microsoft.EntityFrameworkCore;
using threads_app.Repository;

namespace threads_app
{
    public static class DependencyManager
    {
        public static void AddDependencies(WebApplicationBuilder builder){
            builder.Services.AddDbContext<Database>(dbcontextOptionsBuilder => {
                dbcontextOptionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ThreadRepository>();
        }
    }
}
