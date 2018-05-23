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
            int m = month <= 0 ? DateTime.Today.Month : month;
            int y = year <= 0 ? DateTime.Today.Year : year;

            return new DateTime(y, m, 1);
        }

        public static DateTime GetStartDateTime(DateTime date)
        {
            int m = date.Month <= 0 ? DateTime.Today.Month : date.Month;
            int y = date.Year <= 0 ? DateTime.Today.Year : date.Year;

            return new DateTime(y, m, 1);
        }

        public static DateTime GetEndDateTime(int month, int year)
        {
            int m = month <= 0 ? DateTime.Today.Month : month;
            int y = year <= 0 ? DateTime.Today.Year : year;

            return new DateTime(y, m, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime GetEndDateTime(DateTime date)
        {
            int m = date.Month <= 0 ? DateTime.Today.Month : date.Month;
            int y = date.Year <= 0 ? DateTime.Today.Year : date.Year;

            return new DateTime(y, m, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime GetStartLastMonth(int month, int year)
        {
            int m = month - 1 < 1 ? 12 : month;
            int y = month - 1 < 1 ? year - 1 : year;

            return new DateTime(y, m, 1);
        }

        public static DateTime GetEndLastMonth(int month, int year)
        {
            int m = month - 1 < 1 ? 12 : month;
            int y = month - 1 < 1 ? year - 1 : year;

            return new DateTime(y, m, 1).AddMonths(1).AddDays(-1);
        }
    }
}
