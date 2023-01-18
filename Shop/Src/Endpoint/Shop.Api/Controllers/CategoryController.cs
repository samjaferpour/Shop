using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Services;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IValidator<CategoryRequest> _validator;

        public CategoryController(ICategoryService service, IValidator<CategoryRequest> validator)
        {
            this._service = service;
            this._validator = validator;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ShowAllCategories(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _service.ShowAllCategoriesAsync();
            if (result == null)
            {
                return Content("There is no categories yet");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryRequest request)
        {
            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                throw new Exception(validatorResult.Errors[0].ErrorMessage.ToString());
            }
            var result = await _service.AddCategoryAsync(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]/{id:guid}")]
        public async Task<IActionResult> FindCategoryById([FromRoute] Guid id)
        {
            var result = await _service.FindCategoryByIdAsync(id);
            if (result == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("[action]/{id:guid}")]
        public async Task<IActionResult> RemoveCategory([FromRoute] Guid id)
        {
            var result = await _service.RemoveCategoryAsync(id);
            if (result == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("[action]/{id:guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, [FromBody] CategoryRequest request)
        {
            var result = await _service.EditCategoryAsync(id, request);
            if (result == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(result);
        }
    }
}
