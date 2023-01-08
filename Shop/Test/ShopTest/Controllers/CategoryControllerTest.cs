using Microsoft.AspNetCore.Mvc;
using Moq;
using Shop.Api.Controllers;
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
        private CategoryMockData _categoryMock;
        public CategoryControllerTest()
        {
            this._categoryMock = new CategoryMockData();
        }
        [Fact]
        public void Task_ShowAllCategories_Test()
        {
            //Arrange
            var moq = new Mock<ICategoryService>();
            moq.Setup(c => c.ShowAllCategoriesAsync()).Returns(_categoryMock.GetCategories());
            var categoryController = new CategoryController(moq.Object);
            //Act
            var result = categoryController.ShowAllCategories();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            //var returnOk = result as OkObjectResult;
            //Assert.NotNull(returnOk);
            //Assert.IsType<List<CategoryResponse>>(returnOk.Value);
        }
    }
}
