/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System;

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
        /// Tag relation
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Expense()
        {
            Validator = new ExpenseValidator(this);
            Id = -1;
        }

        public override bool MyCopy(Expense other)
        {
            Id = other.Id;
            Name = other.Name;
            Value = other.Value;
            Date = other.Date;
            Tag = other.Tag;

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
            equal &= Tag.Equals(other.Tag);

            return equal;
        }
    }
}
