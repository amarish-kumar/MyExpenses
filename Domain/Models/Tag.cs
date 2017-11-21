/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Validator;

    public class Tag : DomainBase
    {
        /// <summary>
        /// Name column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Tag() : base(new TagValidator())
        {
            Id = -1;
        }

        public override IDomain Clone()
        {
            var obj = new Tag();
            obj.Copy(this);
            return obj;
        }

        public override bool Copy(IDomain other)
        {
            if (!(other is Tag))
                return false;

            var obj = (Tag)other;

            Id = obj.Id;
            Name = obj.Name;

            return true;
        }

        public override bool Equal(IDomain other)
        {
            if (!(other is Tag))
                return false;

            var obj = (Tag)other;

            bool equal = Id.Equals(obj.Id);
            equal &= Name.Equals(obj.Name);

            return equal;
        }
    }
}
