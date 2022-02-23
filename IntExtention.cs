using System.Globalization;

namespace iXtentions
{
    public static class IntExtention
    {
        public static string NomeDoMes(this int Value)
        {
            //string fullMonthName = new DateTime(DateTime.Now.Year, Value, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("pt_BR"));
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Value);
            monthName = monthName.ToFirstUpper();
            return monthName;
        }

       


    }
}