using System;
using System.Threading;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. Non-Repeating Prompts & Questions:
 *    In ReflectingActivity and ListingActivity, the program keeps track of unused prompts 
 *    and questions so that none are repeated during a session until all of them have been 
 *    used at least once. Once all items have been shown, the lists automatically refresh.
 *
 * 2. Activity Session Log & Statistics Tracker:
 *    The Program tracks the number of times each activity (Breathing, Reflecting, Listing)
 *    is performed and accumulates the total seconds spent across all sessions.
 *    A full session summary report is displayed when the user finishes and chooses to quit.
 */

class Program
{
    static void Main(string[] args)
    {
        // Activity tracking statistics
        int breathingSessions = 0;
        int breathingTotalSeconds = 0;

        int reflectingSessions = 0;
        int reflectingTotalSeconds = 0;

        int listingSessions = 0;
        int listingTotalSeconds = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingSessions++;
                breathingTotalSeconds += breathing.GetDuration();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingSessions++;
                reflectingTotalSeconds += reflecting.GetDuration();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingSessions++;
                listingTotalSeconds += listing.GetDuration();
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("             SESSION ACTIVITY LOG                ");
                Console.WriteLine("=================================================");
                Console.WriteLine($"  Breathing Activity:  {breathingSessions} session(s) ({breathingTotalSeconds}s total)");
                Console.WriteLine($"  Reflecting Activity: {reflectingSessions} session(s) ({reflectingTotalSeconds}s total)");
                Console.WriteLine($"  Listing Activity:    {listingSessions} session(s) ({listingTotalSeconds}s total)");
                Console.WriteLine("-------------------------------------------------");
                int totalSeconds = breathingTotalSeconds + reflectingTotalSeconds + listingTotalSeconds;
                int totalSessions = breathingSessions + reflectingSessions + listingSessions;
                Console.WriteLine($"  Total Mindfulness Time: {totalSeconds} seconds across {totalSessions} session(s).");
                Console.WriteLine("=================================================");
                Console.WriteLine("\nThank you for taking time to be mindful today. Goodbye!\n");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid option. Please choose a number between 1 and 4.");
                Thread.Sleep(1500);
            }
        }
    }
}