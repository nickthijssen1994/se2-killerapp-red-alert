using KillerAppASP.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace KillerAppASP.ViewModels
{
    public class MapCreatorViewModel
    {
        public MapGenerateViewModel GenerateViewModel { get; set; }
        public MapListViewModel ListViewModel { get; set; }
    }

    public class MapGenerateViewModel
    {
        [Required]
        [Display(Name = "Map Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string MapName { get; set; }

        [Required]
        [Display(Name = "Map Size")]
        [Range(200, 800, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int MapSize { get; set; }

        [Display(Name = "Ground Type")]
        public string MapGroundType { get; set; }

        [Display(Name = "Map Type")]
        public string MapType { get; set; }

        [Display(Name = "Add Rivers")]
        public bool HasRivers { get; set; }

        [Display(Name = "Add Lakes")]
        public bool HasLakes { get; set; }

        [Display(Name = "Seed")]
        [Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        public int MapSeed { get; set; }
    }

    public class MapListViewModel
    {
        public string SearchTerm { get; set; }

        public List<Map> AllMaps { get; set; }

        public Map TempMap { get; set; }
    }
}
