/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util
{
    using System;

    public static class MyDate
    {
        public static DateTime GetStartDateTime(int month, int year)
        {
            if (month <= 0 && year <= 0)
            {
                month = DateTime.Today.Month;
                year = DateTime.Today.Year;
            }

            return new DateTime(year, month, 1);
        }

        public static DateTime GetEndDateTime(int month, int year)
        {
            if (month <= 0 && year <= 0)
            {
                month = DateTime.Today.Month;
                year = DateTime.Today.Year;
            }

            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime GetStartLastMonth(int month, int year)
        {
            if (month - 1 < 1)
            {
                month = 12;
                year = year - 1;
            }

            return new DateTime(year, month, 1);
        }

        public static DateTime GetEndLastMonth(int month, int year)
        {
            if (month - 1 < 1)
            {
                month = 12;
                year = year - 1;
            }

            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        }
    }
}
