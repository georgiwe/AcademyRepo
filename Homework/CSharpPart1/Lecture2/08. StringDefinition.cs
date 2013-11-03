using System;

class StringDefinition
{
    static void Main()
    {
        string oneWay = "The \"use\" of quotations carries difficulties.";

        string anotherWay = @"The ""use"" of quotations carries difficulties.";

        string thirdWay = "The use of quotations carries difficulties.";

        Console.WriteLine(oneWay);
        Console.WriteLine(anotherWay);
        Console.WriteLine(thirdWay);
    }
}
