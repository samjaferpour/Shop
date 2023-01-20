using MediatR;
using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.CategoryFeatures.Commands
{
    public class EditByIdCommand : IRequest<EditByIdCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class EditByIdCommandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class EditByIdCommandHandler : IRequestHandler<EditByIdCommand, EditByIdCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<EditByIdCommandResponse> Handle(EditByIdCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = command.Id,
                Name = command.Name,
            };
            await _categoryRepository.UpdateAsync(category.Id, category);
            await _unitOfWork.CommitChangesAsync();
            return new EditByIdCommandResponse { Id = command.Id, Name = command.Name};
        }
    }
}
