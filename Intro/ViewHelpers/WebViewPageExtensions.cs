using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Intro.ViewHelpers
{
    public static class WebViewPageExtensions
    {
        public static MvcHtmlString RefillPasswordFor<TModel, TProperty>(
            this WebViewPage<TModel> page,
            Expression<Func<TModel, TProperty>> expression
        )
        {
            string propertyName = ExpressionHelper.GetExpressionText(expression);

            ModelStateDictionary modelState = page.ViewData.ModelState;

            if (
                !modelState.ContainsKey(propertyName) ||
                !modelState.IsValidField(propertyName)
            )
            {
                return MvcHtmlString.Empty;
            }

            string passwordInputId = page.Html.IdFor(expression).ToString();

            Func<TModel, TProperty> getProperty = expression.Compile();
            TProperty value = getProperty(page.Model);

            TagBuilder script = new TagBuilder("script");

            script.InnerHtml = string.Format(
                "document.querySelector('#{0}').value = '{1}'",
                passwordInputId,
                value
            );

            return MvcHtmlString.Create(script.ToString());
        }
    }
}