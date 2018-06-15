/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces.Services
{
    using System.Threading.Tasks;

    public interface IUserAppService
    {
        Task<bool> SignInAsync(string user, string password, bool remeberMe);

        Task SignOutAsync();

        Task<bool> CreateAsync(string email, string password);
    }
}
