using System.Globalization;

namespace iXtensions
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

        public static string GetMonthName(this int Month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month).ToFirstUpper();
        }


        private static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        public static string FormatSize(this Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }




    }
}