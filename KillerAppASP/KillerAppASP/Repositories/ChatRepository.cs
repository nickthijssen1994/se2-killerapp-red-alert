using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Repositories
{
    public class ChatRepository
    {
        private IChatContext context;

        public ChatRepository(IChatContext context)
        {
            this.context = context;
        }

        public void SendGlobalMessage(Message message)
        {
            context.SendGlobalMessage(message);
        }

        public List<Message> GetGlobalMessages()
        {
            return context.GetGlobalMessages();
        }
    }
}