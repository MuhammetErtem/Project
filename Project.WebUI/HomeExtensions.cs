using X.PagedList.Web.Common;

namespace Project.WebUI
{
    public static class HomeExtensions
    {
        public static PagedListRenderOptions PagedListRenderOptions {
            get {
                return new PagedListRenderOptions
                {
                    PageClasses = new[] { "active" }, //a class verileri
                    ContainerDivClasses = new[] { "d-flex", "justify-content-center", "p-2"," product__pagination "} //kapsayıcı class oluşturup csslerini veriyoruz.
                };
            }
        }
    }
}
