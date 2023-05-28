using System.ComponentModel.DataAnnotations;
using iXtensions.Extensions;

namespace iXtensions.DataAnnotationExtensions
{
    public class MultiContainsValidation : ValidationAttribute
    {
        public string[] Verify { get; set; }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return value.ToString().MultContains(Verify) ? true : false;
            }
            else
                return false;
        }
    }
}
