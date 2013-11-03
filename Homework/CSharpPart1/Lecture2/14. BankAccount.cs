using System;
using System.Threading;

class BankAccount
{
    static void Main()
    {
        /*
        Abank account has a holder name (first name, middle name and last name), 
        available amount of money (balance), bank name, IBAN, BIC code and 3 credit 
        card numbers associated with the account. Declare the variables needed to keep 
        the information for a single bank account using the appropriate data types and 
        descriptive names.
        */

        Console.CursorVisible = false;
        Console.WriteLine(
            "Welcome to the account creation tool!\nPlease only enter correct data, it's no fun otherwise...");

        Console.WriteLine();
        Console.WriteLine("Press <Enter> to continue...");
        Console.WriteLine();
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Generating forms. Please wait...");

        Thread.Sleep(4000);
        Console.Clear();

        Console.CursorVisible = true;

        Console.Write("Enter your first name: ");
        string holderFirstName = Console.ReadLine();
        holderFirstName = holderFirstName[0].ToString().ToUpper() + holderFirstName.Substring(1).ToLower();

        Console.Clear();

        Console.Write("Enter your middle name: ");
        string holderMiddleName = Console.ReadLine();
        holderMiddleName = holderMiddleName[0].ToString().ToUpper() + holderMiddleName.Substring(1).ToLower();

        Console.Clear();

        Console.Write("Enter your last name: ");
        string holderLastName = Console.ReadLine();
        holderLastName = holderLastName[0].ToString().ToUpper() + holderLastName.Substring(1).ToLower();

        Console.Clear();

        Console.Write("Enter desired deposit amount: ");
        decimal depositAmount = decimal.Parse(Console.ReadLine());

        Console.Clear();

        Console.Write("Enter the name of the desired bank: ");
        string desiredBank = Console.ReadLine().ToUpper();

        Console.Clear();
        Console.CursorVisible = false;

        for (int i = 1; i < 5; i++)
        {
            Thread.Sleep(585);
            Console.WriteLine("Creating account. Please wait" + new string('.', i));
            Thread.Sleep(1700);
            Console.Clear();
        }

        Console.WriteLine("Your account has been created!");
        Console.WriteLine();
        Console.WriteLine(@"There are 3 (three) credit card numbers, associated with your account.



Please press <Enter> to view them and the data you submitted.");
        Console.ReadLine();
        Console.Clear();
        Thread.Sleep(2000);

        Console.WriteLine("Account holder:\t\t\t{0} {1} {2}", 
            holderFirstName, holderMiddleName, holderLastName);
        Thread.Sleep(1500);
        Console.WriteLine("Bank, servicing the account:\t{0}", desiredBank);
        Thread.Sleep(1500);
        Console.WriteLine("Deposit amount:\t\t\t{0:C}", depositAmount);
        Console.WriteLine();

        Thread.Sleep(2800);

        Random rnd = new Random();
        Console.WriteLine("Your International Bank Account Number: \tBG {0} {1}{2}{3}{4} {5} {6} {7} {8}", 
            rnd.Next(11, 99), (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), 
            (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), rnd.Next(1111, 9999), 
            rnd.Next(1111, 9999), rnd.Next(1111, 9999), rnd.Next(11, 99));

        Thread.Sleep(2000);

        Console.WriteLine("Bank's BIC code:\t\t\t\t{0}{1}{2}{3}{4}{5}{6}{7}", (char)rnd.Next(65, 90), 
            (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), 
            (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), (char)rnd.Next(65, 90), 
            (char)rnd.Next(65, 90));

        Console.WriteLine();

        Thread.Sleep(2000);

        Console.WriteLine("Associated credit card 1:\t\t\t{0} {1} {2} {3}", rnd.Next(1111, 9999),
            rnd.Next(1111, 9999), rnd.Next(1111, 9999), rnd.Next(1111, 9999));
        Thread.Sleep(1500);                           
        Console.WriteLine("Associated credit card 2:\t\t\t{0} {1} {2} {3}", rnd.Next(1111, 9999),
            rnd.Next(1111, 9999), rnd.Next(1111, 9999), rnd.Next(1111, 9999));
        Thread.Sleep(1500);                           
        Console.WriteLine("Associated credit card 3:\t\t\t{0} {1} {2} {3}", rnd.Next(1111, 9999),
            rnd.Next(1111, 9999), rnd.Next(1111, 9999), rnd.Next(1111, 9999));

        Thread.Sleep(2000);
        Console.WriteLine();
    }
}
