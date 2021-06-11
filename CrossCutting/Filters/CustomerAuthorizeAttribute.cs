using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Filters
{
    public class CustomerAuthorizeAttribute : AuthorizeAttribute
    {
        public const string CustomerAuthenticationScheme = "CustomerAuthenticationScheme";
        public CustomerAuthorizeAttribute()
        {
            this.AuthenticationSchemes = CustomerAuthenticationScheme;
        }
    }
}
