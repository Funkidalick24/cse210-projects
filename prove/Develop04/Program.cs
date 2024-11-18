// Added logic to ensure that no prompt or question is ever repeated before exhausting the available list.

using System;

class Program
{
    static void Main(string[] args)
    {
        string banner = "Welcome to the Mindfulness Program\n";
        Console.WriteLine(banner);

        bool play = true;
        do
        {
             Console.WriteLine("Menu options:\n1. Start Breathing Actvity\n2. Start reflecting Activity\n3. Start Listing Activity\n4. Quit");
             Console.Write("Choose an option from the menu: ");
             string choice = Console.ReadLine();

             int usrChoice = int.Parse(choice);

             if(usrChoice == 1)
             {
                BreathingActivty breathing = new BreathingActivty();
                breathing.Run();
             }
             else if(usrChoice == 2)
             {
                ReflectingActivty reflecting = new ReflectingActivty();
                reflecting.Run();
             }
             else if(usrChoice == 3)
             {
                ListingActivity listing = new ListingActivity();
                listing.Run();
             }
             else if(usrChoice == 4)
             {
                play = false;
             }

        } while (play);

        Console.Clear();
        Console.WriteLine("Bye Bye");
    }
}