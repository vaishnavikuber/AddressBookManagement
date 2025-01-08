using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using CsvHelper;
using Newtonsoft.Json;

namespace UserDataApplication
{
    public class Contacts
    {
        [Required(ErrorMessage ="First Name is Mandetory")]
        [StringLength(15,MinimumLength =3,ErrorMessage ="First name should have minimum 3 and max 15 characters")]
        public string FirstName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last name should have minimum 3 and max 15 characters")]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [RegularExpression("^[0-9]{5,6}", ErrorMessage = "Phone number should be 10 numbers")]
        public string Zip {  get; set; }

        [RegularExpression("^[0-9]{10}",ErrorMessage ="Phone number should be 10 numbers")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string Email {  get; set; }

        public static List<Contacts> AddressBook = new List<Contacts>();

        public static Dictionary<string, string> cityPerson = new Dictionary<string, string>();

        public static Dictionary<string, string> statePerson = new Dictionary<string, string>();
        public static Contacts CreateContact()
        {
            Console.WriteLine("Enter First Name: ");
            string fname = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State: ");
            string state = Console.ReadLine();

            Console.WriteLine("Enter ZipCode: ");
            string zip = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            Contacts contacts = new Contacts
            {
                FirstName = fname,
                LastName = lname,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phone,
                Email = email
            };

          
            var Context= new ValidationContext(contacts);
            var Errors = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(contacts, Context, Errors, true);


            return contacts;
           
        }

        public override bool Equals(object obj)
        {
            Contacts cobj = (Contacts)obj;
            var name = AddressBook.FindAll(x => x.FirstName == cobj.FirstName && x.LastName == cobj.LastName);
            if (name == null)
            {
                return false;
            }
            return true;
        }

        public static void AddContact()
        {
            
            Contacts contact = CreateContact();
           
            if (AddressBook.Equals(contact))
            {
                Console.WriteLine("The record is duplicated");
            }
            else
            {              
                AddressBook.Add(contact);
                cityPerson.Add(contact.City, contact.FirstName);
                statePerson.Add(contact.State, contact.FirstName);
                Console.WriteLine("Your Contact is created and added to address book");
                
            }
           
        }

        public static void EditContact(string fname,string lname)
        {
            
 
                    Console.WriteLine("Your datails: ");
                    var contactToEdit = AddressBook.First(x => x.FirstName == fname && x.LastName == lname);
                     
                        Console.WriteLine("Enter the field to edit: \n 1.Address \n 2.City \n 3. State \n 4. Zip\n 5. phone number\n 6.email");
                        int choice= int.Parse(Console.ReadLine());
                        switch(choice)
                        {
                            case 1: Console.WriteLine("Enter address to update");
                                contactToEdit.Address= Console.ReadLine();
                                break;

                            case 2:
                                Console.WriteLine("Enter city to update");
                                contactToEdit.City = Console.ReadLine();
                                break;

                            case 3:
                                Console.WriteLine("Enter state to update");
                                contactToEdit.State = Console.ReadLine();
                                break;

                            case 4:
                                Console.WriteLine("Enter zip to update");
                                contactToEdit.Zip = Console.ReadLine();
                                break;

                            case 5:
                                Console.WriteLine("Enter phone number to update");
                                contactToEdit.PhoneNumber = Console.ReadLine();
                                break;

                            case 6:
                                Console.WriteLine("Enter email to update");
                                contactToEdit.Email = Console.ReadLine();
                                break;
                            default: Console.WriteLine("enter valid choice");
                                break;
                        }

                        

                    

                    Console.WriteLine("Your data is updated");
                

            
        }


        public static void DeleteContact()
        {
            Console.WriteLine("Enter Your first name to Edit");
            string fname = Console.ReadLine();

            Console.WriteLine("Enter Your last name");
            string lname = Console.ReadLine();

            var contactToDelete = Contacts.AddressBook.Where(x => x.FirstName == fname && x.LastName == lname);

            AddressBook.Remove((Contacts)contactToDelete);
        }


        public static void Display()
        {
            foreach(Contacts contact in AddressBook)
            {
                Console.WriteLine($"FirstName: {contact.FirstName} LastName: {contact.LastName} Address: {contact.Address} City: {contact.City} State: {contact.State} Zip: {contact.Zip} Phone Number: {contact.PhoneNumber} Email: {contact.Email}");
            }
        }

        public void CountPersonsByCityOrState()
        {
            Console.WriteLine($"The count of persons in cities : {cityPerson.Count}");
            Console.WriteLine($"The count of persons in states : {statePerson.Count}");
        }

        public static void WriteToTxtFile(List<Contacts> contacts)
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.txt";
            if (File.Exists(filePath))
            {
                
                foreach(Contacts contact in contacts)
                {

                    string record = $"{contact.FirstName }, {contact.LastName}, {contact.Address}, {contact.City}, {contact.State}, {contact.Zip}, {contact.PhoneNumber}";
                    File.AppendAllText(filePath, record);
                }
                Console.WriteLine("Written data successfully into file");
            }
            else
            {
                File.Create(filePath);
                Console.WriteLine("File not exists ,so created new file");
            }
        }

        public static void ReadFromTxtFile()
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.txt";
            if (File.Exists(filePath))
            {

                File.ReadAllText(filePath);
            }
            else
            {
                
                Console.WriteLine("File not exists to read");
            }
        }

        public static void WriteToJsonFile(List<Contacts> contacts)
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.json";
            if (File.Exists(filePath))
            {
                string jsonData=JsonConvert.SerializeObject(contacts,Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine("Written data successfully into file");
            }
            else
            {
                File.Create(filePath);
                Console.WriteLine("File not exists ,so created new file");
            }
        }

        public static void ReadFromJsonFile()
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.json";
            if(File.Exists(filePath))
            {
                string jsonRead= File.ReadAllText(filePath);
                var jsonData = JsonConvert.DeserializeObject<List<Contacts>>(jsonRead);
                foreach(Contacts contact in jsonData)
                {
                    File.Create(filePath);
                    Console.WriteLine($"FirstName: {contact.FirstName} LastName: {contact.LastName} Address: {contact.Address} City: {contact.City} State: {contact.State} Zip: {contact.Zip} Phone Number: {contact.PhoneNumber} Email: {contact.Email}");
                }
            }
            else
            {
                Console.WriteLine("File does not exists to read");
            }
        }

        public static void WriteToCsvFile(List<Contacts> contacts)
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.csv";
            if (File.Exists(filePath))
            {

                using(var writer=new StreamWriter(filePath))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(contacts);
                }
                    Console.WriteLine("Written data successfully into file");
            }
            else
            {
                File.Create(filePath);
                Console.WriteLine("File not exists ,so created new file");
            }
        }

        public static void ReadFromCsvFile()
        {
            string filePath = @"C:\Users\vaish\source\repos\UserDataApplication\UserDataApplication\Contacts.csv";
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                using(var csvReader=new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csvReader.GetRecords<Contacts>();
                    foreach(var contact in data)
                    {
                        Console.WriteLine($"FirstName: {contact.FirstName} LastName: {contact.LastName} Address: {contact.Address} City: {contact.City} State: {contact.State} Zip: {contact.Zip} Phone Number: {contact.PhoneNumber} Email: {contact.Email}");

                    }
                }

                    
            }
            else
            {
                Console.WriteLine("File not exists to read");
            }
        }
        
        

       



        













    }
}
