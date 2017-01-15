using _03_05_01_SystemIO.Data;
using _03_05_01_SystemIO.Helpers;
using _03_05_01_SystemIO.Models;
using _03_05_01_SystemIO.Workflows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_01_SystemIO
{
    public class MainMenu
    {
        

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine().ToUpper(); //changed to Upper

            TestIfEmptyFile(input); //test to see if file is empty before proceding

            switch (input)
            {
                case "1":
                    ListStudentWorkflow listWorkflow = new ListStudentWorkflow();
                    listWorkflow.Execute();
                    break;
                case "2":
                    AddStudentWorkflow addWorkflow = new AddStudentWorkflow();
                    addWorkflow.Execute();
                    break;
                case "3":
                    RemoveStudentWorkflow removeWorkflow = new RemoveStudentWorkflow();
                    removeWorkflow.Execute();
                    break;
                case "4":
                    EditStudentWorkflow editWorkflow = new EditStudentWorkflow();
                    editWorkflow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice.  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }

        //added this to display message if no students in file
        private static void TestIfEmptyFile(string input)
        {

            using (StreamReader sr = new StreamReader(Settings.FilePath))
            {

                sr.ReadLine();

                if (sr.ReadLine() == null && input != "2")
                {

                Console.WriteLine();
                Console.WriteLine("Please note that there are no students yet in the database");
                Console.WriteLine();
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Show();

                }

            }


            StudentRepository repo = new StudentRepository(Settings.FilePath);

            ListStudentResponse response = repo.List();

            List<Student> students = response.Students;

        }

        public static void Show()
        {
            bool continueRunning = true;
            while(continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }
    }
}
