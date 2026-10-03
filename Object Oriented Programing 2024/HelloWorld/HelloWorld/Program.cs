using HelloWorld;
using System;

namespace HelloWorld
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Message myMessage;
            myMessage = new Message("Hello World! Greetings from the Message Object.");
            myMessage.Print();

            string[] messages = { "Hello Ethan", "Hello Sam", "Hello Ronan", "Hello Szymon", "Hello, Nice to meet you" };

            Console.WriteLine("Name:");
            string name = Console.ReadLine().ToLower();

            if (name == "ethan")
            {
                Console.WriteLine(messages[0]);
            }
            else if (name == "sam")
            {
                Console.WriteLine(messages[1]);
            }
            else if (name == "ronan")
            {
                Console.WriteLine(messages[2]);
            }
            else if (name == "szymon")
            {
                Console.WriteLine(messages[3]);
            }
            else
            {
                Console.WriteLine(messages[4]);
            }
            Console.ReadLine();
        }
    }
}
