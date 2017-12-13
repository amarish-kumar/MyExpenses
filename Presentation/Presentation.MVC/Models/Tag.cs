/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tags")]
    public class Tag
    {
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
