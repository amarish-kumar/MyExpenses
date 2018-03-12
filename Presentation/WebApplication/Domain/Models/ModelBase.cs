/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using WebApplication.Domain.Interfaces;

    public class ModelBase : IModel
    {
        [Key]
        public long Id { get; set; }
    }
}
