using System;

namespace PayrollService_ADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            //employeeRepository.GetAllEmployeeDetails();
            employeeRepository.UpdateSalaryQuery();
        }
    }
}