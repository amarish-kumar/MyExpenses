/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Dtos;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces;

    public abstract class AppServiceBase<TModel, TDto> : IAppService<TDto> where TDto : IDto where TModel : IModel
    {
        private readonly IService<TModel> _service;
        private readonly IAdapter<TModel, TDto> _adapter;
        private readonly IUnitOfWork _unitOfWork;

        protected AppServiceBase(IService<TModel> service, IAdapter<TModel, TDto> adapter, IUnitOfWork unitOfWork)
        {
            _service = service;
            _adapter = adapter;
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<TDto> Get()
        {
            return _service.Get().Select(x => _adapter.ModelToDto(x));
        }

        public virtual TDto GetById(long id)
        {
            return _adapter.ModelToDto(_service.GetById(id));
        }

        public virtual bool Remove(long id)
        {
            _unitOfWork.BeginTransaction();

            bool ret = _service.Remove(id);

            if (ret)
            {
                _unitOfWork.Commit();
            }

            return ret;
        }

        public virtual TDto Add(TDto model)
        {
            _unitOfWork.BeginTransaction();

            var ret = _service.Add(_adapter.DtoToModel(model));

            if (ret != null)
            {
                _unitOfWork.Commit();
            }

            return _adapter.ModelToDto(ret);
        }

        public virtual TDto Update(TDto model)
        {
            _unitOfWork.BeginTransaction();

            var ret = _service.Update(_adapter.DtoToModel(model));

            if (ret != null)
            {
                _unitOfWork.Commit();
            }

            return _adapter.ModelToDto(ret);
        }
    }
}