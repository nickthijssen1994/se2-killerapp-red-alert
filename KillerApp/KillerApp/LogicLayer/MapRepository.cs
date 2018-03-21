using System.Collections.Generic;
using KillerApp.DataLayer;
using KillerApp.DomeinClasses;

namespace KillerApp.LogicLayer
{
    public class MapRepository
    {
        private List<Map> maps = new List<Map>();
        private Map map;
       
        public List<Map> Maps { get => maps; set => maps = value; }
        public Map Map { get => map; set => map = value; }

        private readonly IMapContext _mapcontext;

        public MapRepository(IMapContext mapcontext)
        {
            _mapcontext = mapcontext;
        }

        public void GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            MapGenerator mapGenerator = new MapGenerator();
            Map = mapGenerator.GenerateMap(Name, Size, GroundType, MapType, HasLakes, HasRivers);
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
