using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shop.Api.Controllers;
using Shop.Api.Validations;
using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Services;
using ShopTest.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest.Controllers
{
    public class CategoryControllerTest
    {
        private IValidator<CategoryRequestValidator> _validator;
        private CategoryMockData _categoryMock;
        public CategoryControllerTest(IValidator<CategoryRequestValidator> validator)
        {
            this._categoryMock = new CategoryMockData();
            this._validator = validator;
        }
        [Fact]
        public void Task_ShowAllCategories_Test()
        {
            //Arrange
            var moq = new Mock<ICategoryService>(); 
            moq.Setup(c => c.ShowAllCategoriesAsync()).Returns(_categoryMock.GetCategories());
            
            //var categoryController = new CategoryController(moq.Object, _validator);
            //var cancellationToken = new CancellationToken();
            ////Act
            //var result = categoryController.ShowAllCategories(cancellationToken);
            ////Assert
            //Assert.NotNull(result);
            //Assert.IsType<OkResult>(result);
            //Assert.IsType<OkObjectResult>(result);
            //var returnOk = result as OkObjectResult;
            //Assert.NotNull(returnOk);
            //Assert.IsType<List<CategoryResponse>>(returnOk.Value);
        }
    }
}
