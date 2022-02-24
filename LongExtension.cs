using System;
using System.Globalization;

namespace iXtensions
{
    public static class LongExtension
    {
        public static string NomeDoMes(this long value)
        {
                //string fullMonthName = new DateTime(DateTime.Now.Year, Value, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("pt_BR"));
            int newV = Convert.ToInt32(value);
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(newV);
            monthName = monthName.ToFirstUpper();
            return monthName;
        }
    }
}