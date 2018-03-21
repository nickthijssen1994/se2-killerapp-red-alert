using System.Collections.Generic;
using KillerApp.DomeinClasses;

namespace KillerApp.DataLayer
{
    public interface IMapContext
    {
        void SaveMap(Map map);
        List<Map> GetMaps();
        Map GetMap(string mapname);
        void DeleteMap(string mapname);
    }
}
