using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using threads_app.Data;
using threads_app.Models;

namespace threads_app.Repository
{
    public class ThreadRepository
    {
        private readonly Database database;
        public ThreadRepository(Database _database)
        {
            database = _database;

            // Temporary cleaner:
            // foreach (var thread in database.ThreadTable.ToList()){
            //     database.Remove(thread);
            // }
        }
        public async Task<List<Models.Thread>> GetAll(){
            return await database.ThreadTable.ToListAsync();
        }

        public async Task<Models.Thread?> GetById(int id){
            return await database.ThreadTable.FindAsync(id);
        }

        public async Task<Models.Thread> Create(ThreadNoId threadNoId){
            var thread = threadNoId.ToThread();
            await database.AddAsync(thread);
            await database.SaveChangesAsync();
            return thread;
        }
    }
}
