using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("\nThank you for participating in the Eternal Quest. Goodbye!\n");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select a valid number from the menu.\n");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int previousLevel = GetLevel(_score);
        string rankTitle = GetRankTitle(previousLevel);

        Console.WriteLine();
        Console.WriteLine("=================================================");
        Console.WriteLine($"  Points: {_score}  |  Level {previousLevel}: {rankTitle}");
        Console.WriteLine("=================================================");
        Console.WriteLine();
    }

    private int GetLevel(int score)
    {
        if (score >= 5000) return 5;
        if (score >= 3000) return 4;
        if (score >= 1500) return 3;
        if (score >= 500)  return 2;
        return 1;
    }

    private string GetRankTitle(int level)
    {
        return level switch
        {
            5 => "Master of Eternity",
            4 => "Celestial Knight",
            3 => "Steadfast Warrior",
            2 => "Apprentice Disciple",
            _ => "Novice Seeker"
        };
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals found. Create some goals first!\n");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        Console.WriteLine("Goal created successfully!\n");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to record. Please create a goal first.\n");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];

            if (goal.IsComplete())
            {
                Console.WriteLine("\nThis goal is already completed!\n");
                return;
            }

            int oldLevel = GetLevel(_score);
            goal.RecordEvent();
            int pointsEarned = goal.GetPoints();

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.GetBonus();
                Console.WriteLine($"\n*** BONUS UNLOCKED! You achieved the bonus of {checklistGoal.GetBonus()} points! ***");
            }

            _score += pointsEarned;
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");

            int newLevel = GetLevel(_score);
            if (newLevel > oldLevel)
            {
                Console.WriteLine("\n*************************************************");
                Console.WriteLine($"*** LEVEL UP! You reached Level {newLevel}: {GetRankTitle(newLevel)}! ***");
                Console.WriteLine("*************************************************\n");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid selection.\n");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals successfully saved to '{filename}'.\n");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' does not exist.\n");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.\n");
            return;
        }

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] typeAndDetails = line.Split(':');
            string goalType = typeAndDetails[0];
            string[] details = typeAndDetails[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                bool isComplete = bool.Parse(details[3]);
                _goals.Add(new SimpleGoal(name, desc, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                int bonus = int.Parse(details[3]);
                int target = int.Parse(details[4]);
                int completed = int.Parse(details[5]);
                _goals.Add(new ChecklistGoal(name, desc, points, bonus, target, completed));
            }
        }

        Console.WriteLine($"Goals successfully loaded from '{filename}'. Current Score: {_score}\n");
    }
}
