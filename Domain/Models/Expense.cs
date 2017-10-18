/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Domain.Interfaces;

    public class Expense : IEntity
    {
        /// <summary>
        /// Id column
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value column
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Date column
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Relation with Expenses_Tags table
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Expense()
        {
            Id = -1;
            Tags = new HashSet<Tag>();
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if is equal and false otherwise</returns>
        public bool Equals(IEntity obj)
        {
            if (!(obj is Expense))
            {
                return false;
            }

            Expense expense = (Expense)obj;

            bool equal = Id.Equals(expense.Id);
            equal &= Name.Equals(expense.Name);
            equal &= Value.Equals(expense.Value);
            equal &= Date.Equals(expense.Date);
            equal &= Tags.Count == expense.Tags.Count;

            if(Tags.Count == expense.Tags.Count)
            {
                foreach (Tag tag in Tags)
                {
                    foreach (Tag expenseTag in expense.Tags)
                    {
                        equal &= tag.Equals(expenseTag);
                    }
                }
            }

            return equal;
        }

        /// <summary>
        /// Copy method
        /// </summary>
        /// <param name="obj">Object to copy</param>
        /// <returns>True if is success and false otherwise</returns>
        public bool Copy(IEntity obj)
        {
            if (!(obj is Expense))
            {
                return false;
            }

            Expense expense = (Expense)obj;

            Name = expense.Name;
            Value = expense.Value;
            Date = expense.Date;
            Tags = expense.Tags;

            return true;
        }
    }
}
