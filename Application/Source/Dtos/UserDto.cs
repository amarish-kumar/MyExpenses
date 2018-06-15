/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using MyExpenses.Application.Interfaces.Dtos;

    public class UserDto : IDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
