using X.PagedList.Web.Common;

namespace Project.WebUI
{
    public static class Extensions
    {
        public static PagedListRenderOptions PagedListRenderOptions {
            get {
                return new PagedListRenderOptions
                {
                    ActiveLiElementClass = "active", // Aktive olacak olan sayfa sayısı görüntüsü(bootstraptaki verilere göre ayarlanmıştır)
                    UlElementClasses = new[] { "pagination", "pagination-sm" }, //ul class verileri
                    LiElementClasses = new[] { "page-item"}, //li class verileri
                    PageClasses = new[] { "page-link"}, //a class verileri
                    ContainerDivClasses = new[] { "d-flex", "justify-content-center", "p-2"} //kapsayıcı class oluşturup csslerini veriyoruz.
                };
            }
        }
    }
}
