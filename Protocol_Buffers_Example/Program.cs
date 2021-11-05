using Google.Protobuf;
using Protocol_Buffers_Example;

//to make things work, first make a .proto file with the entries you need.
//then find the protoc.exe compiler in the tools folder of the imported tools package in this project.
//copy the proto file to the same folder as the compiler
//then run protoc --chsarp_out=./ *.proto 
//you should now have a new .cs file generated in the folder to copy to the project, which contains concrete classes.

if (args.Length > 1)
            {
                Console.Error.WriteLine("Usage: AddressBook [file]");
                Console.Error.WriteLine("If the filename isn't specified, \"addressbook.data\" is used instead.");
                return 1;
            }
            string addressBookFile = args.Length > 0 ? args[0] : "addressbook.data";

            bool stopping = false;
            while (!stopping)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("  L: List contents");
                Console.WriteLine("  A: Add new person");
                Console.WriteLine("  Q: Quit");
                Console.Write("Action? ");
                Console.Out.Flush();
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case 'A':
                        case 'a':
                            AddPerson.Add(new string[] { addressBookFile });
                            break;
                        case 'L':
                        case 'l':
                            ListPeople.List(new string[] { addressBookFile });
                            break;
                        case 'Q':
                        case 'q':
                            stopping = true;
                            break;
                        default:
                            Console.WriteLine("Unknown option: {0}", choice);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception executing action: {0}", e);
                }
                Console.WriteLine();
            }
            return 0;
     

