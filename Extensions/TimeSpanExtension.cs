using System;

namespace iXtensions.Extensions
{
    public static class TimeSpanExtension
    {
        public static int Days(this TimeSpan? ts)
            => ts.Value.Days;
        
        public static string DaysWithDias(this TimeSpan? ts)
            => ts.Value.Days == 1 ? ts.Value.Days + " dia" : ts.Value.Days + " dias";
    }
}
