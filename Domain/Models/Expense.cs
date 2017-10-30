/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Validator;

    public sealed class Expense : EntityBase<Expense>
    {
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
        public Expense() : base(new ExpenseValidator())
        {
            Id = -1;
            Tags = new HashSet<Tag>();
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="other">Object to compare</param>
        /// <returns>True if is equal and false otherwise</returns>
        public override bool Equals(Expense other)
        {
            Expense expense = other;

            bool equal = Id.Equals(expense.Id);
            equal &= Name.Equals(expense.Name);
            equal &= Value.Equals(expense.Value);
            equal &= Date.Equals(expense.Date);
            equal &= Tags.Count == expense.Tags.Count;

            return equal;
        }

        /// <summary>
        /// Copy method
        /// </summary>
        /// <param name="obj">Object to copy</param>
        /// <returns>True if is success and false otherwise</returns>
        public override bool Copy(IEntity obj)
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
