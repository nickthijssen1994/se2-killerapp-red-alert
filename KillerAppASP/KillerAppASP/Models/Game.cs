using System;

namespace KillerAppASP.Models
{
    public class Game
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Map Map { get; set; }
        public int StartingResources { get; set; }
        public DateTime CreationDate { get; set; }
    }
}