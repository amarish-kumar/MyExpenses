/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.Collections.Generic;

    using MyExpenses.Domain.Interfaces;

    public class Tag : IEntity
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
        /// Relation with Expenses_Tags table
        /// </summary>
        public ICollection<Expense> Expenses { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Tag()
        {
            Id = -1;
            Expenses = new HashSet<Expense>();
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if is equal and false otherwise</returns>
        public bool Equals(IEntity obj)
        {
            if (!(obj is Tag))
            {
                return false;
            }

            Tag expense = obj as Tag;

            bool equal = Id.Equals(expense.Id);
            equal &= Name.Equals(expense.Name);
            equal &= Expenses.Count == expense.Expenses.Count;

            if (Expenses.Count == expense.Expenses.Count)
            {
                foreach (Expense tag in Expenses)
                {
                    foreach (Expense expenseTag in expense.Expenses)
                    {
                        equal &= tag.Equals(expenseTag);
                    }
                }
            }

            return equal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">Object to copy</param>
        /// <returns>True if is success and false otherwise</returns>
        public bool Copy(IEntity obj)
        {
            if (!(obj is Tag))
            {
                return false;
            }

            Tag expense = obj as Tag;

            Name = expense.Name;
            Expenses = expense.Expenses;

            return true;
        }
    }
}
