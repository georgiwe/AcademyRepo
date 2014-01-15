using System;
using System.Text;
using System.Text.RegularExpressions;

class EncodeAndEncrypt
{
    static void Main()
    {
        string msg = Console.ReadLine();
        string cyp = Console.ReadLine();

        string encryptedMsg = Encrypt(msg, cyp);
        string encodedMsg = Encode(encryptedMsg + cyp);
        string result = encodedMsg + cyp.Length;

        Console.WriteLine(result);
    }

    static string Encrypt(string message, string cypher)
    {
        int longer = Math.Max(message.Length, cypher.Length);

        var result = new StringBuilder();

        for (int i = 0, cypInd = 0, msgInd = 0; i < longer; i++)
        {
            int msgCode;

            if (result.Length < message.Length) msgCode = message[msgInd++] - 'A';
            else msgCode = result[msgInd] - 'A';

            int cypCode = cypher[cypInd++] - 'A';

            if (result.Length < message.Length) result.Append((char)((msgCode ^ cypCode) + 65));
            else result[msgInd++] = (char)((msgCode ^ cypCode) + 65);

            if (cypInd == cypher.Length) cypInd = 0;
            if (msgInd == message.Length) msgInd = 0;
        }

        return result.ToString();
    }

    static string Encode(string message)
    {
        var result = new StringBuilder(message);
        MatchCollection matches = Regex.Matches(message, @"([A-Z])\1{2,}");

        foreach (Match match in matches)
            result.Replace(match.Value, (match.Value.Length.ToString() + match.Value[0]).PadLeft(match.Value.Length, '!'), match.Index, match.Length);

        result.Replace("!", "");

        return result.ToString();
    }
}
