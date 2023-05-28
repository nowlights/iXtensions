using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace iXtensions.DataAnnotationExtensions
{
    public class PasswordValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is null) return false;
            var input = value.ToString();

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%&*()_.,-]");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:|./?,-]");

            if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "A senha deve conter um número";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "A senha deve conter uma letra maiscula";
                return false;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "A senha deve conter uma letra minuscula";
                return false;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "A senha deve conter caracteres especiais como (!@#$%&*()_.,-)";
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}