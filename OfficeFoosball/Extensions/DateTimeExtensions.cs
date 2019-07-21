using System;

namespace OfficeFoosball.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetPreviousWorkingDay(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return dateTime.Date.AddDays(-2);
                case DayOfWeek.Monday:
                    return dateTime.Date.AddDays(-3);
                default:
                    return dateTime.Date.AddDays(-1);
            }
        }
    }
}
