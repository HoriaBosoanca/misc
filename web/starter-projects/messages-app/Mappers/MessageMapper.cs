using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.DTO;

namespace api.Mappers
{
    public static class MessageMapper
    {
        public static Message MessageCreateToMessage(this MesasgeCreate mesasgeCreate){
            return new Message() {
                Text = mesasgeCreate.Text
            };
        }
    }
}
