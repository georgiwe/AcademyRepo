using System;

class EmployeeRecord
{
    static void Main()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        firstName = firstName[0].ToString().ToUpper() + firstName.Substring(1).ToLower();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        lastName = lastName[0].ToString().ToUpper() + lastName.Substring(1).ToLower();

        Console.Write("Enter age: ");
        ushort age = ushort.Parse(Console.ReadLine());

        Console.Write("Enter gender: ");
        char gender = (char)Console.Read();

        Console.Write("Enter ID number: ");
        string idNumber = Console.ReadLine();
    }
}
