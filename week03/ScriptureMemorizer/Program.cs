using System;
using System.Collections.Generic;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. Random Selection from Visible Words Only:
 *    In the Scripture.HideRandomWords method, the program filters only the words that
 *    are not yet hidden before selecting words at random. This prevents the program from
 *    wasting turns "re-hiding" already hidden words.
 *
 * 2. Scripture Library:
 *    Instead of hardcoding a single scripture, the program includes a library of multiple
 *    scriptures (both single-verse and multi-verse ranges) and chooses one at random
 *    each time the program runs to provide varied practice.
 */

class Program
{
    static void Main(string[] args)
    {
        // Scripture library for practice (Exceeding requirement: random selection)
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me"
            ),
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be and men are that they might have joy"
            )
        };

        // Select a random scripture from the library
        Random random = new Random();
        int selectedIndex = random.Next(library.Count);
        Scripture scripture = library[selectedIndex];

        // Main interactive loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // If all words are hidden, display final output and exit
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! All words have been hidden. You have completed the memorization.");
                break;
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words each turn
            scripture.HideRandomWords(3);
        }
    }
}