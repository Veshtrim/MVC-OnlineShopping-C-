using System.Linq;
namespace OnlineShopping.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
