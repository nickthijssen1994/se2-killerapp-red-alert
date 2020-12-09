using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KillerAppASP.Helperclasses
{
	public static class ModelStateExtension
	{
		public static string ErrorsToHTML(this ModelStateDictionary modelState)
		{
			var errors = "";
			if (!modelState.IsValid)
				foreach (var key in modelState)
				{
					foreach (var item in key.Value.Errors)
					{
						var error = item.ErrorMessage.ToString();
						errors += "<p>" + error + "</p>";
					}
				}

			return errors;
		}
	}
}