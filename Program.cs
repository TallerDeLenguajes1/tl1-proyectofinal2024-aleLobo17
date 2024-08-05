// See https://aka.ms/new-console-template for more information

using personaje;
using fabrica;
using ArchivosJSON;
using batalla;
using mostrar;

public class Program
{
    public static async Task Main(string[] args)
    {
        var fabrica = new FabricaDePersonajes();
        var gestionPersonajes = new GestionPersonajes();
        var historial = new GuardarYleerArchivosJson();
        var combate = new Combate();
        var archivoPersonajes = @"personajes.json";
        var archivoHistorial = @"historial.json";
        var listGanadores = new List<Personaje>();
        var mostrarImagen = new Mostrar();

        Console.WriteLine("\nConectando con el juego...\n");
        
        mostrarImagen.MostrarLogo();
        Console.WriteLine("\nPresione una tecla para iniciar...");
        Console.ReadKey();
        Console.Clear();
        var pjFabricados = await gestionPersonajes.CargarOcrearPersonajes(archivoPersonajes);
        await MenuInteractivo.Menu.ControlarMenu(fabrica, historial, combate, archivoHistorial, pjFabricados, listGanadores);
    }
}