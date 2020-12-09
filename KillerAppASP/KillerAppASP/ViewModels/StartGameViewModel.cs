using KillerAppASP.Models;
using System.ComponentModel.DataAnnotations;

namespace KillerAppASP.ViewModels
{
	public class StartGameViewModel
	{
		public MapListViewModel MapList { get; set; }
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
		[Display(Name = "Starting Resources")]
		[Range(5000, 50000, ErrorMessage = "{0} must be between {1} and {2}.")]
		public int StartingResources { get; set; }

		[Required(ErrorMessage = "Select a Map")]
		public string SelectedMap { get; set; }
	}
}