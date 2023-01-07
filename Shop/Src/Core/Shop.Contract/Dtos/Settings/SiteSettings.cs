using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Dtos.Settings
{
    public class SiteSettings
    {
        public JwtConfig JwtConfig { get; set; } = null!;
    }
}
