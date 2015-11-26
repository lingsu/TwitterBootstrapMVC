using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    public partial class Renderer<TModel>
    {
        public static string RenderTextBox(HtmlHelper<TModel> html, BootstrapTextBoxModel model, bool isPassword)
        {
            bool flag = html.ViewContext.Controller.ViewData["BMVC.Globals.SetValidationMessageInline"] != null && (bool)html.ViewContext.Controller.ViewData["BMVC.Globals.SetValidationMessageInline"];
            string text = (html.ViewContext.Controller.ViewData["BMVC.Globals.SetValidationMessageBeforeInput"] != null && (bool)html.ViewContext.Controller.ViewData["BMVC.Globals.SetValidationMessageBeforeInput"]) ? "{2}{0}{1}" : "{0}{1}{2}";
            model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));

            var combinedHtml = "{0}{1}{2}";

            if (model.metadata.IsRequired)
            {
                model.htmlAttributes.Add("required", "");
            }

            //model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));

            if (!string.IsNullOrEmpty(model.id)) model.htmlAttributes.Add("id", model.id);
            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            if (model.tooltip != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltip.ToDictionary());
            if (model.typehead != null) model.htmlAttributes.MergeHtmlAttributes(model.typehead.ToDictionary(html));
            // assign placeholder class
            if (!string.IsNullOrEmpty(model.placeholder)) model.htmlAttributes.Add("placeholder", model.placeholder);
            // assign size class
            model.htmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForInputSize(model.size));

            if (VersionSpecific.Version == 3)
            {
                model.htmlAttributes.AddOrMergeCssClass("class", "form-control");
            }

            object value;
            bool flag3 = html.ViewData.TryGetValue(model.htmlFieldName, out value);
            if (flag3)
            {
                html.ViewData.Remove(model.htmlFieldName);
            }

            // build html for input
            var input = isPassword
                ? html.Password(model.htmlFieldName, null, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString()
                : html.TextBox(model.htmlFieldName, model.value, model.format, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            // account for appendString, prependString, and AppendButtons

            var helpText = model.helpText != null ? model.helpText.ToHtmlString() : string.Empty;
            var validationMessage = "";
            if (model.displayValidationMessage)
            {
                var validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            return MvcHtmlString.Create(string.Format(combinedHtml, input, helpText, validationMessage)).ToString();
        }
    }
}