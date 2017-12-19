/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using System;

    public class FilterDate
    {
        private FilterDateType _filterDateType { get; set; }

        public FilterDateType FilterDateType
        {
            get => _filterDateType;

            set
            {
                _filterDateType = value;

                switch(_filterDateType)
                {
                    case FilterDateType.CurrentMonth:
                        StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        EndDate = DateTime.Today;
                        break;
                    case FilterDateType.LastMonth:
                        StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                        EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                        break;
                }
            }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public FilterDate()
        {
            FilterDateType = FilterDateType.CurrentMonth;
            StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate = DateTime.Today;
        }
    }

    public enum FilterDateType
    {
        CurrentMonth,
        LastMonth,
        Custom
    }
}
