using System.Collections.Generic;

namespace KillerApp.DataLayer
{
    public interface IMapContext
    {
        void AddMap(Map map);
        List<Map> GetMaps();
        Map GetMap(string mapname);
        void DeleteMap(string mapname);
    }
}
