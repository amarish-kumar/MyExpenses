/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Validator;
    using System.Collections.Generic;

    public class Tag : EntityBase<Tag>
    {
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
        public Tag() : base(new TagValidator())
        {
            Id = -1;
            Expenses = new HashSet<Expense>();
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="other">Object to compare</param>
        /// <returns>True if is equal and false otherwise</returns>
        public override bool Equals(Tag other)
        {
            bool equal = Id.Equals(other.Id);
            equal &= Name.Equals(other.Name);
            equal &= Expenses.Count == other.Expenses.Count;

            return equal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">Object to copy</param>
        /// <returns>True if is success and false otherwise</returns>
        public override bool Copy(IEntity obj)
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
