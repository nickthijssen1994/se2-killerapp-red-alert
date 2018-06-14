using System.Collections.Generic;

namespace KillerAppASP.ViewModels
{
    public class ChatViewModel
    {
        public List<string> SendMessages { get; set; }
        public string MessageToSend { get; set; }
    }
}