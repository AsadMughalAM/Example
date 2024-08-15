using Core.Entities;
using System.Data;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class CategoryRepository: BaseRepository,ICategoryRepository
    {

        public CategoryRepository(IConfiguration config) : base(config)
        {

        }


        public List<Category> GetData()
        {
            string commandString = "Select * FROM Categories;";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var cat = new List<Category>();

            foreach (DataRow row in dataTable.Rows)
            {
                var cate = new Category()
                {
                    CategoryID = (int)row["CategoryID"],
                    CategoryName = (string)row["CategoryName"],
                    Description = row["Description"]?.ToString(),

                };

                cat.Add(cate);
            }

            return cat;
        }
        public Category? GetById(string id)
        {
            string commandString = $"Select * FROM Customers where CustomerID = '{id}' ;";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var customer = new List<Customer>();
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var cust = new Customer()
                {
                    CustomerID = (string)row["CustomerID"],
                    CompanyName = (string)row["CompanyName"],
                    ContactName = row["ContactName"]?.ToString(),
                    ContactTitle = row["ContactTitle"]?.ToString(),
                    Address = row["Address"]?.ToString(),
                    City = row["City"]?.ToString(),
                    Region = row["Region"]?.ToString(),
                    PostalCode = row["PostalCode"]?.ToString(),
                    Country = row["Country"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    Fax = row["Fax"]?.ToString(),

                };
            }
            return null;
        }
        public Category Create(Category category)
        {


            string commandString = $"Insert into Categories ([CategoryName],[Description]) values ( '{category.CategoryName}' , '{category.Description}')";
            Console.WriteLine(commandString);
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var a = command.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return a > 0 ? category : new();
        }
    }
}
