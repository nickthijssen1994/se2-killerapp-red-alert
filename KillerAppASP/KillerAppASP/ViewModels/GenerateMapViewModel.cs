using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
	public class GenerateMapViewModel
	{
		[Required(ErrorMessage = "{0} is required.")]
		[Display(Name = "Name")]
		[StringLength(20, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 6)]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
		[Display(Name = "Size")]
		[Range(200, 800, ErrorMessage = "{0} must be between {1} and {2}.")]
		public int Size { get; set; }

		[Display(Name = "Ground Type")] public string GroundType { get; set; }
		[Display(Name = "Map Type")] public string MapType { get; set; }
		[Display(Name = "Add Rivers")] public bool HasRivers { get; set; }
		[Display(Name = "Add Lakes")] public bool HasLakes { get; set; }

		[Display(Name = "Seed")]
		[Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
		public int Seed { get; set; }
	}
}