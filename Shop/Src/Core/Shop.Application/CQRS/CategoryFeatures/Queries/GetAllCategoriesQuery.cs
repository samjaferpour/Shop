using AutoMapper;
using MediatR;
using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.CategoryFeatures.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<GetAllCategoriesQueryResponse>>
    {
    }
    public class GetAllCategoriesQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetAllCategoriesQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository= categoryRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            //var response = _mapper.Map<IEnumerable<GetAllCategoriesQueryResponse>>(categories);
            var responses = new List<GetAllCategoriesQueryResponse>();
            foreach (var category in categories)
            {
                responses.Add(new GetAllCategoriesQueryResponse { Id = category.Id, Name = category.Name });
            }
            return responses;
        }
    }
}
