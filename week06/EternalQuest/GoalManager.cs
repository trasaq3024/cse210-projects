using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // === EXCEEDS REQUIREMENT FEATURE ===
    // Added Level-Up System: Player gains a level for every 100 points earned.
    private int _level = 1; // Starts at level 1
    // ===================================

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points | Level: {_level}"); // Shows level
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
            _goals.Add(new SimpleGoal(name, description, points));
        else if (choice == "2")
            _goals.Add(new EternalGoal(name, description, points));
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level); // Save level for exceeds requirement feature
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]); // Load level

        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] goalData = parts[1].Split(",");

            if (goalType == "SimpleGoal")
                _goals.Add(new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
            else if (goalType == "EternalGoal")
                _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
            else if (goalType == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3]), int.Parse(goalData[4])));
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;

        int pointsEarned = _goals[choice].RecordEvent();
        _score += pointsEarned;

        // === EXCEEDS REQUIREMENT FEATURE ===
        // Level up every 100 points
        if (_score >= _level * 100)
        {
            _level++;
            Console.WriteLine($"🎉 Congratulations! You reached Level {_level}!");
        }
        // ===================================

        Console.WriteLine($"You have earned {pointsEarned} points!");
    }
}

