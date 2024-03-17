using System;

class Program
{
    static void Main(string[] args)
    {
        InfoTracker infoTracker = new InfoTracker();
        Menu menu = new Menu();
        bool isRunning = true;
        bool isInvalidInput = false;
        bool shouldClear = true;


        while (isRunning)
        {
            if(shouldClear) { Console.Clear(); }
            shouldClear = true;
            Console.WriteLine("--------------------------------------");
            string userInput = menu.DisplayMainMenu(infoTracker, isInvalidInput);
            Console.WriteLine("--------------------------------------");
            Thread.Sleep(1000);
            isInvalidInput = false;

            switch (userInput)
            {
                case "1":
                    bool incorrectInput = true;
                    while (incorrectInput)
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------------------");
                        userInput = menu.DisplayGoalMenu(infoTracker, isInvalidInput);
                        Console.WriteLine("--------------------------------------");
                        Thread.Sleep(1000);
                        isInvalidInput = false;

                        switch (userInput)
                        {
                            case "1":
                                SimpleGoal simpleGoal = new SimpleGoal();
                                simpleGoal.GetUserInfo();
                                infoTracker.AddGoal(simpleGoal);
                                incorrectInput = false;
                                break;
                            case "2":
                                EternalGoal eternalGoal = new EternalGoal();
                                eternalGoal.GetUserInfo();
                                infoTracker.AddGoal(eternalGoal);
                                incorrectInput = false;
                                break;
                            case "3":
                                ChecklistGoal checklistGoal = new ChecklistGoal();
                                checklistGoal.GetUserInfo();
                                infoTracker.AddGoal(checklistGoal);
                                incorrectInput = false;
                                break;
                            default:
                                isInvalidInput = true;
                                break;
                        }
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    menu.ListGoalsMenu(infoTracker);
                    shouldClear = false;
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    userInput = Console.ReadLine();
                    Console.WriteLine("--------------------------------------");
                    Thread.Sleep(1000);
                    infoTracker.SaveGoals(userInput);
                    Console.Clear();
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    userInput = Console.ReadLine();
                    Console.WriteLine("--------------------------------------");
                    Thread.Sleep(1000);
                    Console.Clear();
                    infoTracker.LoadGoals(userInput);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    menu.RecordEventMenu(infoTracker);
                    Console.WriteLine("--------------------------------------");
                    Thread.Sleep(3000);
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    isInvalidInput = true;
                    break;
            }
        }
    }
}