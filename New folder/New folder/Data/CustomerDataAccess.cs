using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ASP.Models;
using Microsoft.Data.SqlClient;

namespace ASP.Data
{
    public class CustomerDataAccess
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=crmdb;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<CustomerInfo> GetAllCustomers()
        {
            List<CustomerInfo> customersList = new List<CustomerInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM customers ORDER BY id DESC";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerInfo customerInfo = new CustomerInfo
                            {
                                Id = reader.GetInt32(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Email = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Address = reader.GetString(5),
                                Company = reader.GetString(6),
                                Notes = reader.GetString(7),
                                CreatedAt = reader.GetDateTime(8)
                            };

                            customersList.Add(customerInfo);
                        }
                    }
                }
            }

            return customersList;
        }

        public void CreateCustomer(CustomerInfo customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO customers (firstname, lastname, email, phone, address, company, notes, created_at) VALUES (@firstname, @lastname, @email, @phone, @address, @company, @notes, @created_at)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@firstname", customer.Firstname);
                    command.Parameters.AddWithValue("@lastname", customer.Lastname);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phone", customer.Phone ?? "");
                    command.Parameters.AddWithValue("@address", customer.Address ?? "");
                    command.Parameters.AddWithValue("@company", customer.Company);
                    command.Parameters.AddWithValue("@notes", customer.Notes ?? "");
                    command.Parameters.AddWithValue("@created_at", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM customers WHERE id=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public CustomerInfo GetCustomerById(int id)
        {
            CustomerInfo customer = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM customers WHERE id=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new CustomerInfo
                            {
                                Id = reader.GetInt32(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Email = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Address = reader.GetString(5),
                                Company = reader.GetString(6),
                                Notes = reader.GetString(7),
                                CreatedAt = reader.GetDateTime(8)
                            };
                        }
                    }
                }
            }

            return customer;
        }

        public void UpdateCustomer(CustomerInfo customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE customers SET firstname=@firstname, lastname=@lastname, email=@email, phone=@phone, address=@address, company=@company, notes=@notes WHERE id=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@firstname", customer.Firstname);
                    command.Parameters.AddWithValue("@lastname", customer.Lastname);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phone", customer.Phone ?? "");
                    command.Parameters.AddWithValue("@address", customer.Address ?? "");
                    command.Parameters.AddWithValue("@company", customer.Company);
                    command.Parameters.AddWithValue("@notes", customer.Notes ?? "");
                    command.Parameters.AddWithValue("@id", customer.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
