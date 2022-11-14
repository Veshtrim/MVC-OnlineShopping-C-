using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OnlineShopping.Models;
namespace OnlineShopping.Models.ViewModels
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo) {
            repository = repo;
        
        }
        public IViewComponentResult Invoke() {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                    .Select(x => x.ProductCategory)
                    .Distinct()
                    .OrderBy(x => x));
        }
    }
}
