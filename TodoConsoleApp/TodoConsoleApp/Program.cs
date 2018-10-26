using System;
using System.Collections.Generic;

namespace TodoConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string command = "";
            List<TaskModel> TodoList = new List<TaskModel>();
            do
            {
                ConsoleEx.Write("Wprowadź polecenie: ", ConsoleColor.Gray);
                command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        Commands.AddTask();
                        ConsoleEx.Write("Wprowadź nowe zadanie: ", ConsoleColor.Gray);
                        TodoList.Add(Commands.TaskParse(Console.ReadLine()));
                        break;
                    case "show":
                        Commands.ShowTasks(TodoList);
                        break;
                }
            } while (command != "exit");
        }
    }
}
