// Write a program that replaces in a HTML document given as string all 
// the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

using System;
using System.Text.RegularExpressions;

class HTMLtags
{
    static void Main()
    {
        string text = "<p>Please visit <a         href   =   \"http://academy.telerik.com           \"   >our site<   /  a   > to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        text = Regex.Replace(text, @"<\s*a\s*href\s*=\s*\""", "[URL=", RegexOptions.IgnoreCase);
        text = Regex.Replace(text, @"(\[URL=.+?)(\s*""\s*>)", "$1]", RegexOptions.IgnoreCase);
        text = Regex.Replace(text, @"<\s*/\s*a\s*>", "[/URL]", RegexOptions.IgnoreCase);

        Console.WriteLine(text);
    }
}
