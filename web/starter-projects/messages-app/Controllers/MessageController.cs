using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.DTO;
using api.Mappers;

namespace api.Controllers
{   
    [Route("messages_api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly Database context;
        public MessageController(Database _context)
        {
            context = _context;

            const int maxMessageAmount = 100;
            RemoveLast(maxMessageAmount);
        }

        void RemoveLast(int maxMessageAmount){
            var MessageList = context.MessageTable.ToList();
            if(MessageList.Count > maxMessageAmount){
                for(int i = 0; i < MessageList.Count - maxMessageAmount; i++){
                    context.MessageTable.Remove(MessageList[i]);
                    context.SaveChanges();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var data = await context.MessageTable.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var data = await context.MessageTable.FindAsync(id);
            if(data==null){
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MesasgeCreate messageCreate){
            var message = messageCreate.MessageCreateToMessage();
            await context.MessageTable.AddAsync(message);   
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }
    }
}
