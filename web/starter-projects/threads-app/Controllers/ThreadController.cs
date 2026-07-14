using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using threads_app.Data;
using threads_app.Models;
using threads_app.Repository;

namespace threads_app.Controllers
{
    [Route("/thread")]
    [ApiController]
    public class ThreadController: ControllerBase
    {
        private readonly ThreadRepository repo;
        public ThreadController(ThreadRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var thread = await repo.GetById(id);
            if (thread == null){
                return NotFound();
            }
            return Ok(thread);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ThreadNoId threadNoId)
        {
            var thread = await repo.Create(threadNoId);
            return CreatedAtAction(nameof(GetById), new { id = thread.Id}, thread);
        }
    }
}
