// Added an optioon to remove an entry if needed
public class Program
{
    private static void Main()
    {
        Journal journal = new();
        PromptGenerator promptGenerator = new();

        while (true)
        {
            Console.WriteLine("\n1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Remove an entry");
            Console.WriteLine("6. Exit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                journal.AddEntry(prompt, response);


            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }



            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string file = Console.ReadLine();
                try
                {
                    journal.SaveToFile(file);
                    Console.WriteLine($"{file} successfully saved\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}\n");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string file = Console.ReadLine();
                try
                {
                    journal.LoadFromFile(file);
                    Console.WriteLine($"{file} successfully loaded\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading file: {ex.Message}\n");
                }
            }
            else if (choice == "6")
            {
                break;
            }
            else if (choice == "5")
            {
                // Display all entries first so user can see which one to remove
                Console.WriteLine("\nCurrent entries:");
                journal.DisplayAll();

                // Prompt user for the entry number they want to remove

                Console.Write("\nEnter the number of the entry you want to remove: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    // Subtract 1 from index because the display shows entries starting at 1,
                    // but the List is zero-based
                    if (journal.RemoveEntry(index - 1))
                    {
                        Console.WriteLine("Entry successfully removed.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry number.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}