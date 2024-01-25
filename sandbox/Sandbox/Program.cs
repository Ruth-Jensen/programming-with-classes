using System;

class Program
{
    static void Main(string[] args)
    {
        Person bob = new Person();
        bob._givenName = "Bob";
        bob._familyName = "Jones";
        bob.ShowWesternName();

        //Console.WriteLine("Hello World!");

        //this is a single line comment
        
        /*this is a
        multiline comment */

        //ctrl forward slash on a line to comment it out
    }
}