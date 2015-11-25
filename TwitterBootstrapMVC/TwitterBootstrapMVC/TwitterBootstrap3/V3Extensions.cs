using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrap3
{
    public static class V3Extensions
    {
        public static BootstrapTextBox<TModel> Size<TModel>(this BootstrapTextBox<TModel> textBox, InputSize inputSize)
        {
            //textBox._model.size = inputSize;
            return textBox;
        }
    }
}