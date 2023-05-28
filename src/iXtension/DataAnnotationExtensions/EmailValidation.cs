using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace iXtensions.DataAnnotationExtensions
{
    public class EmailValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {	
                MailAddress  m = new MailAddress(value.ToString());
                return true;
            }
            catch(System.Exception) { return false;}
        }
    }
}