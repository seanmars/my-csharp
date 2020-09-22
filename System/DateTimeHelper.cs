using System;
using System.Collections.Generic;
using System.Globalization;

public class DateTimeHelper
{
    private readonly Dictionary<int, int> _beginWeekOfYear = new Dictionary<int, int>();
    private readonly CultureInfo _cultureInfo = new CultureInfo("zh-TW");

    private DateTime BeginDateTime { get; } = DateTime.MinValue;
    private DateTime EndDateTime { get; } = DateTime.MaxValue;

    public DateTimeHelper()
    {
        Init();
    }

    public DateTimeHelper(DateTime beginDateTime, DateTime endDateTime)
    {
        BeginDateTime = beginDateTime;
        EndDateTime = endDateTime;

        if (BeginDateTime >= EndDateTime)
        {
            throw new ArgumentException("The begin DateTime can not equal or over then end DateTime.");
        }

        Init();
    }

    private void Init()
    {
        var current = BeginDateTime;
        var sumOfTotalYearHasWeeks = 0;

        while (current.Year <= EndDateTime.Year)
        {
            _beginWeekOfYear[current.Year] = sumOfTotalYearHasWeeks + 1;

            var lastDayOfYear = new DateTime(current.Year, 12, 31);
            sumOfTotalYearHasWeeks += _cultureInfo.Calendar
                .GetWeekOfYear(lastDayOfYear, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            if (current.Year == DateTime.MaxValue.Year)
            {
                break;
            }

            current = current.AddYears(1);
        }
    }

    public int GetBeginWeekOfYear(DateTime dateTime)
    {
        return _beginWeekOfYear.TryGetValue(dateTime.Year, out var result)
            ? result
            : 0;
    }

    public int WeekOfBeginDate(DateTime dateTime)
    {
        // TODO
        return 1;
    }
}
