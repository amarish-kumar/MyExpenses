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
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
            return Month + " - " + cultureInfo.DateTimeFormat.GetMonthName(Month);
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
