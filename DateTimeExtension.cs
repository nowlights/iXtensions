using System;
using System.Globalization;

namespace iXtensions
{
    public static class DateTimeExtension
    {

        public static string ToFormatDateMySql(this DateTime dt)
             => dt.ToString("yyyy-MM-dd");


        public static string ToDiaMesAnoHoraMinuto(this DateTime value)
            => value.ToString("dd/MM/yyyy HH:mm");



        public static string ToString(this DateTime? dt, string format)
            => dt == null ? "n/a" : ((DateTime)dt).ToString(format);


        public static string CalcTime(this DateTime HoraIni, DateTime HoraFim)
        {
            TimeSpan ts;
            ts = HoraIni - HoraFim;
            return ts.ToString(@"hh\:mm\:ss");
        }

        public static TimeSpan CalcTime(this DateTime HoraIni, DateTime HoraFim, bool ReturnTimeSpan = true)
        {
            TimeSpan ts;
            ts = HoraFim - HoraIni;
            return ts;
        }

        public static string? CalcTime(this DateTime? HoraIni, DateTime? HoraFim)
        {
            TimeSpan? ts;
            ts = HoraIni - HoraFim;
            return ts?.ToString(@"hh\:mm\:ss");
        }

        public static TimeSpan? CalcTime(this DateTime? HoraIni, DateTime? HoraFim, bool ReturnTimeSpan = true)
        {
            TimeSpan? ts;
            ts = HoraFim - HoraIni;
            return ts;
        }

        /// <summary>
        /// Verify date is more than 2018
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Boolean</returns>
        public static bool isValid(this DateTime? dt)
            => dt == null ? false : (dt >= new DateTime(2018, 1, 1) ? true : false);

        public static bool isValid(this DateTime dt)
            => dt >= new DateTime(2018, 1, 1) ? true : false;

        public static string ToDataASHoraMinuto(this DateTime dt)
            => (dt.ToString("dd/MM/dddd") + " às " + dt.ToString("HH:mm"));

        public static bool DateBetween(this DateTime DataToCheck, DateTime Start, DateTime fim)
            => (DataToCheck >= Start && DataToCheck < fim ? true : false);

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static string ToDetails(this DateTime dt)
        {
            if (dt.Day == DateTime.Now.Day) return $"hoje {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-1).Day) return $"ontem, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-2).Day) return $"há dois dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-3).Day) return $"há três dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-4).Day) return $"há quatro dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-5).Day) return $"há cinco dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (DateTime.Now.StartOfWeek(DayOfWeek.Monday) < dt) return $"esta semana, {dt.ToString("dd/MM")} às {dt.ToString("HH:mm")}";
            else if (dt.Month == DateTime.Now.Month) return $"este mês, {dt.ToString("dd/MM")} às {dt.ToString("HH:mm")}";
            else return $"Em {dt.ToString("dd/MM/yyyy")} às {dt.ToString("HH:mm")}";
        }

        public static string ToDetails(this DateTime? dataNullable, string returnIfNull)
        {
            if (!dataNullable.isValid()) return returnIfNull;
            DateTime dt = Convert.ToDateTime(dataNullable);
            if (dt.Day == DateTime.Now.Day) return $"hoje {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-1).Day) return $"ontem, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-2).Day) return $"há dois dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-3).Day) return $"há três dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-4).Day) return $"há quatro dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (dt.Day == DateTime.Now.AddDays(-5).Day) return $"há cinco dias atrás, {dt.ToString("dddd")} ({dt.ToString("dd/MM")}) às {dt.ToString("HH:mm")}";
            else if (DateTime.Now.StartOfWeek(DayOfWeek.Monday) < dt) return $"esta semana, {dt.ToString("dd/MM")} às {dt.ToString("HH:mm")}";
            else if (dt.Month == DateTime.Now.Month) return $"este mês, {dt.ToString("dd/MM")} às {dt.ToString("HH:mm")}";
            else return $"Em {dt.ToString("dd/MM/yyyy")} às {dt.ToString("HH:mm")}";
        }

        public static string GetDayName(this DateTime Value)
            => CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Value.DayOfWeek).ToFirstUpper();


        public static string GetMonthName(this DateTime Month)
           => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month.Month).ToFirstUpper();
        
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(this DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }


    }
}
