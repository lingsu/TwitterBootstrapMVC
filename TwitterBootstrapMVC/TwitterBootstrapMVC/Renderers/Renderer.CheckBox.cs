using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderCheckBox(HtmlHelper html, BootstrapCheckBoxModel model)
        {
            //model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            if (model.tooltip != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltip.ToDictionary());
            var mergedHtmlAttrs = string.IsNullOrEmpty(model.id) ? model.htmlAttributes : model.htmlAttributes.AddOrReplace("id", model.id);

            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            TagBuilder input = new TagBuilder("input");
            //input.MergeAttribute("type", "checkbox");
            input.AddOrMergeAttribute("type", "checkbox");
            input.AddOrMergeAttribute("value", "true");
            input.AddOrMergeAttribute("name", model.htmlFieldName);
            input.MergeAttributes(model.htmlAttributes.FormatHtmlAttributes());
            if (model.isChecked)
            {
                input.AddOrMergeAttribute("checked", "checked");
            }

            return input.ToString(TagRenderMode.Normal);
            // return html.CheckBox(model.htmlFieldName, model.isChecked, mergedHtmlAttrs.FormatHtmlAttributes()).ToHtmlString() + validationMessage;
        }
    }
}
