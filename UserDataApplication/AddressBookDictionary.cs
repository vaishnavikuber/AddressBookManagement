using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserDataApplication
{
    internal class AddressBookDictionary : Contacts
    {

        public static Dictionary<string, List<Contacts>> AddressBookName = new Dictionary<string, List<Contacts>>();

        public static Dictionary<string,List<Contacts>> AddAddressBookToDictionary()
        {
            Console.WriteLine("Enter name of address book to add to dictionary");
            string name = Console.ReadLine();
            if (AddressBookName.ContainsKey(name))
            {
                Console.WriteLine($"Address book with name '{name}' already exists.");
                return null;
            }
            else
            {
                Console.WriteLine($"Created address book with name '{name}'");
                List<Contacts> addressBook = new List<Contacts>();
                AddressBookName.Add(name, addressBook);
                Console.WriteLine("Address Book added to dictionary successfully!!");
                return AddressBookName;
            }
           
            
        }


        public static List<Contacts> SearchPersonInStateAccrossAddressBooks(string state)
        {
            List<Contacts> contacts = null;
            foreach (var addressBook in AddressBookName)
            {
                contacts = AddressBook.FindAll(x => x.State == state);
                
            }
            return contacts;

        }

        public static void SortAddressBookByName(List<Contacts> addressBook)
        {

            addressBook.Sort((a1,a2)=>a1.FirstName.CompareTo(a2.FirstName));
            
            foreach (var contact in addressBook)
            {
                Console.WriteLine($"{contact.ToString()}");
            }
        }

        public override string ToString()
        {
            return $"First Name:{this.FirstName} Last Name:{this.LastName} Address: {this.Address} City: {this.City} State: {this.State} Zip: {this.Zip} Phone Number: {this.PhoneNumber} Email: {this.Email}";
        }

        public static void SortAddressBookByCity(List<Contacts> addressBook)
        {

            addressBook.Sort((a1, a2) => a1.City.CompareTo(a2.City));

            foreach (var contact in addressBook)
            {
                Console.WriteLine($"{contact.ToString()}");
            }
        }

        public static void SortAddressBookByState(List<Contacts> addressBook)
        {

            addressBook.Sort((a1, a2) => a1.State.CompareTo(a2.State));

            foreach (var contact in addressBook)
            {
                Console.WriteLine($"{contact.ToString()}");
            }
        }

        public static void SortAddressBookByZip(List<Contacts> addressBook)
        {

            addressBook.Sort((a1, a2) => a1.Zip.CompareTo(a2.Zip));

            foreach (var contact in addressBook)
            {
                Console.WriteLine($"{contact.ToString()}");
            }
        }


    }
}
