using System.Collections.Generic;
using KillerApp.DataLayer;

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

        public void AddMap(Map map)
        {
            _mapcontext.AddMap(map);
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
        }

    }
}
