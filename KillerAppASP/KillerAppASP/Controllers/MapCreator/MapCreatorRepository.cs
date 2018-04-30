using System.Collections.Generic;
using KillerAppASP.Models;
using KillerAppASP.Data;

namespace KillerAppASP.Controllers
{
    public class MapCreatorRepository
    {
        public List<Map> Maps { get; set; }
        public Map Map { get; set; }

        private readonly IMapContext _mapcontext;

        public MapCreatorRepository(IMapContext mapcontext)
        {
            _mapcontext = mapcontext;
        }

        public void GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers, int Seed)
        {
            MapGenerator mapGenerator = new MapGenerator();
            Map = mapGenerator.GenerateMap(Name, Size, GroundType, MapType, HasLakes, HasRivers, Seed);
            _mapcontext.SaveMap(Map);
        }

        public void SaveMap()
        {
            _mapcontext.SaveMap(Map);
            Maps.Add(Map);
        }

        public void GetMaps()
        {
            Maps = _mapcontext.GetMaps();
        }

        public void GetMap(string name)
        {
            Map = _mapcontext.GetMap(name);
        }

        public void DeleteMap(string name)
        {
            _mapcontext.DeleteMap(name);
            Maps.RemoveAll(x => x.Name == name);
        }
    }
}
