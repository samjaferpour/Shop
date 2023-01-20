using MediatR;
using Shop.Contract.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.CategoryFeatures.Commands
{
    public class RemoveCategoryByIdCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
   
    public class RemoveCategoryByIdCommandHandler : IRequestHandler<RemoveCategoryByIdCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(RemoveCategoryByIdCommand command, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(command.Id);
            await _unitOfWork.CommitChangesAsync();
            return Unit.Value;
        }
    }
}
