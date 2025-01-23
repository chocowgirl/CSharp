using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Demo_ASP1.Handlers
{
    public static class ValidationHandler
    {
        public static void Required(this ModelStateDictionary modelState, object? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                modelState.AddModelError(name, $"Le champ '{name} est requis.");
            }
        }

        public static void MinLength(this ModelStateDictionary modelState, string value, string name, int minChar = 1)
        {
            if(value is not null && value.Length < minChar)
            {
                modelState.AddModelError(name, $"Le champ '{name}' doit avoir au moins {minChar} charactères.");
            }
        }

        public static void MaxLength(this ModelStateDictionary modelState, string value, string name, int maxChar)
        {
            if (value is not null && value.Length > maxChar)
            {
                modelState.AddModelError(name, $"Le champ '{name}' doit avoir au max {maxChar} charactères.");
            }
        }


    }
}
