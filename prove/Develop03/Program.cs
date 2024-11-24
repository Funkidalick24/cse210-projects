/*
Extra Features:
- Multiple difficulty levels (Easy/Medium/Hard)
- Hint system showing first letter of each word
- Pattern-based hiding (every nth word)
- Length-based hiding (hides longer words first)
- Scripture library loaded from file
- Random scripture selection
*/
ScriptureLibrary library = new();
library.LoadFromFile("scriptures.txt");

Console.WriteLine("Select difficulty:");
Console.WriteLine("1 - Easy (2 words hidden)");
Console.WriteLine("2 - Medium (3 words hidden)");
Console.WriteLine("3 - Hard (4 words hidden)");
int wordsToHide = Console.ReadKey().KeyChar switch
{
    '1' => 2,
    '3' => 4,
    _ => 3
};
Console.Clear();

static void ShowHint(Scripture scripture)
{
    Console.Clear();
    Console.WriteLine(scripture.GetHintText());
    Console.WriteLine("\nPress any key to continue...");
    _ = Console.ReadKey();
}

bool continuePracticing = true;
while (continuePracticing)
{
    Scripture scripture = library.GetRandomScripture();
    bool scriptureComplete = false;

    while (!scriptureComplete)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress:");
        Console.WriteLine("Enter - Hide more words");
        Console.WriteLine("H - Show hint (first letter of each word)");
        Console.WriteLine("N - New scripture");
        Console.WriteLine("P - Pattern mode (hide every nth word)");
        Console.WriteLine("L - Hide longer words first");
        Console.WriteLine("Q - Quit");

        string input = Console.ReadLine()?.ToLowerInvariant() ?? "";
        switch (input)
        {
            case "h":
                ShowHint(scripture);
                break;
            case "n":
                Console.Clear();
                scriptureComplete = true;
                break;
            case "q":
                scriptureComplete = true;
                continuePracticing = false;
                break;
            case "p":
                Console.Write("Enter n (every nth word will be hidden): ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    scripture.HideEveryNthWord(n);
                }


                break;
            case "l":
                scripture.HideWordsByLength(5);
                break;
            default:
                scripture.HideRandomWords(wordsToHide);
                if (scripture.IsCompletelyHidden())
                {

                    scriptureComplete = true;
                }


                break;
        }
    }
}
