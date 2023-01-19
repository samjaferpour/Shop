using MediatR;
using Shop.Contract.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdResponse>
    {
        public Guid Id { get; set; }
    }
    public class GetCategoryByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            return new GetCategoryByIdResponse { Id = category.Id , Name = category.Name };
        }
    }
}
