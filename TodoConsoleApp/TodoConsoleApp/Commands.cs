using System;
using System.Collections.Generic;

namespace TodoConsoleApp
{
    public class Commands
    {
        public static void AddTask()
        {
            ConsoleEx.WriteLine("Wprowadź nowe zadanie według podanego schematu: ", ConsoleColor.Yellow);
            ConsoleEx.Write("\tZdarzenie całodniowe: ", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine("opis;data_rozpoczęcia;ważne[opcjonalnie]".PadLeft(57), ConsoleColor.Gray);
            ConsoleEx.Write("\tZdarzenie o określonym czasie trwania: ", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine("opis;data_rozpoczęcia;data_zakończenia;ważne[opcjonalnie]", ConsoleColor.Gray);
        }

        public static TaskModel TaskParse(string task)
        {
            string[] taskParameters = task.Split(';');
            if (taskParameters.Length == 3)
            {
                return new TaskModel(taskParameters[0], taskParameters[1], taskParameters[2]);
            }
            if (taskParameters.Length == 4)
            {
                return new TaskModel(taskParameters[0], taskParameters[1], taskParameters[2], taskParameters[3]);
            }
            return null;
        }

        public static void ShowTasks(List<TaskModel> list)
        {
            Console.Clear();
            int descriptionColumnWidth = Console.WindowWidth - 60;
            if (descriptionColumnWidth < 0) descriptionColumnWidth = 0;
            ConsoleEx.WriteLine("|Index|" +
                "Opis".PadRight(descriptionColumnWidth) +
                "|Data rozpoczęcia|Data zakończenia|Całodniowe|Ważne|", ConsoleColor.Red);
            if (list.Count != 0)
            {
                foreach (TaskModel task in list)
                {
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(list.IndexOf(task).ToString().PadRight(5), ConsoleColor.Gray);
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(task.Description.PadRight(descriptionColumnWidth).Substring(0,descriptionColumnWidth), ConsoleColor.Gray);
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(task.StartDate.PadRight(16), ConsoleColor.Gray);
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(task.EndDate.PadRight(16), ConsoleColor.Gray);
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(task.AllDayTask.ToString().PadRight(10), ConsoleColor.Gray);
                    ConsoleEx.Write("|", ConsoleColor.Red);
                    ConsoleEx.Write(task.Important.ToString().PadRight(5), ConsoleColor.Gray);
                    ConsoleEx.WriteLine("|", ConsoleColor.Red);
                }
            }
        }
    }
}
