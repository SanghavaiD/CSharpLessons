using Microsoft.Data.SqlClient;
using System.Data;

namespace MyFirstMCPApp.Models
{
    public class EmpDbRepository
    {
        public static List<Employee> GetEmpList()
        {
            List<Employee> employeelist = new List<Employee>();
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand selectemployeecmd = cn.CreateCommand();
                String selectAllEmployee = "Select*from emptbl";
                selectemployeecmd.CommandText = selectAllEmployee;
                SqlDataReader employeedr = selectemployeecmd.ExecuteReader();
                while (employeedr.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = employeedr.GetInt32(0),
                        Name = employeedr.GetString(1),
                        Salary = employeedr.GetDecimal(2),
                        City = employeedr.GetString(3),
                    };
                    employeelist.Add(employee);
                }
            }
            return employeelist;

        }
        public static Employee GetEmpById(int id)
        {
            Employee empfound = null;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand selectemployeecmd = cn.CreateCommand();
                String selectionEmps = "Select*from emptbl where eno=@id";   //Parameter
                selectemployeecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                selectemployeecmd.CommandText = selectionEmps;
                SqlDataReader employeedr = selectemployeecmd.ExecuteReader();
                while (employeedr.Read())
                {
                    empfound = new Employee
                    {
                        Id = employeedr.GetInt32(0),
                        Name = employeedr.GetString(1),
                        Salary = employeedr.GetDecimal(2),
                        City = employeedr.GetString(3),
                    };

                }

                return empfound;
            }
            
        }
        public static int AddNewEmp(Employee newEmp)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand insertEmpcmd = cn.CreateCommand();
                String insertNewEmpQuery = "insert into emptbl values( @id,@name,@salary,@city )";
                insertEmpcmd.Parameters.Add("@id", SqlDbType.Int).Value = newEmp.Id;
                insertEmpcmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = newEmp.Name;
                insertEmpcmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = newEmp.Salary;
                insertEmpcmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = newEmp.City;

                insertEmpcmd.CommandText = insertNewEmpQuery;
                query_result = insertEmpcmd.ExecuteNonQuery();
            }
            return query_result;
        }
        public static int UpdateEmployee(Employee modifiedEmployee)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand updateEmpcmd = cn.CreateCommand();
                String updateEmpQuery = "Update emptbl set name=@name, salary=@salary, city=@city where eno=@id";
                updateEmpcmd.Parameters.Add("@id", SqlDbType.Int).Value = modifiedEmployee.Id;
                updateEmpcmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = modifiedEmployee.Name;
                updateEmpcmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = modifiedEmployee.City;
                updateEmpcmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = modifiedEmployee.Salary;
                updateEmpcmd.CommandText = updateEmpQuery;
                query_result = updateEmpcmd.ExecuteNonQuery();
            }
            return query_result;
        }
        public static int DeleteEmployee(int id)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand deleteEmpcmd = cn.CreateCommand();
                String deleteEmpQuery = "Delete from emptbl where eno=@id";
                deleteEmpcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                deleteEmpcmd.CommandText = deleteEmpQuery;
                query_result = deleteEmpcmd.ExecuteNonQuery();
            }
            return query_result;
        }
    }
}
