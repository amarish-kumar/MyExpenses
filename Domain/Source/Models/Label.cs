/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public class Label : ModelBase
    {
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public override void Copy(IModel obj)
        {
            base.Copy(obj);

            if (obj is Label label)
            {
                Name = label.Name;
                Expenses = label.Expenses;
            }
        }
    }
}
