using System;

namespace KillerAppASP.Helperclasses
{
    public static class DateTimeExtensions
    {
        //datetime naar string met bijv. '1 day ago' of '30 minutes ago'
        public static string HowLongAgo(DateTime timeStamp)
        {
            string howLongAgo = "";
            DateTime now = DateTime.Now;
            TimeSpan difference = now.Subtract(timeStamp);
            if (difference.Days >= 1)
            {
                howLongAgo = (int)difference.TotalDays + " days ago";
            }
            else if (difference.Hours >= 1)
            {
                howLongAgo = (int)difference.TotalHours + " hours ago";
            }
            else if (difference.Minutes >= 1)
            {
                howLongAgo = (int)difference.TotalMinutes + " minutes ago";
            }
            else
            {
                howLongAgo = (int)difference.TotalSeconds + " seconds ago";
            }
            return howLongAgo;
        }
    }
}