using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace PayrollService_ADO.Net
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = payroll_services;";
        //creating object of sqlconnection class and passing connectionstring
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //This method for retrieve all employee data from database
        public void GetAllEmployeeDetails()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                string query = @"select * from employee_payroll;";         //query for fetching the data from database                
                SqlCommand command = new SqlCommand(query, sqlConnection); //command object to execute query on given database
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();            //returning as rows

                if (reader.HasRows)                              //condition to check rows present or not in selected database
                {
                    //if rows are present then read the rows 
                    while (reader.Read())
                    {
                        model.EmployeeId = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                        model.EmployeeName = Convert.ToString(reader["Name"] == DBNull.Value ? default : reader["Name"]);
                        model.Salary = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                        model.StartDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default : reader["StartDate"]);
                        model.Gender = Convert.ToString(reader["Gender"] == DBNull.Value ? default : reader["Gender"]);
                        model.PhoneNumber = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        model.Address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
                        model.Department = Convert.ToString(reader["Department"] == DBNull.Value ? default : reader["Department"]);
                        model.TaxablePay = Convert.ToDouble(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                        model.IncomeTax = Convert.ToDouble(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                        model.NetPay = Convert.ToDouble(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", model.EmployeeId, model.EmployeeName, model.Salary, model.StartDate, model.Gender, model.PhoneNumber, model.Address, model.TaxablePay, model.IncomeTax, model.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No rows present");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //This method for update data of employee payroll
        public int UpdateSalaryQuery()
        {
            sqlConnection.Open();
            string query = "update employee_payroll set BasicPay=3000000 where Name= 'pooja'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();
            if (result != 0)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Not updated");
            }
            sqlConnection.Close();
            return result;
        }
    }

}/////////