/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public class Payment : ModelBase
    {
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public override void Copy(IModel obj)
        {
            if (obj is Payment payment)
            {
                Name = payment.Name;
            }
        }
    }
}
