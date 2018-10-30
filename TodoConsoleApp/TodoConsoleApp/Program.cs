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

            if(args.Length == 0) // sprawdź czy program został uruchomiony z parametrami
            {
                do // Główna pętla programu
                {

                    ConsoleEx.Write("Wprowadź polecenie: ", ConsoleColor.Gray);
                    command = Console.ReadLine();
                    if (command.StartsWith("add"))
                    {
                        if (command == "add")
                        {
                            Commands.AddTask();
                            ConsoleEx.Write("Wprowadź nowe zadanie: ", ConsoleColor.Gray);
                            TaskModel newTask = Commands.TaskParse(Console.ReadLine());
                            if (newTask != null) TodoList.Add(newTask);

                        }
                        if (command.Length > 3)
                        {
                            TaskModel newTask = Commands.TaskParse(command.Replace("add ", ""));
                            if (newTask != null) TodoList.Add(newTask);
                        }
                    }
                    if (command == "show")
                    {
                        Commands.ShowTasks(TodoList);
                    }
                    if (command.StartsWith("remove"))
                    {
                        if (command == "remove")
                        {
                            Commands.RemoveTask(TodoList);
                        }
                        if (command.Length > 5)
                        {
                            Commands.RemoveTask(TodoList, int.Parse(command.Replace("remove ", "")));
                        }
                    }
                    if (command == "save")
                    {
                        Commands.SaveTasks(TodoList);
                    }
                    if (command == "savehtml")
                    {
                        Commands.SaveTasksToHTML(TodoList);
                    }
                    if (command == "load")
                    {
                        if (Commands.LoadTasks() != null)
                        {
                            TodoList = Commands.LoadTasks();
                        }
                    }
                } while (command != "exit");
            }
            else if(args[0] == "add") //Obsługa parametru 'add'
            {
                if (Commands.LoadTasks() != null)
                {
                    TodoList = Commands.LoadTasks();
                }
                string getParameters = string.Join(" ", args);
                TaskModel newTask = Commands.TaskParse(getParameters.Replace("add ", ""));
                if (newTask != null) TodoList.Add(newTask);
                Commands.SaveTasks(TodoList);
            }
        }
    }
}
