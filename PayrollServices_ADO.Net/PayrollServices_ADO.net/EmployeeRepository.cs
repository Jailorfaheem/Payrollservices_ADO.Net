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
        //creating object of sqlconnection class
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}