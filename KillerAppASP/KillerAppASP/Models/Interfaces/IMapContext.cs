using System.Collections.Generic;

namespace KillerAppASP.Models
{
    public interface IMapContext
    {
        int SaveMap(Map Map, string Username);
        int DeleteMap(string Mapname, string Username);
        Map GetMap(string Mapname, string Username);
        List<string> GetAllMaps();
        List<string> GetUserMaps(string Username);
    }
}
