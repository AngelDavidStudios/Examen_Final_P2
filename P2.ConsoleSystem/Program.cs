using P2.ConsoleSystem.Services;
using P2.Models.Models;

class Program
{
    private static readonly EquipoService _equipoService = new EquipoService();
    static async Task Main(string[] args)
    {
        while (true)
        {
            string titulo = "--- Menú de Equipos ---";
            string separador = new string('=', 30);
            int anchoConsola = Console.WindowWidth;

            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine(titulo.PadLeft((anchoConsola + titulo.Length) / 2));
            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine();

            string[] opciones =
            {
                "1. Listar Equipos disponibles",
                "2. Agregar Equipo",
                "3. Actualizar Equipo",
                "4. Eliminar Equipo",
                "5. Salir"
            };

            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion.PadLeft((anchoConsola + opcion.Length) / 2));
            }

            Console.WriteLine();
            string prompt = "Selecciona una opción: ";
            Console.Write(prompt.PadLeft((anchoConsola + prompt.Length) / 2));

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListEquipoAsync();
                    break;
                case "2":
                    await AddEquipoAsync();
                    break;
                case "3":
                    await UpdateEquipoAsync();
                    break;
                case "4":
                    await DeleteEquipoAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    private static async Task ListEquipoAsync()
    {
        try
        {
            var equipos = await _equipoService.GetEquipos();
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }
            
            Console.WriteLine("\n--- Lista de Equipoas ---");
            Console.WriteLine($"{"ID Equipo",-5} {"Nombre Equipo",-20} {"Tipo",-30} {"Precio X Dia",-15} {"Descripcion",-30}");
            Console.WriteLine(new string('-', 100));
            
            foreach (var equipo in equipos)
            {
                Console.WriteLine($"{equipo.IdEquipo,-5} {equipo.Nombre,-20} {equipo.Tipo,-30} {equipo.PrecioXDia,-15} {equipo.Descripcion,-30}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    
    private static async Task AddEquipoAsync()
    {
        try
        {
            Console.Write("ID del equipo: ");
            var id = Console.ReadLine();
            Console.Write("Nombre del equipo: ");
            var nombre = Console.ReadLine();
            Console.Write("Tipo de equipo: ");
            var tipo = Console.ReadLine();
            Console.Write("Precio por día: ");
            var precio = Console.ReadLine();
            Console.Write("Descripción: ");
            var descripcion = Console.ReadLine();
            
            var equipo = new Equipos()
            {
                IdEquipo = int.Parse(id),
                Nombre = nombre,
                Tipo = tipo,
                PrecioXDia = double.Parse(precio),
                Descripcion = descripcion
            };
            
            await _equipoService.AddEquipo(equipo);
            Console.WriteLine("Equipo agregado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    
    private static async Task UpdateEquipoAsync()
    {
        try
        {
            Console.Write("ID del equipo a actualizar: ");
            var id = Console.ReadLine();
            Console.Write("Nuevo nombre del equipo: ");
            var nombre = Console.ReadLine();
            Console.Write("Nuevo tipo de equipo: ");
            var tipo = Console.ReadLine();
            Console.Write("Nuevo precio por día: ");
            var precio = Console.ReadLine();
            Console.Write("Nueva descripción: ");
            var descripcion = Console.ReadLine();
            
            var equipo = new Equipos()
            {
                IdEquipo = int.Parse(id),
                Nombre = nombre,
                Tipo = tipo,
                PrecioXDia = double.Parse(precio),
                Descripcion = descripcion
            };
            
            await _equipoService.UpdateEquipo(equipo);
            Console.WriteLine("Equipo actualizado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    
    private static async Task DeleteEquipoAsync()
    {
        try
        {
            Console.Write("ID del equipo a eliminar: ");
            var id = Console.ReadLine();
            await _equipoService.DeleteEquipo(int.Parse(id));
            Console.WriteLine("Equipo eliminado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}