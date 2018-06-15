/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System.Threading.Tasks;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> SignInAsync(string user, string password, bool remeberMe)
        {
            return await _repository.SignInAsync(user, password, remeberMe);
        }

        public async Task SignOutAsync()
        {
            await _repository.SignOutAsync();
        }

        public async Task<bool> CreateAsync(string email, string password)
        {
            return await _repository.CreateAsync(email, password);
        }
    }
}
