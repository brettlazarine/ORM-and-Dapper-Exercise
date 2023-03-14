using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");   
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("Select * FROM products WHERE ProductID = @id", new { id });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name," +
                " Price = @price," +
                " CategoryID = @categoryID," +
                " OnSale = @onsale," +
                " StockLevel = @stock " +
                "WHERE ProductID = @id;",
                new { id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    onsale = product.OnSale,
                    stock = product.StockLevel });
        }

        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM sales WHERE ProductID = @id;", new { id });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id });
            _connection.Execute("DELETE FROM products WHERE ProductID = @id;", new { id });
        }
    }
}
