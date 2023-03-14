using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            //var departmentRepo = new DapperDepartmentRepository(conn);
            //departmentRepo.InsertDepartment("NewDept");
            //var departments = departmentRepo.GetAllDepartments();
            //foreach (var department in departments)
            //{
            //    Console.WriteLine($"{department.DepartmentID} {department.Name}");  
            //}

            var productRepo = new DapperProductRepository(conn);
            //var productToUpdate = productRepo.GetProduct(940);
            //productToUpdate.Name = "New Hotness";
            //productToUpdate.StockLevel = 5;
            //productToUpdate.Price = 999.99;
            //productToUpdate.OnSale = false;
            //productToUpdate.CategoryID = 2;
            //productRepo.UpdateProduct(productToUpdate); 
            //var products = productRepo.GetAllProducts();
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.ProductID} {product.Name}: {product.Price}, {product.StockLevel}, {product.OnSale}");
            //}
            productRepo.DeleteProduct(940);
        }
    }
}
