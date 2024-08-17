using Microsoft.Data.SqlClient;
using Core.Entities;
using System.Data;
using Microsoft.Extensions.Configuration;
using Core.Interfaces;

namespace DAL.Repositories
{
    public class CustomerRepository : BaseRepository,ICustomerRepository
    {
        public CustomerRepository(IConfiguration config): base(config)
        {
            
        }


        public List<Customer> GetData()
        {
            string commandString = "Select * FROM Customers;";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var custs = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
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


                custs.Add(cust);
            }

            return custs;
        }
       
        public Customer Create(Customer customer)
        {


            string commandString = $"Insert into Customers ([CustomerID],[CompanyName],[Country]) values ('{customer.CustomerID}','{customer.CompanyName}' , '{customer.Country}')";
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

            return a > 0 ? customer : new();
        }

        public Customer Update(Customer customer)
        {

            string commandString = $"Update Customers Set ([CustomerID]='{customer.CustomerID}',[CompanyName]='{customer.ContactName}',[Country]='{customer.Country}') Where ([CustomerID]='{customer.CustomerID}')";
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

            return a > 0 ? customer : new();
        }

    }
}
