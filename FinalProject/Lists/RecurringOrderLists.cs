using System.Collections.Generic;
using FinalProject.Constants;

namespace FinalProject.Lists
{
    public class RecurringOrderLists
    {
        public static readonly IList<string> RecurringOrderFrequenciesTextList = new List<string>
        {
            RecurringOrderFrequenciesNamesConstants.OnceADay,
            RecurringOrderFrequenciesNamesConstants.Weekly,
            RecurringOrderFrequenciesNamesConstants.OnceAMonth,
            RecurringOrderFrequenciesNamesConstants.EveryTwoMonths,
            RecurringOrderFrequenciesNamesConstants.Quarterly
        };

        public static readonly IList<string> DaysOfWeekList = new List<string>
        {
            DaysOfWeekConstants.Sunday,
            DaysOfWeekConstants.Monday,
            DaysOfWeekConstants.Tuesday,
            DaysOfWeekConstants.Wednesday,
            DaysOfWeekConstants.Thursday,
            DaysOfWeekConstants.Friday,
            DaysOfWeekConstants.Saturday
        };

        public static readonly IList<string> WeeksOfMonthList = new List<string>
        {
            WeeksOfMonthConstants.First,
            WeeksOfMonthConstants.Second,
            WeeksOfMonthConstants.Third,
            WeeksOfMonthConstants.Fourth,
            WeeksOfMonthConstants.Last
        };
    }
}