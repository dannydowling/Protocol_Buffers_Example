using Google.Protobuf.Examples.AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol_Buffers_Example
{
    internal class ListPeople
    {
        /// <summary>
        /// Iterates though all people in the AddressBook and prints info about them.
        /// </summary>
        private static void Print(AddressBook addressBook)
        {
            foreach (Person person in addressBook.People)
            {
                Console.WriteLine("Person ID: {0}", person.Id);
                Console.WriteLine("  Name: {0}", person.Name);
                if (person.Email != "")
                {
                    Console.WriteLine("  E-mail address: {0}", person.Email);
                }

                foreach (Person.Types.PhoneNumber phoneNumber in person.Phones)
                {
                    switch (phoneNumber.Type)
                    {
                        case Person.Types.PhoneType.Mobile:
                            Console.Write("  Mobile phone #: ");
                            break;
                        case Person.Types.PhoneType.Home:
                            Console.Write("  Home phone #: ");
                            break;
                        case Person.Types.PhoneType.Work:
                            Console.Write("  Work phone #: ");
                            break;
                    }
                    Console.WriteLine(phoneNumber.Number);
                }
            }
        }

        /// <summary>
        /// Entry point - loads the addressbook and then displays it.
        /// </summary>
        public static int List(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage:  ListPeople ADDRESS_BOOK_FILE");
                return 1;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("{0} doesn't exist. Add a person to create the file first.", args[0]);
                return 0;
            }

            // Read the existing address book.
            using (Stream stream = File.OpenRead(args[0]))
            {
                AddressBook addressBook = AddressBook.Parser.ParseFrom(stream);
                Print(addressBook);
            }
            return 0;
        }
    }
}
