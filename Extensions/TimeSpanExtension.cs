using System;

namespace iXtensions.Extensions
{
    public static class TimeSpanExtension
    {
        public static int Days(this TimeSpan? ts)
            => ts.Value.Days;
    }
}
