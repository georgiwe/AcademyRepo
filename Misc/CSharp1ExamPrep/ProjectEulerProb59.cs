using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string cypher = string.Empty;
        string text = string.Empty;

        text = File.ReadAllText("text.txt");

        MatchCollection matches = Regex.Matches(text, @"\d+");
        int[] nums = new int[matches.Count];

        for (int i = 0; i < matches.Count; i++) nums[i] = int.Parse(matches[i].Value);

        using (StreamReader reader = new StreamReader(@"textCypher.txt"))
        {
            cypher = reader.ReadLine();

            while (cypher != null)
            {
                string decryptedText = EncryptDecrypt(nums, cypher);

                if (Regex.IsMatch(decryptedText, @"\bgive\b|\byou\b|\bmake\b|\bknow\b|\bthat\b|\bhave\b", RegexOptions.IgnoreCase))
                {
                    using (StreamWriter writer = new StreamWriter("out.txt", true))
                    {
                        writer.WriteLine(decryptedText);
                        writer.WriteLine(new string('=', 40) + "\n\n\n\n\n");
                    }
                }

                cypher = reader.ReadLine();
            }
        }
    }

    static string EncryptDecrypt(int[] nums, string cypher)
    {
        var result = new int[nums.Length];

        for (int i = 0, cypherIndex = 0; i < nums.Length; i++)
        {
            if (cypherIndex >= cypher.Length) cypherIndex = 0;
            result[i] = (nums[i] ^ ((int)cypher[cypherIndex++]));
        }

        return TurnToText(result);
    }

    static string TurnToText(int[] nums)
    {
        var result = new StringBuilder(nums.Length);

        for (int i = 0; i < nums.Length; i++) result.Append((char)(nums[i]));

        return result.ToString();
    }
}
