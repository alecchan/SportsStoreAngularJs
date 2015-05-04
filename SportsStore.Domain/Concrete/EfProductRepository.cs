using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
	public class EfProductRepository : IProductRepository
	{
		private EfDbContext context = new EfDbContext();

		public IQueryable<Entities.Product> Products
		{
			get { return context.Products; }
		}
		
		public void SaveProduct(Entities.Product product)
		{
			if (product.ProductID == 0)
				context.Products.Add(product);
			else
				context.Entry(product).State = EntityState.Modified;

			context.SaveChanges();
		}

		public void DeleteProduct(Entities.Product product)
		{
			context.Products.Remove(product);
			context.SaveChanges();
		}
	}
}
