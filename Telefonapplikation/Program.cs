namespace AddressList
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }

            public Person(string name, string phone, string address)
            {
                this.Name = name;
                this.Phone = phone;
                this.Address = address;
            }

            public void Print()
            {
                Console.WriteLine($"Namn: {this.Name}\n" +
                                  $"Telefonnummer: {this.Phone}\n" +
                                  $"Address: {this.Address}");
            }
        }

        public static List<Person> personList = new List<Person>(); //Eventuellt ändra till private senare

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the address list.");
            Console.WriteLine("Type 'help' for assistance!");
            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command == "help")
                {
                    Console.WriteLine("Sorry, not implemented!");
                }
                else if (command == "load")
                {
                    // Loadgrenen: här lägg in kod
                    // hej hej hej hej hej
                }
                else if (command == "exit")
                {

                }
                else
                {
                    Console.WriteLine($"Unknown command: {command}");
                }
            } while (command != "exit");
            Console.WriteLine("Goodbye!");
        }
    }
}