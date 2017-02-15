namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Expense
    {
        public long ID;

        public string Name { get; set; }

        public string Value { get; set; }

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
