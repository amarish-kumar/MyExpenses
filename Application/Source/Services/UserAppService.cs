/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Threading.Tasks;

    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;

    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(IUserService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SignInAsync(string email, string password, bool remeberMe)
        {
            return await _service.SignInAsync(email, password, remeberMe);
        }

        public async Task SignOutAsync()
        {
            await _service.SignOutAsync();
        }

        public async Task<bool> CreateAsync(string email, string password)
        {
            return await _service.CreateAsync(email, password);
        }
    }
}
