using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UnderstandingADOApp
{
    class User
    {
        string password;
        public string Username { get; set; }
        public string Password { get 
            {
                string mask = password.Substring(1, 2) + "**..";
                return mask;
            }
            set { password = value; } 
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Username: " + Username
                + "\nPassword: " + password
                + "\nName: " + Name
                + "\nAge: " + Age;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Id: " + Id
                + "\nName: " + Name
                + "\nAge: " + Age;
                
        }
    }

    internal class Program
    {
        SqlConnection conn;
        SqlCommand cmdInsert, cmdUpdate, cmdSelect, cmdDelete;
        public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            //conn.Open();
            //Console.WriteLine("Connected");
        }

        public Employee GetEmployeeDetails()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter your preferred name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            employee.Age = Convert.ToInt32(Console.ReadLine());

            return employee;
        }
        public void AddEmployee()
        {
            Employee employee = GetEmployeeDetails();
            cmdInsert = new SqlCommand("proc_AddNewEmployee", conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdInsert.Parameters.AddWithValue("@name", employee.Name);//together
                cmdInsert.Parameters.AddWithValue("@age", employee.Age);
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();   
                if (result > 0)
                    Console.WriteLine("Employee is added");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not insert");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not insert-some error");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            finally
            {
                conn.Close();
            }


        }

        public void RetrieveAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            cmdSelect = new SqlCommand("proc_GetAllEmployees", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                IDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(reader[0].ToString());
                    employee.Name = reader[1].ToString();
                    employee.Age = Convert.ToInt32(reader[2].ToString());

                    employees.Add(employee);
                }
                PrintAllEmployees(employees);
            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not retrieve employees");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not select-some error");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            finally
            {
                conn.Close();
            }
        }

        public Employee GetEmployeeAgeForUpdate()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter your employee id");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your age to change to");
            employee.Age = Convert.ToInt32(Console.ReadLine());

            return employee;
        }

        public void UpdateEmployeeAge()
        {
            Employee employee = GetEmployeeAgeForUpdate();
            cmdUpdate = new SqlCommand("proc_UpdateEmployeeAge", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdUpdate.Parameters.AddWithValue("@id", employee.Id);
                cmdUpdate.Parameters.AddWithValue("@age", employee.Age);
                conn.Open();
                int result = cmdUpdate.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Employee age is updated");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not update employee age");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update-some error");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            finally
            {
                conn.Close();
            }
        }

        public Employee GetEmployeeIDToRemove()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter employee id to remove");
            employee.Id = Convert.ToInt32(Console.ReadLine());

            return employee;
        }

        public void RemoveEmployee()
        {
            Employee employee = GetEmployeeIDToRemove();
            cmdDelete = new SqlCommand("proc_RemoveEmployeeById", conn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdDelete.Parameters.AddWithValue("@id", employee.Id);
                conn.Open();
                int result = cmdDelete.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Employee has been deleted");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not delete employee");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not delete-some error");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            finally
            {
                conn.Close();
            }
        }

        User TakeUserDetailsFromConsole()
        {
            User user = new User();
            Console.WriteLine("Please enter your preferred username");
            user.Username = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter your password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Please re enter your password");
                String password = Console.ReadLine();
                if (password == user.Password)
                {
                    break;
                }
                Console.WriteLine("Password mismatch");
                Console.WriteLine("try again");
            } while (true);
            Console.WriteLine("Please enter your full name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            user.Age = Convert.ToInt32(Console.ReadLine());
            return user;
        }
        void RegisterUser()
        {
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "insert into tblUser values (@un,@pass,@name,@age)";
            cmdInsert.Connection = conn;
            User user = TakeUserDetailsFromConsole();
            try
            {
                cmdInsert.Parameters.Add("@un", SqlDbType.VarChar, 20);   //use
                cmdInsert.Parameters[0].Value = user.Username;              //together
                cmdInsert.Parameters.AddWithValue("@pass", user.Password);
                cmdInsert.Parameters.AddWithValue("@name", user.Name);
                cmdInsert.Parameters.AddWithValue("@age", user.Age);
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();   //dml is a statement, not a query
                if (result > 0)
                    Console.WriteLine("User registered");

            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not insert");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            catch(Exception se)
            {
                Console.WriteLine("Could not insert-some error");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------------------");
            }
            finally  //releasing resources put in finally block
            {
                conn.Close();
            }
        }

        public void UpdatePassword()
        {
            cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "update tblUser set password = @pass where userid = @ui";
            cmdUpdate.Connection = conn;
            User user = TakeUserId();

            cmdUpdate.Parameters.AddWithValue("@pass", user.Password);//together
            cmdUpdate.Parameters.AddWithValue("@ui", user.Username);

            conn.Open();
            int result = cmdUpdate.ExecuteNonQuery();   //dml is a statement, not a query
            if (result > 0)
                Console.WriteLine("User password is updated");
        }

        public User TakeUserId()
        {
            User u = new User();
            Console.WriteLine("Please enter your userid");
            u.Username = Console.ReadLine();
            Console.WriteLine("Please enter the password to be changed");
            u.Password = Console.ReadLine();
            return u;
        }

        void ReadUsersFromDB_Connected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUsers", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                IDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader[0].ToString();
                    user.Password = reader[1].ToString();
                    user.Name = reader[2].ToString();
                    user.Age = Convert.ToInt32(reader[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        void ReadUsersFromDB_DisConnected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUsers", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdSelect;
                adapter.Fill(ds, "myUsers");//open connection->Fetch the data->put it in the dataset-> disconnect from database
                conn.Close();
                foreach (DataRow item in ds.Tables["myUsers"].Rows)
                {
                    User user = new User();
                    user.Username = item["userid"].ToString();  //m1
                    user.Password = item[1].ToString();         //m2
                    user.Name = item[2].ToString();
                    user.Age = Convert.ToInt32(item[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {

            }
        }
        void PrintAllUSers(ICollection<User> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users added yet");
                return;
            }
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }

        void PrintAllEmployees(ICollection<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No employees added yet");
                return;
            }
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.RegisterUser();
            //program.UpdatePassword();
            //program.ReadUsersFromDB_DisConnected();
            //program.ReadUsersFromDB_Connected();

            program.RemoveEmployee();
            Console.ReadKey();
        }
    }
}
