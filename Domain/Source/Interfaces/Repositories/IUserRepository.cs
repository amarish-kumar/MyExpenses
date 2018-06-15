/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces.Repositories
{
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<bool> SignInAsync(string email, string password, bool remeberMe);

        Task SignOutAsync();

        Task<bool> CreateAsync(string email, string password);
    }
}
