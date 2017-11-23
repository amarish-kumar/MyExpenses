/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Domain.Validator;

    public sealed class Expense : DomainBase<Expense>
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
        public Expense()
        {
            Validator = new ExpenseValidator(this);
            Id = -1;
            Tags = new HashSet<Tag>();
        }

        public override bool MyCopy(Expense other)
        {
            Id = other.Id;
            Name = other.Name;
            Value = other.Value;
            Date = other.Date;
            Tags = other.Tags;

            return true;
        }

        public override Expense MyClone()
        {
            var obj = new Expense();
            obj.MyCopy(this);
            return obj;
        }

        public override bool MyEqual(Expense other)
        {
            bool equal = Id.Equals(other.Id);
            equal &= Name.Equals(other.Name);
            equal &= Value.Equals(other.Value);
            equal &= Tags.Equals(other.Tags);

            return equal;
        }
    }
}
