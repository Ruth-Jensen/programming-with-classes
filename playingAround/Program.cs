// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;

Person person = new Person("Ruth", "Jensen", "Ms.");
string ISignature = person.GetInformalSignature();
Console.WriteLine(ISignature);
