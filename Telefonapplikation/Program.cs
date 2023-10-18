//Version 4
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                Console.WriteLine($"Name: {this.Name}\n" +
                                  $"Phone Number: {this.Phone}\n" +
                                  $"Address: {this.Address}\n");
            }
        }

        public static List<Person> personList = new List<Person>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the address list.");
            Console.WriteLine("Type 'help' for assistance!");

            string userProfilePath = Environment.GetEnvironmentVariable("USERPROFILE");
            string filePath = Path.Combine(userProfilePath, "Documents", "adresser.txt");

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
                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        foreach (var line in lines)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3)
                            {
                                personList.Add(new Person(parts[0], parts[1], parts[2]));
                            }
                        }
                        Console.WriteLine($"Loaded {lines.Length} entries from {filePath}");
                    }
                    else
                    {
                        Console.WriteLine($"File {filePath} does not exist!");
                    }
                }
                else if (command == "list")
                {
                    foreach (var person in personList)
                    {
                        person.Print();
                    }
                }
                else if (command == "add")
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    string address = Console.ReadLine();
                    Person newPerson = new Person(name, phone, address);
                    personList.Add(newPerson);
                }
                else if (command == "save")
                {
                    string[] lines = personList.Select(p => $"{p.Name},{p.Phone},{p.Address}").ToArray();
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine($"Saved {lines.Length} entries to {filePath}");
                }
                else if (command == "delete")
                {
                    Console.Write("Enter the name of the person you want to delete: ");
                    string nameToDelete = Console.ReadLine();
                    var personToDelete = personList.FirstOrDefault(p => p.Name == nameToDelete);

                    if (personToDelete != null)
                    {
                        personList.Remove(personToDelete);
                        Console.WriteLine($"{nameToDelete} has been deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"No person named {nameToDelete} found.");
                    }
                }
                else if (command == "exit")
                {
                    // exit
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
