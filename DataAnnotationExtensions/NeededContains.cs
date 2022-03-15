using System.ComponentModel.DataAnnotations;

namespace iXtensions.DataAnnotationExtensions
{
    public class NeededContains : ValidationAttribute
    {
        public string[] NeedContains { get; set; }

        public override bool IsValid(object value)
        {
            var v = value.ToString();
            int r = 0;
            foreach (var i in NeedContains)
                if (v.Contains(i)) r++;
            return r >= 1;
        }
    }
}