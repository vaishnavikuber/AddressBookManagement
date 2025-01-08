using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserDataApplication
{
    internal class Employee
    {
        [RegularExpression("^[0-9]{3}")]
        [Required(ErrorMessage ="Employee id is required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [RegularExpression("^[A-Z][a-z]{2,50}",ErrorMessage ="name should have minimum 3 and maximum 50 characters")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee designation is required")]
        public string Designation {  get; set; }

        [Required(ErrorMessage = "Employee email is required")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{10}", ErrorMessage ="phone number should have 10 digits")]
        public string PhoneNumber { get; set; }

        public int Wage { get; set; }

        public static List<Employee> PartTimeEmployee = new List<Employee>();

        public static string CheckPresentOrAbsent()
        {
            Random random = new Random();
            int res= random.Next(0,2);
            if(res == 0)
            {
                return "absent";
            }
            else
            {
                return "present";
            }
        }

        public static int WagePerHour = 20;
        public static int FullDayHour = 8;
        public static int partTimeHour = 8;

        public static int CalculateDailyEmployeeWage()
        {
            

            if (CheckPresentOrAbsent() == "present")
            {
                int DailyEmployeeWage = WagePerHour * FullDayHour;

                return DailyEmployeeWage;
            }
            else
            {
                return 0;
            }

        }

        public static void AddPartTimeEmployeeAndWage()
        {
            

            if(CheckPresentOrAbsent() == "present")
            {

                Console.WriteLine("Enter Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("enter designation: ");
                string designation = Console.ReadLine();

                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();

                int wage = partTimeHour * 20;

                Employee employee = new Employee
                {
                    EmployeeId = id,
                    EmployeeName = name,
                    Designation = designation,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Wage = wage
                };

                PartTimeEmployee.Add(employee);

                Console.WriteLine("Your Data added successfully");


            }
            else
            {
                Console.WriteLine("Employee is absent");
            }

            
        }


        public static void UsingSwitchCases()
        {
            Random random = new Random();
            int attendence=random.Next(0,2);
            switch (attendence)
            {
                case 0:
                    Console.WriteLine("employee is absent");
                    break;
                case 1:
                    Console.WriteLine("Employee is present");
                    
                    int DailyEmployeeWage = WagePerHour * FullDayHour;

                    Console.WriteLine("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("enter designation: ");
                    string designation = Console.ReadLine();

                    Console.WriteLine("Enter Email: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Phone Number: ");
                    string phoneNumber = Console.ReadLine();
                    
                    int wage = partTimeHour * 20;

                    Employee employee = new Employee
                    {
                        EmployeeId = id,
                        EmployeeName = name,
                        Designation = designation,
                        Email = email,
                        PhoneNumber = phoneNumber,
                        Wage = wage
                    };

                    PartTimeEmployee.Add(employee);

                    Console.WriteLine("Your Data added successfully");

                    break;
                default:
                    Console.WriteLine("You are not an employee ");
                    break;
            }
        }


        public static void CalculateMonthlyWage()
        {
            int WorkingDays = 20;
            int MonthWage = CalculateDailyEmployeeWage() * WorkingDays;
            Console.WriteLine($"Wages for a month: {MonthWage}");
        }

        public static void TotalWagePerDaysAndMonth()
        {
            int Days = 20;
            int Hours = 100;

            int TotalWageForDays = 0;
            int TotalWageForHours = 0;

            while(Days>0)
            {
                TotalWageForDays = TotalWageForDays +( FullDayHour*WagePerHour);
                Days--;
                
            }
            while (Hours > 0)
            {
                TotalWageForHours = TotalWageForHours + WagePerHour;
                Hours--;
            }

            Console.WriteLine($"Total Wage for 20 days : {TotalWageForDays}");
            Console.WriteLine($"Total Wage for 100 hours : {TotalWageForHours}");
        }



    }
}
