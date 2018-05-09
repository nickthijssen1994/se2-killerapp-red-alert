﻿using KillerAppASP.Data;
using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.Controllers
{
    public class MapCreatorRepository
    {
        private IMapContext context;

        public MapCreatorRepository(IMapContext context)
        {
            this.context = context;
        }

        public List<string> Maps { get; set; }
        public Map Map { get; set; }

        public void GenerateMap(string Name, int Size, int Seed, int GroundType, int MapType, bool HasLakes, bool HasRivers, string Username)
        {
            MapGenerator mapGenerator = new MapGenerator();
            Map = mapGenerator.GenerateMap(Name, Size, Seed, GroundType, MapType, HasLakes, HasRivers, Username);
        }

        public int SaveMap(string username)
        {
            return context.SaveMap(Map, username);
        }

        public int DeleteMap(string name, string username)
        {
            return context.DeleteMap(name, username);
        }

        public void GetMap(string mapname, string username)
        {
            Map = context.GetMap(mapname, username);
        }

        public void GetAllMaps()
        {
            Maps = context.GetAllMaps();
            Maps.Sort();
        }

        public void GetUserMaps(string username)
        {
            Maps = context.GetUserMaps(username);
            Maps.Sort();
        }
    }
}
