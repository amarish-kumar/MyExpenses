/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc.Rendering;

    internal static class MyDateViewModel
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
    }

    internal class MonthViewModel
    {
        public MonthViewModel(int month)
        {
            Month = month;
        }

        public int Month { get; }

        public string Name => ToString();

        public override string ToString()
        {
            return Month + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month);
        }

        public static SelectList GetAll(int selectedMonth)
        {
            ICollection<MonthViewModel> allMonths = new List<MonthViewModel>();

            for (int i = 1; i <= 12; i++)
            {
                allMonths.Add(new MonthViewModel(i));
            }

            return new SelectList(allMonths, nameof(MonthViewModel.Month), nameof(MonthViewModel.Name), selectedMonth);
        }
    }
}
