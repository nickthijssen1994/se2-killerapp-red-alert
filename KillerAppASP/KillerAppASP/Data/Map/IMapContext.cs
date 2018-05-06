using System.Collections.Generic;
using KillerAppASP.Models;

namespace KillerAppASP.Data
{
    public interface IMapContext
    {
        int SaveMap(Map map, string username);
        int DeleteMap(string mapname, string username);
        List<string> GetAllMaps();
        List<string> GetUserMaps(string username);
    }
}
