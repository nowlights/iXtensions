using System.ComponentModel.DataAnnotations;

namespace iXtensions.DataAnnotationExtensions
{
    public class DisallowCharacters : ValidationAttribute
    {
        public string[] CharactersLock { get; set; }
        public override bool IsValid(object value)
        {
            var v = value.ToString();
            int r = 0;
            foreach (var i in CharactersLock)
                if (v.Contains(i)) r++;
            if (r == 0) return true;
            else return false;
        }
    }
}