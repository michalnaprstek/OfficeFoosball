﻿namespace OfficeFoosball.Models
{
    public class Player
    {
        public Player()
        {
                
        }

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
