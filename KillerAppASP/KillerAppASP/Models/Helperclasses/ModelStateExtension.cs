using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KillerAppASP.Models
{
    public static class ModelStateExtension
    {
        public static string ErrorsToHTML(this ModelStateDictionary modelState)
        {
            string errors = "";
            if (!modelState.IsValid)
            {
                foreach (var key in modelState)
                {
                    foreach (var item in key.Value.Errors)
                    {
                        string error = item.ErrorMessage.ToString();
                        errors += "<p>" + error + "</p>";
                    }
                }
            }
            return errors;
        }
    }
}
