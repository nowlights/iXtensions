using System;
using System.ComponentModel.DataAnnotations;

namespace iXtensions.DataAnnotationExtensions
{
    public class SecurityTagHtml : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var v = value.ToString();
                int r = 0;
                string[] charac = new string[] { "<", ">", "javascript" };
                foreach (var item in charac)
                    if (v.Contains(item)) r++;
                if (r == 0) return true; else { ErrorMessage = "Caracteres não permitidos"; return false; }
            }
            else return true;
        }
    }
}