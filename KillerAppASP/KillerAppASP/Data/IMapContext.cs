using System.Collections.Generic;
using KillerAppASP.Models;

namespace KillerAppASP.Data
{
    public interface IMapContext
    {
        void SaveMap(Map map);
        List<Map> GetMaps();
        Map GetMap(string mapname);
        void DeleteMap(string mapname);
    }
}
