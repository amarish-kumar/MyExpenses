/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expenses")]
    public sealed class Expense : IEntity
    {
        /// <summary>
        /// ID column
        /// </summary>
        [Key]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// NAME column
        /// </summary>
        [Column("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// VALUE column
        /// </summary>
        [Column("VALUE")]
        public float Value { get; set; }

        /// <summary>
        /// DATE column
        /// </summary>
        [Column("DATE")]
        public DateTime Date { get; set; }

        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Construtor
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
        /// 
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
