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

    public sealed class Expense : DomainBase
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

        public override IDomain Clone()
        {
            var obj = new Expense();
            obj.Copy(this);
            return obj;
        }

        public override bool Copy(IDomain other)
        {
            if (!(other is Expense))
                return false;

            var obj = (Expense)other;

            Id = obj.Id;
            Name = obj.Name;
            Value = obj.Value;
            Date = obj.Date;
            Tags = obj.Tags;

            return true;
        }

        public override bool Equal(IDomain other)
        {
            if (!(other is Expense))
                return false;

            var obj = (Expense)other;

            bool equal = Id.Equals(obj.Id);
            equal &= Name.Equals(obj.Name);
            equal &= Value.Equals(obj.Value);
            equal &= Tags.Equals(obj.Tags);

            return equal;
        }
    }
}
