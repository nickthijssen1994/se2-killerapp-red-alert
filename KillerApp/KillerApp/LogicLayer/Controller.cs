using KillerApp.DataLayer;
using KillerApp.DomeinClasses;

namespace KillerApp.LogicLayer
{
    public class Controller
    {
        IMapContext mapContext;
        MapRepository mapRepository;
        private Map temporaryMap;
        public Map TemporaryMap { get => temporaryMap; set => temporaryMap = value; }

        private static Controller instance;

        private Controller()
        {
            mapContext = new MapSQLContext();
            mapRepository = new MapRepository(mapContext);
        }

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        public void GenerateMap(string Name, int Size, int GroundType, int MapType, bool HasLakes, bool HasRivers)
        {
            MapGenerator mapGenerator = new MapGenerator();
            TemporaryMap = mapGenerator.GenerateMap(Name, Size, GroundType, MapType, HasLakes, HasRivers);
        }
    }
}
