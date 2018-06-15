/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;

    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _manager;

        public UserRepository(SignInManager<User> signInManager, UserManager<User> manager)
        {
            _signInManager = signInManager;
            _manager = manager;
        }

        public async Task<bool> SignInAsync(string email, string password, bool remeberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, remeberMe, false);
            return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> CreateAsync(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await _manager.CreateAsync(user, password);
            return result.Succeeded;
        }
    }
}
