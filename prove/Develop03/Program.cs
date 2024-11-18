// Added logic to only hide a word that isn't already hidden.

using System;
using System.IO;
using System.Net.Quic;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        Reference reference = new Reference("Moses", 1, 39);
        Scripture scripture = new Scripture(reference, "39 For behold, this is my work and my glory\u2014to bring to pass the immortality and eternal life of man.");

        bool play = true;
        bool play2 = true;

        string banner = $"Welcome to the scripture memoriser, press ENTER twice to continue or enter 'quit' to stop.";
        Console.WriteLine(banner);
        string quit = Console.ReadLine();

        if (quit.ToLower() == "quit")
        {
            Console.WriteLine("Have a great day.");
        }
        else
        {
            Console.ReadKey();
            do
            {

                do
                {
                    Console.Clear();
                    scripture.GetDisplayText();
                    quit = Console.ReadLine();

                    if (quit.ToLower() == "quit")
                    {
                        play = false;
                    }
                    else
                    {
                        Console.ReadKey();
                        Console.Clear();
                        scripture.HideRandomWords(1);
                        scripture.GetDisplayText();
                    }

                    if (scripture.IsCompletelyHidden())
                    {
                        play2 = scripture.IsCompletelyHidden();
                        play = false;
                    }
                } while (play && play2);
                Console.WriteLine();
                Console.WriteLine("Generate scripture? (yes/no)");
                string resp = Console.ReadLine();

                if (resp.ToLower() == "yes")
                {
                    scripture = new Scripture(reference, "39 For behold, this is my work and my glory\u2014to bring to pass the immortality and eternal life of man.");
                    play = true;
                }

                Console.WriteLine();
                Console.WriteLine("Have a great day.");

            } while (play);
        }

    }
}