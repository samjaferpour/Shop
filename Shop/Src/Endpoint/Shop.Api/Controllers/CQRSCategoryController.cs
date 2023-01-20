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
        {
            ;
            this._mediator = mediator;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> ShowAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("[controller]/id")]
        public async Task<IActionResult> CategoryDetails([FromQuery] GetCategoryByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete]
        [Route("[controller]/id")]
        public async Task<IActionResult> RemoveCategory([FromQuery] RemoveCategoryByIdCommand command)
        {
            await _mediator.Send(command);
            return Ok("Successfully Removed");
        }
        [HttpPut]
        [Route("[controller]/id")]
        public async Task<IActionResult> EditCategory([FromBody] EditByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
