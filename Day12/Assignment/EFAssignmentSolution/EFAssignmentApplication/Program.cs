using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignmentApplication
{
    class Program
    {
        void manageMenu()
        {
            int choice = 0;
            do
            {
                ManageMenu manageMenu = new ManageMenu();
                Console.WriteLine("Welcome");
                Console.WriteLine("1. Add department");
                Console.WriteLine("2. Edit department name");
                Console.WriteLine("3. Print Departments");
                Console.WriteLine("4. Add employee");
                Console.WriteLine("5. Edit employee age");
                Console.WriteLine("6. Edit employee department");
                Console.WriteLine("7. Print all employees");
                Console.WriteLine("8. Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                try
                {
                    switch (choice)
                    {
                        case 1:
                            manageMenu.AddDepartment();
                            break;
                        case 2:
                            manageMenu.EditDepartmentName();
                            break;
                        case 3:
                            manageMenu.GetAllDepartments();
                            break;
                        case 4:
                            manageMenu.AddEmployee();
                            break;
                        case 5:
                            manageMenu.EditEmployeeAge();
                            break;
                        case 6:
                            manageMenu.EditEmployeeDepartment();
                            break;
                        case 7:
                            manageMenu.GetAllEmployees();
                            break;
                        case 8:
                            Console.WriteLine("bye");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, pls try again");
                            break;
                    }
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine("null mistake");
                    Console.WriteLine(nre.Message);
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine("Pizza could not be found");
                    Console.WriteLine(aore.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("expecting a number");
                    Console.WriteLine(fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("oops something went wrong");
                    Console.WriteLine(e.Message);
                }
            } while (choice != 8);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.manageMenu();

            Console.ReadKey();
        }
    }
}
