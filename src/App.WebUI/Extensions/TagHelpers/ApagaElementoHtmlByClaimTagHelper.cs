using App.WebUI.Extensions.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace App.WebUI.Extensions.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "apaga-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "apaga-by-claim-value")]
    public class ApagaElementoHtmlByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApagaElementoHtmlByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("apaga-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("apaga-by-claim-value")]

        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (output == null) throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_httpContextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }
}
