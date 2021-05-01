using App.WebUI.Extensions.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace App.WebUI.Extensions.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "apaga-by-action")]
    public class ApagaElementoHtmlByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApagaElementoHtmlByActionTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("apaga-by-action")]
        public string ActionName { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (output == null) throw new ArgumentNullException(nameof(output));

            var action = _httpContextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (action.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}
