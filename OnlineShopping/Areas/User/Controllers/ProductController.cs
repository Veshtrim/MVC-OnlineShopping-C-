using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using System.Linq;
using OnlineShopping.Models.ViewModels;
using System;


namespace OnlineShopping.Controllers
{
    [Area("User")]
    
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string productSearch,string category, int productPage = 1)
        {
            var q = repository.Products.AsQueryable();

            // Filter by name (Name must contain given value)
            if (!String.IsNullOrEmpty(productSearch))
            {
                q = q.Where(p => p.ProductName.Contains(productSearch));
            }

     
            return View(new ProductsListViewModel
            {
                Products = repository.Products
             .Where(p => category == null || p.ProductCategory == category)
             .Where(n => productSearch == null || n.ProductName == productSearch)
               .OrderBy(p => p.ProductId)
               .Skip((productPage - 1) * PageSize)
               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                   repository.Products.Count() :
                  repository.Products.Where(e =>
                   e.ProductCategory == category).Count()
                },
                CurrentCategory = category
            });
          
        }
    }
}
