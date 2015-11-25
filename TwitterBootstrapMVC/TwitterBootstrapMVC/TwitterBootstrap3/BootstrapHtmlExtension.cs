using System.Web.Mvc;
using TwitterBootstrapMVC;
using TwitterBootstrapMVC.BootstrapMethods;

namespace TwitterBootstrap3
{
    public static class BootstrapHtmlExtension
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> helper)
        {
            return new Bootstrap<TModel>(helper);
        }

        public static BootstrapAjax<TModel> Bootstrap<TModel>(this AjaxHelper<TModel> helper)
        {
          
            return new BootstrapAjax<TModel>(helper);
        }
    }
}