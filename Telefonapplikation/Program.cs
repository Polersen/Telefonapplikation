namespace AddressList
{
    internal class Program
    {
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