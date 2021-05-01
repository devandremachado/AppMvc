using System;
using App.WebUI.Extensions.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.WebUI.Extensions.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "desabilita-by-claim-name")]
    [HtmlTargetElement("a", Attributes = "desabilita-by-claim-value")]
    public class DesabilitaLinkByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DesabilitaLinkByClaimTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("desabilita-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("desabilita-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (output == null) throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "Você não tem permissão"));
        }
    }
}