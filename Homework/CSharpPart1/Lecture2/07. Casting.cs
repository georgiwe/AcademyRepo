using System;

class Casting
{
    static void Main()
    {
        string hello = "Hello";
        string world = "world";

        object helloWorld = hello + " " + world;

        string objectValue = (string)helloWorld;
    }
}
