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
            Console.WriteLine("5. Exit");
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
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}