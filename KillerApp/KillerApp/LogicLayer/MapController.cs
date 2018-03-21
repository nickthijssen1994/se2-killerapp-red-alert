using KillerApp.DataLayer;
using KillerApp.DomeinClasses;
using System.Collections.Generic;

namespace KillerApp.LogicLayer
{
    public class MapController
    {
        IMapContext mapContext;
        MapRepository mapRepository;
        private static MapController instance;

        private MapController()
        {
            mapContext = new MapSQLContext();
            mapRepository = new MapRepository(mapContext);
        }

        public static MapController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapController();
                }
                return instance;
            }
        }

        public void GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            if (Name != null || Name != "")
            {
                mapRepository.GenerateMap(Name, Size, GroundType, MapType, HasLakes, HasRivers);
            }
        }

        public void SaveMap()
        {
            mapRepository.SaveMap();
        }

        public Map GetMap()
        {
            return mapRepository.Map;
        }

        public List<Map> GetMaps()
        {
            mapRepository.GetMaps();
            return mapRepository.Maps;
        }

        public void DeleteMap(string name)
        {
            mapRepository.DeleteMap(name);
        }
    }
}
