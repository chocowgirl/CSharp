using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace MiniExoASP17Jan2025.Handlers
{
    public static class ValidationHandler
    {
        public static void RequiredAge(this ModelStateDictionary modelState, DateOnly birthdate, string Birthday, int age = 18)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (birthdate > today.AddYears(-age))
            {
                modelState.AddModelError(Birthday, $"You are not 18 years old yet.");
            }
        }

        public static void RequiredUpperCase(this ModelStateDictionary modelState, string value, string Password)
        {
            if(value is not null && !Regex.IsMatch(value, "[A-Z]"))
            {
                modelState.AddModelError(Password, "The password must have at least one capital letter");
            }
        }

        public static void RequiredLowerCase(this ModelStateDictionary modelState, string value, string Password)
        {
            if (value is not null && !Regex.IsMatch(value, "[a-z]"))
            {
                modelState.AddModelError(Password, "The password must have at least one lowercase letter");
            }
        }

        public static void RequiredNumber(this ModelStateDictionary modelState, string value, string Password)
        {
            if (value is not null && !Regex.IsMatch(value, "[0-9]"))
            {
                modelState.AddModelError(Password, "The password must have at least one number");
            }
        }

        public static void RequiredSymbol(this ModelStateDictionary modelState, string value, string Password)
        {
            if (value is not null && !Regex.IsMatch(value, "[*/^[@-_$\\]|\\-#§%+]"))
            {
                modelState.AddModelError(Password, "The password must have at least one symbol");
            }
        }



        //private static void RegexpValidation(this ModelStateDictionary modelState, string value, string name, string pattern, string errorMessage)
        //{
        //    if (value is not null && !Regex.IsMatch(value, pattern))
        //    {
        //        modelState.AddModelError(name, errorMessage);
        //    }
        //}

    }
}
