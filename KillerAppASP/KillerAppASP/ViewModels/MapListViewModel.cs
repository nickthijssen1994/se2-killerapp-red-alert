using KillerAppASP.Models;
using System.Collections.Generic;

namespace KillerAppASP.ViewModels
{
    public class MapListViewModel
    {
        public List<string> Maps { get; set; }
        public Map Map { get; set; }
        public string SearchTerm { get; set; }
    }
}
