using System;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. Gamification Level & Rank System:
 *    The program implements a progression system where players advance through 5 distinct
 *    levels and earn honorable RPG titles based on their total score:
 *      - Level 1: Novice Seeker (0 - 499 pts)
 *      - Level 2: Apprentice Disciple (500 - 1499 pts)
 *      - Level 3: Steadfast Warrior (1500 - 2999 pts)
 *      - Level 4: Celestial Knight (3000 - 4999 pts)
 *      - Level 5: Master of Eternity (5000+ pts)
 *    When a player earns enough points to reach a new rank, a celebratory "LEVEL UP!"
 *    banner is displayed in the console.
 *
 * 2. Completion Protection:
 *    Completed simple goals cannot be re-recorded repeatedly for unintended points,
 *    ensuring the integrity of the score and quest milestones.
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}