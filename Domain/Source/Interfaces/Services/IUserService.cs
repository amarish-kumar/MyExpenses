/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Services
{
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> SignInAsync(string user, string password, bool remeberMe);

        Task SignOutAsync();

        Task<bool> CreateAsync(string email, string password);
    }
}
