/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;

    public abstract class AppServiceBase<TModel> : IAppService<TModel> where TModel : IModel
    {
        private readonly IAppService<TModel> _service;
        private readonly IUnitOfWork _unitOfWork;

        protected AppServiceBase(IAppService<TModel> service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes)
        {
            return _service.GetAsync(filter, includes);
        }

        public Task<IEnumerable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] includes)
        {
            return _service.GetAllAsync( includes);
        }

        public Task<TModel> GetByIdAsync(long id, params Expression<Func<TModel, object>>[] includes)
        {
            return _service.GetByIdAsync(id, includes);
        }

        public async Task<bool> RemoveAsync(TModel model)
        {
            bool ret = await _service.RemoveAsync(model);

            if (ret)
            {
                await _unitOfWork.CommitAsync();
            }

            return ret;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            bool ret = await _service.RemoveAsync(id);

            if (ret)
            {
                await _unitOfWork.CommitAsync();
            }

            return ret;
        }

        public async Task<TModel> AddOrUpdateAsync(TModel model)
        {
            var ret = await _service.AddOrUpdateAsync(model);

            if (ret != null)
            {
                await _unitOfWork.CommitAsync();
            }

            return ret;
        }
    }
}