/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Adapter;
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public class TagsAppService : ITagsAppService
    {
        private readonly ITagsService _tagsService;
        private readonly IUnitOfWork _unitOfWork;

        public TagsAppService(ITagsService tagsService, IUnitOfWork unitOfWork)
        {
            _tagsService = tagsService;
            _unitOfWork = unitOfWork;
        }

        public List<TagDto> GetAllTags()
        {
            // Get tags from domain
            List<Tag> tagsDomain = _tagsService.GetAll().ToList();

            // Convert to DTO
            List<TagDto> tagsDto = tagsDomain.Select(TagAdapter.ToDto).ToList();

            return tagsDto;
        }

        public MyResults SaveOrUpdateTag(TagDto tagDto)
        {
            _unitOfWork.BeginTransaction();

            // Save or update expenses
            MyResults results = _tagsService.SaveOrUpdate(TagAdapter.ToDomain(tagDto));

            if(results.Type == MyResultsType.Ok)
                _unitOfWork.Commit();

            return results;
        }

        public MyResults RemoveTag(TagDto tagDto)
        {
            _unitOfWork.BeginTransaction();

            // Remove expense
            MyResults results = _tagsService.Remove(TagAdapter.ToDomain(tagDto));

            if (results.Type == MyResultsType.Ok)
                _unitOfWork.Commit();

            return results;
        }
    }
}
