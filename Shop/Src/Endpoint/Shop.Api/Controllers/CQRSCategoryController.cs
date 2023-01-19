using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.CQRS.CategoryFeatures.Commands;
using Shop.Application.CQRS.CategoryFeatures.Queries;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CQRSCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CQRSCategoryController(IMediator mediator)
        {      ;
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
