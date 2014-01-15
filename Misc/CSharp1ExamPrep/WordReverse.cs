using System;
using System.Text;


class TestArea
{
    static void Main(string[] args)
    {
        Console.WriteLine(ReverseWords("Ugliest code ever writen by me"));
    }



    static string ReverseWords(string input)
    {
        input = input + " ";

        int wordCount = 0;


        foreach (var character in input)
        {
            if (character == ' ')
            {
                wordCount++;
            }
        }

        string[] strArray = new string[wordCount];
        int indexOfArray = wordCount - 1;

        foreach (var character in input)
        {
            if (character != ' ')
                strArray[indexOfArray] += character;
            else indexOfArray--;
        }

        string result = "";

        for (int i = 0; i < wordCount; i++)
        {
            if (i == wordCount - 1) result += strArray[i];
            else result += strArray[i] + " ";
        }

        return result;
    }
}
