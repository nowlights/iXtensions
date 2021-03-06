using System.ComponentModel.DataAnnotations;

namespace iXtensions.DataAnnotationExtensions
{
    public class NotValueSelecione : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return value.ToString() == "Selecione" ? false : true;
            }
            else
                return false;
        }
    }
}