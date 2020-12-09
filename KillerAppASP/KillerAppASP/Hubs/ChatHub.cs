using System;
using System.Threading.Tasks;
using KillerAppASP.Datalayer;
using KillerAppASP.Helperclasses;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace KillerAppASP.Hubs
{
	public class ChatHub : Hub
	{
		private readonly ChatRepository chatRepository;

		public ChatHub()
		{
			IChatContext context = new ChatMSSQLContext();
			chatRepository = new ChatRepository(context);
		}

		public async Task SendMessage(string user, string text)
		{
			var timestamp = DateTimeExtensions.HowLongAgo(DateTime.Now);
			await Clients.All.SendAsync("ReceiveMessage", user, text, timestamp);

			var message = new Message
			{
				SendBy = user,
				Text = text,
				TimeStamp = DateTime.Now
			};

			chatRepository.SendGlobalMessage(message);
		}
	}
}