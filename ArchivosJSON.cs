using System.Text.Json;
using personaje;
using fabrica;
using mostrar;

namespace ArchivosJSON
{
    //para guardar los personajes con carcteristicas random
    public class GuardarYleerArchivosJson{
        public void GuardarJson(List<Personaje> personajes, string nombreArchivo)
        {
            string jsonString = JsonSerializer.Serialize(personajes);

            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine(jsonString);
                }
            }
        }
        
        public List<Personaje> LeerJson(string archivo)
        {
            if (Existe(archivo))
            {
                string json = File.ReadAllText(archivo);
                return JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            else{
                Console.WriteLine("el archivo no existe.");
                return new List<Personaje>();
            }
        }
        public bool Existe(string archivo)
        {
            return File.Exists(archivo);
        }
    }

public class ArchivoPersonajes
    {
        private GuardarYleerArchivosJson personajesJSON = new GuardarYleerArchivosJson();

        public List<Personaje> GuardarYLeer(List<Personaje> listaPjs, string archivo)
        {
            if (personajesJSON.Existe(archivo))
            {
                return personajesJSON.LeerJson(archivo);
            }
            else
            {
                personajesJSON.GuardarJson(listaPjs, archivo);
                return personajesJSON.LeerJson(archivo);
            }
        }
    }

    public class GestionPersonajes
    {
        private GuardarYleerArchivosJson personajesJSON = new GuardarYleerArchivosJson();
        private FabricaDePersonajes fabrica = new FabricaDePersonajes();

        public async Task<List<Personaje>> CargarOcrearPersonajes(string archivo)
        {
            Console.Clear();
            var asci = new Mostrar();
            asci.CondicionInicial();
            int.TryParse(Console.ReadLine(), out int opcion);

            if (opcion == 1)
            {
                if (personajesJSON.Existe(archivo))
                {
                    return personajesJSON.LeerJson(archivo);
                }
                else
                {
                    Console.WriteLine("Lo sentimos no hay registros previos. Seleccione la otra opcion XD");
                    return await CargarOcrearPersonajes(archivo);
                }
            }
            else if (opcion == 2)
            {
                var listaPjs = await fabrica.CrearPersonajes(10);
                personajesJSON.GuardarJson(listaPjs, archivo);
                return listaPjs;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opción no válida.");
                return await CargarOcrearPersonajes(archivo);
            }
        }
    }
}