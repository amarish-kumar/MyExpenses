/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Domain.Interfaces;

    public class ModelBase : IModel
    {
        [Key]
        public long Id { get; set; }
    }
}
