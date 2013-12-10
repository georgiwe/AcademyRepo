// Write a program that finds the maximal sequence of equal elements in an array

using System;
using System.Collections.Generic;

class MaxSequence
{
    static void Main()
    {
        // I'll do it with strings. Fo sho!
        string[] anArray = new string[]
        {
            "one", "two", "two", "two", "threesome",
            "one", "more", "threesome", "more", "eight and three quarters", 
            "eight and three quarters", "eight and three quarters"
        };

        int maxLength = 1; // the maximum length sequence
        List<string> sequenceMembers = new List<string>(); // will contain all the sequence members that have 
                                                           // the same length, if it's the maximum length
        int sequenceLengthCounter = 1; // the counter for the current sequence length
        string maxLengthSeqMember = ""; // the first maximum length sequence member

        for (int i = 0; i < anArray.Length - 1; i++)
        {
            if (anArray[i] == anArray[i + 1]) sequenceLengthCounter++; // iff current sequence increases
            else sequenceLengthCounter = 1; // if the sequence ends

            if (sequenceLengthCounter > maxLength) // checks if the current sequence length is the longest yet
            {
                maxLength = sequenceLengthCounter;
                maxLengthSeqMember = anArray[i]; // "remembers" the member
            }
        }

        sequenceMembers.Add(maxLengthSeqMember); // adds the first found maximum sequence member to the list

        for (int i = 0; i < anArray.Length - 1; i++) // looks for more sequences of other members, with the sam length as the max
        {
            if (anArray[i] == anArray[i + 1]) sequenceLengthCounter++;
            else sequenceLengthCounter = 1;

            if (sequenceLengthCounter == maxLength && sequenceMembers.Contains(anArray[i]) == false) 
                sequenceMembers.Add(anArray[i]); // if a new sequence of the same length as the max is found,
        }                                        // adds the new member to the list, if not present already.

        // creates an array (dunno if that was necessary) and prints it for each max length sequence
        for (int i = 0; i < sequenceMembers.Count; i++)
        {
            string[] resultArray = new string[maxLength];

            Console.Write("\n{");
            for (int j = 0; j < maxLength; j++)
            {
                resultArray[j] = sequenceMembers[i];
                Console.Write("{0}, ", resultArray[j]);
            }
            Console.WriteLine("\b\b}  \n"); // \b stands for backspace - I use it to delete the ", " after the last member
        }
    }
}
