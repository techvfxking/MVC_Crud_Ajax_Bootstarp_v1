using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVC_Crud_Ajax_Bootstarp_v1.Models
{
    public class EmployeeDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public List<Employee> GetList()
        {
            List<Employee> employees = new List<Employee>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SelectEmployee", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        ID = Convert.ToInt32(reader[nameof(Employee.ID)]),
                        Name = reader[nameof(Employee.Name)].ToString(),
                        Age = Convert.ToInt32(reader[nameof(Employee.Age)]),
                        Country = reader[nameof(Employee.Country)].ToString(),
                        State = reader[nameof(Employee.State)].ToString()
                    };

                    employees.Add(employee);
                }
            }
            return employees;
        }

        public int Add(Employee employee)
        {

            if (employee != null)
            {
                int i;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("InsertUpdateEmployee", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@ID", employee.ID);
                    sqlCommand.Parameters.AddWithValue("@Age", employee.Age);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@Country", employee.Country);
                    sqlCommand.Parameters.AddWithValue("@State", employee.State);

                    sqlCommand.Parameters.AddWithValue("@Action", "Insert");

                    i = sqlCommand.ExecuteNonQuery();
                }
                return i;
            }
            else
                return 404;
           
        }

        public int Update(Employee employee)
        {

            if (employee != null)
            {
                int i;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("InsertUpdateEmployee", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@ID", employee.ID);
                    sqlCommand.Parameters.AddWithValue("@Age", employee.Age);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@Country", employee.Country);
                    sqlCommand.Parameters.AddWithValue("@State", employee.State);

                    sqlCommand.Parameters.AddWithValue("@Action", "Update");

                    i = sqlCommand.ExecuteNonQuery();
                }
                return i;
            }
            else
                return 404;

        }

        public int Delete(int id)
        {
            if (id > 0)
            {
                int i;
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DeleteEmployee", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    i = sqlCommand.ExecuteNonQuery();
                }
                return i;
            }
            else
                return 404;
        }
    }
}