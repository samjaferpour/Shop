using Shop.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace ShopTest.MockData
{
    public class CategoryMockData
    {
        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            var categories = new Filler<CategoryResponse>().Create(100);
            return categories;
        }

    }
}
