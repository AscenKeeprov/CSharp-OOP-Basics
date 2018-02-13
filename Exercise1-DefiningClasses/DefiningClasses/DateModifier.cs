using System;
using System.Globalization;

public class DateModifier
{
    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public int DateDelta { get { return Math.Abs((Date2 - Date1).Days); } }

    public int GetDateDifference(string date1, string date2)
    {
	Date1 = DateTime.ParseExact(date1, @"yyyy MM dd", CultureInfo.InvariantCulture);
	Date2 = DateTime.ParseExact(date2, @"yyyy MM dd", CultureInfo.InvariantCulture);
	return DateDelta;
    }
}
