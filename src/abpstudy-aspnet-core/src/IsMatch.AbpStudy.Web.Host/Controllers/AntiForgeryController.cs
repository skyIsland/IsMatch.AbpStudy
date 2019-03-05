using Microsoft.AspNetCore.Antiforgery;
using IsMatch.AbpStudy.Controllers;

namespace IsMatch.AbpStudy.Web.Host.Controllers
{
    public class AntiForgeryController : AbpStudyControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
