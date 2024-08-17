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
        public Category Update(Category category)
        {


            string commandString = $"Update Categories Set ([CategoryName]='{category.CategoryName}',[Description]='{category.Description}') Where ( [CategoryID]='{category.CategoryID}')";
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
