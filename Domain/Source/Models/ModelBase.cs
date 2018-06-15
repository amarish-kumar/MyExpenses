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

        public MyUser CreatedUser { get; set; }

        public MyUser LastUpdateUser { get; set; }

        public virtual void Copy(IModel obj)
        {
            Id = obj.Id;
            CreatedUser = obj.CreatedUser;
            LastUpdateUser = obj.LastUpdateUser;
        }
    }
}
