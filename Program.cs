List<string> TaskList = new List<string>();// Propiedad estática para almacenar la lista de tareas

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

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string selectedOption = Console.ReadLine();
    return Convert.ToInt32(selectedOption);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList(); // Mostrar tareas pendientes

        string selectedOption = Console.ReadLine();
        // Remove one position because the list is zero based
        int indexToRemove = Convert.ToInt32(selectedOption) - 1;
        // Validar que el índice ingresado sea válido
        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            Console.WriteLine("El número ingresado es inválido. Por favor, ingrese un número válido.");
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0) // Verificar que el índice sea válido
            {
                string taskDescription = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskDescription} eliminada");
            }
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al eliminar la tarea. Asegúrese de ingresar un número válido.");
    }
}
void ShowMenuAdd()
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

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0) // Validar que la lista de tareas no sea nula y tenga elementos
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach(p => Console.WriteLine($"{indexTask++} . {p}"));

        Console.WriteLine("----------------------------------------");

    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
