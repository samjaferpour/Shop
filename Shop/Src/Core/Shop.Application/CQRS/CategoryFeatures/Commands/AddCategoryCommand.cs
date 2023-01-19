using AutoMapper;
using MediatR;
using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.CategoryFeatures.Commands
{
    public class AddCategoryCommand : IRequest<AddCategoryResponse>
    {
        public string Name { get; set; } =string.Empty;
    }
    public class AddCategoryResponse
    {
        public Guid CategoryId { get; set;}
    }
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<AddCategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            //var category = _mapper.Map<Category>(request);
            var category = new Category
            {
                Name= request.Name,
            };
            await _categoryRepository.InsertAsync(category);
            await _unitOfWork.CommitChangesAsync();
            return new AddCategoryResponse
            {
                CategoryId = category.Id,
            };
        }
    }
}
