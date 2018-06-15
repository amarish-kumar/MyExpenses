/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.Interfaces;

    public abstract class ModelBase : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // TODO
        //[ForeignKey("CreatedUserId")]
        //public long? CreatedUserId { get; set; }
        //public User CreatedUser { get; set; }

        //[ForeignKey("LastUpdateUserId")]
        //public long? LastUpdateUserId { get; set; }
        //public User LastUpdateUser { get; set; }

        public virtual void Copy(IModel obj)
        {
            Id = obj.Id;

            // TODO
            //CreatedUserId = obj.CreatedUserId;
            //CreatedUser = obj.CreatedUser;

            //LastUpdateUserId = obj.LastUpdateUserId;
            //LastUpdateUser = obj.LastUpdateUser;
        }
    }
}
