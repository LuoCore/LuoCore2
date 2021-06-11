using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CrossCutting.Filters
{
    public class ApiAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ClaimsPrincipal _id;

        public ApiAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
            var id = new ClaimsIdentity("Api");
            id.AddClaim(new Claim(ClaimTypes.Name, "Hao", ClaimValueTypes.String, "Api"));
            _id = new ClaimsPrincipal(id);
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            => Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(_id, "Api")));
    }
}
