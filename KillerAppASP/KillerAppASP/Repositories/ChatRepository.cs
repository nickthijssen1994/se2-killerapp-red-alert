using System.Collections.Generic;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;

namespace KillerAppASP.Repositories
{
	public class ChatRepository
	{
		private readonly IChatContext context;

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