﻿using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderRadioButton(HtmlHelper html, BootstrapRadioButtonModel model)
        {
            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            if (model.tooltip != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltip.ToDictionary());

            model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if (!string.IsNullOrEmpty(model.id)) model.htmlAttributes.AddOrReplace("id", model.id);

            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }
            return html.RadioButton(model.htmlFieldName, model.value, model.isChecked, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString() + validationMessage;
        }
    }
}
