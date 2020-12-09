using System.Collections.Generic;
using KillerAppASP.Models;

namespace KillerAppASP.Interfaces
{
	public interface IChatContext
	{
		void SendGlobalMessage(Message message);
		List<Message> GetGlobalMessages();
	}
}