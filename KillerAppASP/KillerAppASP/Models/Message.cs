using System;

namespace KillerAppASP.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string SendBy { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
