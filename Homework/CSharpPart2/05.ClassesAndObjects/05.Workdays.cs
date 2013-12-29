// Write a method that calculates the number of workdays between today and given date, 
// passed as parameter. Consider that workdays are all days from Monday to Friday 
// except a fixed list of public holidays specified preliminary as array.

using System;
using System.Globalization;

class Workdays
{
    static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        Console.WriteLine("Enter Year, Month and Day - each on a separate line:");
        DateTime now = DateTime.Now.Date; // Set the time to 00:00:00 o'clock,
        DateTime then = new DateTime(     // so we compare equal days and can use ints.
            int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

        GetWorkdaysBetween(now, then);
    }

    static void GetWorkdaysBetween(DateTime start, DateTime end)
    {
        if (start > end) { Console.WriteLine("Erroneous input!"); return; }

        DateTime[] holidays = {
        new DateTime(start.Year,  1,  1),
        new DateTime(start.Year,  3,  3),
        new DateTime(start.Year,  5,  6),
        new DateTime(start.Year,  5, 24),
        new DateTime(start.Year, 10,  9), }; // My birthday, obv. 
                                                                                // If it is Sat/Sun, we
        if (start.DayOfWeek == DayOfWeek.Saturday) start = start.AddDays(2);    // start counting from the
        else if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(1); // first upcoming Monday.

        int subtractedDays = 0;
        if (end.DayOfWeek == DayOfWeek.Sunday) // We cout only full days, so no need to remove Saturdays.
        {                                      // We skip Saturdays with the 00:00 and on Mondays,
            end = end.AddDays(-1); // Subtracts one day.        // we have already removed the two weekend days.
            subtractedDays += 1;   // We remember how many days we subtracted,
        }                          // in order to display the right date in the end.

        int daysBetweenDates = (int)end.Subtract(start).TotalDays;
        int resultDays = 0;

        resultDays = daysBetweenDates - ((daysBetweenDates / 7) * 2);

        for (int y = 0; y <= end.Year - start.Year; y++)
        {
            for (int i = 0; i < holidays.Length; i++)
            {
                holidays[i] = new DateTime(holidays[i].Year + 1, holidays[i].Month, holidays[i].Day);

                if (holidays[i] <= end && holidays[i] >= start &&
                    holidays[i].DayOfWeek != DayOfWeek.Saturday && holidays[i].DayOfWeek != DayOfWeek.Sunday)
                        Console.Write("\n{0:MMM dd, yyyy} has been excluded as a holiday.", holidays[i], resultDays--);
            }

            Console.WriteLine();
        }

        Console.WriteLine("\nThere are {0} workdays until {1:dd.MM.yyyy HH:mm:ss}.", resultDays, end.AddDays(subtractedDays));
        Console.WriteLine("(Meaning {0:MMM, dd, yyyy} is not counted.)\n", end.AddDays(subtractedDays));
    }
}
