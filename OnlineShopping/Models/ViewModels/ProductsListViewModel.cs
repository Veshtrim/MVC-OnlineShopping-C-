using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using OnlineShopping.Models;
namespace OnlineShopping.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBrand { get; set; }
        public IFormFile ProductPhoto { get; set; }
        public string BrandId { get; set; }
        public string productSearch { get; set; }
        
    }
}
