/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Expense
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Expense()
        {
            Tags = new HashSet<Tag>();
        }
    }
}
