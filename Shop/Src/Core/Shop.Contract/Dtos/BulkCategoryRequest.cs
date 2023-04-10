using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Dtos
{
    public class BulkCategoryRequest
    {
        public List<string> Names { get; set; }
    }
}
