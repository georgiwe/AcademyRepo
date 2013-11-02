using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Randomiser
{
    static Random _random = new Random();

    static void Main()
    {
        //Get random lowercase letters.

        Console.WriteLine(GetRandom("letter"));
        Console.WriteLine(GetRandom("digit"));
        //Console.WriteLine(GetRandom("letter"));
        //Console.WriteLine(GetRandom("digit"));
        //Console.WriteLine(GetRandom("letter"));
        //Console.WriteLine(GetRandom("digit"));
        //Console.WriteLine(GetRandom("letter"));
        //Console.WriteLine(GetRandom("digit"));

        Console.WriteLine("\n");

        // Get random uppercase letters

        Console.WriteLine(GetRandom("letter").ToUpper());
        Console.WriteLine(GetRandom("letter").ToUpper());
        //Console.WriteLine(GetRandom("letter").ToUpper());
        //Console.WriteLine(GetRandom("letter").ToUpper());
        //Console.WriteLine(GetRandom("letter").ToUpper());

        Console.WriteLine("\n");

        // Generate random IBANS

        Console.WriteLine(GetRandomIBAN());
        Console.WriteLine(GetRandomIBAN());
        Console.WriteLine(GetRandomIBAN());
        //Console.WriteLine(GetRandomIBAN());
        //Console.WriteLine(GetRandomIBAN());
        //Console.WriteLine(GetRandomIBAN());

        Console.WriteLine("\n");

    }
    public static string GetRandom(string input)
    {
        string result;

        if (input == "digit") 
        {
            result = _random.Next(0, 10).ToString(); 
        }
        else if (input == "letter")
        {
            int numA = _random.Next(0, 26); // Zero to 25
            result = ((char)('a' + numA)).ToString();
        }
        else { result = "Wrong parameter"; }

        return result;
    }

    public static string GetRandomIBAN()
    {
        string result = "BG " + GetRandom("digit") + GetRandom("digit") + " " +
            GetRandom("letter").ToUpper() + GetRandom("letter").ToUpper() +
            GetRandom("letter").ToUpper() + GetRandom("letter").ToUpper() + " " +
            GetRandom("digit") + GetRandom("digit") + GetRandom("digit") + 
            GetRandom("digit") + " ";

        for (int i = 0; i < 4; i++)
        {
            result += GetRandom("digit");
        }

        result += " ";

        for (int i = 0; i < 4; i++)
        {
            result += GetRandom("digit");
        }

        result += " " + GetRandom("digit") + GetRandom("digit");

        return result;
    }

}
