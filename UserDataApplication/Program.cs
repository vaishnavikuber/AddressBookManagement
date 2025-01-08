using System;
using System.Collections.Generic;

namespace UserDataApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("------------User Data-------------");

            

            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Create Address Book and Add to dictionary");
            Console.WriteLine("2. Create contact and add to AddressBook");
            Console.WriteLine("3. Display Address Book");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Search persons accross state");
            
            int choice= int.Parse( Console.ReadLine());

            switch (choice)
            {
                case 1: AddressBookDictionary.AddAddressBookToDictionary();
                    break;
                case 2: Contacts.AddContact();
                    break;
                case 3: Contacts.Display();
                    break;
                case 4:
                    Console.WriteLine("Enter Your first name to Edit");
                    string fname = Console.ReadLine();

                    Console.WriteLine("Enter Your last name");
                    string lname = Console.ReadLine();
                    Contacts.EditContact(fname,lname);
                    break;
                case 5: Contacts.DeleteContact();
                    break;
                case 6:
                    Console.WriteLine("Enter the name of state");
                    string state= Console.ReadLine();
                    List<Contacts> contacts= AddressBookDictionary.SearchPersonInStateAccrossAddressBooks(state);
                    foreach(Contacts contact in contacts)
                    {
                        Console.WriteLine($"FirstName:{contact.FirstName} LastName:{contact.LastName} Address:{contact.Address} City:{contact.City} State:{contact.State} Zip:{contact.Zip} Phone number:{contact.PhoneNumber} Email:{contact.Email}");
                    }
                    break;
               
            }


            Console.WriteLine("-----------------Employee-------------------");

            //string status = Employee.CheckPresentOrAbsent();
            //Console.WriteLine(status);

            //int dailyWage = Employee.CalculateDailyEmployeeWage();
            //Console.WriteLine($"Daily Wage: {dailyWage}");

            //Employee.AddPartTimeEmployeeAndWage();

            //Employee.CalculateMonthlyWage();

            Employee.TotalWagePerDaysAndMonth();

        }
    }
}
