using System;
using System.Globalization;

namespace Modern.Forms.Functions
{
    public static class FunctionsKlocka
    {
        public static string HämtaDatum() =>
            DateTime.Now.ToString("yyyy-MM-dd");

        public static string HämtaTid() =>
            DateTime.Now.ToString("HH:mm:ss");

        public static string HämtaManad() =>
            DateTime.Now.ToString("MMMM", new CultureInfo("sv-SE"));

        public static string HämtaVecka()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Calendar calendar = ci.Calendar;
            CalendarWeekRule rule = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDay = ci.DateTimeFormat.FirstDayOfWeek;
            int vecka = calendar.GetWeekOfYear(DateTime.Now, rule, firstDay);
            return "Vecka: " + vecka;
        }
    }
}
