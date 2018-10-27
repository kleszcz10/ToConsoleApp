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
                if(command.StartsWith("add"))
                {
                    if(command == "add")
                    {
                        Commands.AddTask();
                        ConsoleEx.Write("Wprowadź nowe zadanie: ", ConsoleColor.Gray);
                        TodoList.Add(Commands.TaskParse(Console.ReadLine()));
                    }
                    if(command.Length > 3)
                    {
                        TodoList.Add(Commands.TaskParse(command.Replace("add ","")));
                    }
                }
                if(command == "show")
                {
                    Commands.ShowTasks(TodoList);
                }
            } while (command != "exit");
        }
    }
}
