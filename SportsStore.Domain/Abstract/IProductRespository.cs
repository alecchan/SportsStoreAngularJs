using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// Contract for the Product Repository
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

		void SaveProduct(Product product);

		void DeleteProduct(Product product);
    }
}