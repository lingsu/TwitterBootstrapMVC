﻿using System;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapPassword : BootstrapTextBoxBase<BootstrapPassword>
    {
        public BootstrapPassword(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
        }

        public override IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.Password);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            return Renderer.RenderTextBox(html, _model, true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
