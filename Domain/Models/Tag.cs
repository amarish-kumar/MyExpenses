/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using MyExpenses.Domain.Validator;

    public class Tag : DomainBase<Tag>
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

        public override bool MyCopy(Tag other)
        {
            Id = other.Id;
            Name = other.Name;

            return true;
        }

        public override Tag MyClone()
        {
            var obj = new Tag();
            obj.MyCopy(this);
            return obj;
        }

        public override bool MyEqual(Tag other)
        {
            bool equal = Id.Equals(other.Id);
            equal &= Name.Equals(other.Name);

            return equal;
        }
    }
}
