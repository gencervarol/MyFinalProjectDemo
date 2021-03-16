using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {   
        //global değişkenler alt çizgi ile verilir.
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName= "T-Shirt", UnitPrice= 35, UnitsInStock=20 },
                new Product { ProductId = 2, CategoryId = 2, ProductName= "Atkı", UnitPrice= 20, UnitsInStock=50 },
                new Product { ProductId = 3, CategoryId = 3, ProductName= "Bileklik", UnitPrice= 10, UnitsInStock=100 },
                new Product { ProductId = 4, CategoryId = 4, ProductName= "Mont", UnitPrice= 495, UnitsInStock=15 },
                new Product { ProductId = 5, CategoryId = 5, ProductName= "Şort", UnitPrice= 25, UnitsInStock=45 }
            };
        }
        
        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            foreach (var p in _products)
           // {    if (product.ProductId==p.ProductId   {                     productToDelete = p;     }           }
            //LINQ

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
           Product  productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
