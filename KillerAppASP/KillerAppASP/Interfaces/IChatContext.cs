using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Interfaces
{
	public interface IChatContext
	{
		void SendGlobalMessage(Message message);
		List<Message> GetGlobalMessages();
	}
}