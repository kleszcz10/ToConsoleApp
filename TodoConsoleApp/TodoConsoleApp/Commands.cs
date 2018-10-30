using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            if (taskParameters.Length == 3 && taskParameters[1] != "")
            {
                return new TaskModel(taskParameters[0], taskParameters[1], taskParameters[2].ToLower());
            }
            if (taskParameters.Length == 4 && taskParameters[1] != "")
            {
                return new TaskModel(taskParameters[0], taskParameters[1], taskParameters[2], taskParameters[3].ToLower());
            }
            return null;
        }

        public static void ShowTasks(List<TaskModel> list)
        {
            Console.Clear();
            int descriptionColumnWidth = Console.WindowWidth - 60;
            if (descriptionColumnWidth < 0)
            {
                descriptionColumnWidth = 0;
            }

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
                    ConsoleEx.Write(task.Description.PadRight(descriptionColumnWidth).Substring(0, descriptionColumnWidth), ConsoleColor.Gray);
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

        public static void RemoveTask(List<TaskModel> list)
        {
            ConsoleEx.Write($"Podaj numer id zadania które chcesz usunąć [0-{list.Count - 1}]: ", ConsoleColor.Yellow);
            int idOfTaskToRemove = int.Parse(Console.ReadLine());
            if (idOfTaskToRemove >= 0 && idOfTaskToRemove <= list.Count - 1)
            {
                list.RemoveAt(idOfTaskToRemove);
            }
            else
            {
                ConsoleEx.WriteLine("Zadanie o podanym id nie istnieje", ConsoleColor.Red);
            }
        }

        public static void RemoveTask(List<TaskModel> list, int idOfTaskToRemove)
        {
            if (idOfTaskToRemove >= 0 && idOfTaskToRemove <= list.Count - 1)
            {
                list.RemoveAt(idOfTaskToRemove);
            }
            else
            {
                ConsoleEx.WriteLine("Zadanie o podanym id nie istnieje", ConsoleColor.Red);
            }
        }

        public static void SaveTasks(List<TaskModel> list)
        {
            StringBuilder csvFile = new StringBuilder();
            foreach (TaskModel task in list)
            {
                string fileLine = $"{task.Description};{task.StartDate};{task.EndDate};{task.AllDayTask};{task.Important}";
                csvFile.AppendLine(fileLine);
            }
            File.WriteAllText("data.csv", csvFile.ToString());
        }

        public static List<TaskModel> LoadTasks()
        {
            List<TaskModel> newTaskList = new List<TaskModel>();

            if (File.Exists("data.csv"))
            {
                foreach (string line in File.ReadAllLines("data.csv"))
                {
                    string[] newTaskData = line.Split(';');
                    TaskModel newTask = Commands.TaskParse($"{newTaskData[0]};{newTaskData[1]};{newTaskData[2]};{newTaskData[4]}");
                    if (newTask != null)
                    {
                        newTaskList.Add(newTask);
                    }
                }
            }

            return newTaskList;
        }

        public static void SaveTasksToHTML(List<TaskModel> list)
        {
            StringBuilder htmlFile = new StringBuilder();
            htmlFile.AppendLine("<!DOCTYPE html>");
            htmlFile.AppendLine("<html>");
            htmlFile.AppendLine("<style>");
            htmlFile.AppendLine("body {font-family: Helvetica, Arial, sans-serif; font-size: 24px;}");
            htmlFile.AppendLine("th, td { padding: 15px; text-align: left;}");
            htmlFile.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            htmlFile.AppendLine("th {background-color: #4CAF50; color: white;}");
            htmlFile.AppendLine("</style>");
            htmlFile.AppendLine("<body>");
            htmlFile.AppendLine("<table>");
            htmlFile.AppendLine("<tr><th>Opis</th><th>Data rozpoczęcia</th><th>Data zakończenia</th><th>Całodzienne</th><th>Ważne</th></tr>");


            foreach (TaskModel task in list)
            {
                string fileLine = $"<tr><td>{task.Description}</td><td>{task.StartDate}</td><td>{task.EndDate}</td><td>{task.AllDayTask}</td><td>{task.Important}</td></tr>";
                htmlFile.AppendLine(fileLine);
            }
            htmlFile.AppendLine("</table>" +
                                "</body>" +
                                "</html>");
            File.WriteAllText("data.html", htmlFile.ToString());
        }
    }
}
