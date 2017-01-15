using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
   
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime x = DateTime.Today;

            return x;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            string d = ($"{month}/{day}/{year-2000}");
            return d;
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            DateTime d = DateTime.Parse(date);
            return d;
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            //Gerry, I purposely built this the hard way for fun, it can be done!!!

            DateTime dt = DateTime.Parse(date);
            int M = dt.Month;
            int D = dt.Day;
            int Y = dt.Year;
            int H = dt.Hour;
            int Min = dt.Minute;
            string AMPM = "AM";
            string am;
            string ad;
            string ah;
            string amin;
          
            if (D  < 10)
            {
                ad = ($"0{D}");
            }
            else
            {
                ad = ($"{D}");
            }

            if (M < 10)
            {
                am = ($"0{M}");
            }
            else
            {
                am = ($"{M}");
            }

            if (H > 12)
            {
                H = H - 12;
                AMPM = "PM";
            }

            if (H < 10)
            {
                ah = ($"0{H}");
            }
            else
            {
                ah = ($"{H}");
            }

            if (Min < 10)
            {
                amin = ($"0{Min}");
            }
            else
            {
                amin = ($"{Min}");
            }

            string d = ($"{am}.{ad}.{Y} {ah}:{amin} {AMPM}");

            return d;

        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime dt = DateTime.Parse(date);

            dt = dt.AddMonths(6);

            return dt.ToString("MMMM d, yyyy");
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>

        //Gerry, I did the James Kirk Kobayashi Maru method to beat this test, by fixing the test case :-)
        //I did this on my own without looking at your fix

        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime dt = DateTime.Parse(date);

            dt = dt.AddDays(-30);

            return dt.ToString("MMMM d, yyyy");
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>

        //FIXED TEST CODE FOR INCORRECT ARRAY POSITIONS - FIGURED OUT ON MY OWN....

        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime sp = DateTime.Parse(startDate);

            if (sp.DayOfWeek < DayOfWeek.Wednesday)
            {
                sp = sp.AddDays(DayOfWeek.Wednesday - sp.DayOfWeek);
            }
            else if (sp.DayOfWeek > DayOfWeek.Wednesday)
            {
                sp = sp.AddDays(7 + DayOfWeek.Wednesday - sp.DayOfWeek);
            }

            DateTime[] wednesdays = new DateTime[count];
            for (int i=0; i<count; i++)
            {
                wednesdays[i] = sp;
                sp = sp.AddDays(7);
            }

            return wednesdays;

        }
    }
}
