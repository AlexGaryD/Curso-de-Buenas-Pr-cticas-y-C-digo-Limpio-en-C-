using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } // Propiedad estática para almacenar la lista de tareas

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0; //Variable de control del menú
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add) //
                {
                    ShowMenuAdd(); // Agregar tarea
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove(); // Eliminar tarea
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList(); // Mostrar tareas pendientes
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read selectedOption
            string selectedOption = Console.ReadLine();
            return Convert.ToInt32(selectedOption);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < TaskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TaskList[i]);
                }
                Console.WriteLine("----------------------------------------");

                string selectedOption = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(selectedOption) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string taskDescription = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskDescription + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskDescription = Console.ReadLine();
                TaskList.Add(taskDescription);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < TaskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TaskList[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}