using personaje;

namespace fabrica
{
    public class FabricaDePersonajes
    {
        private List<string> nombresUsados = new List<string>();
        public async Task<Personaje> CrearPersonaje(int id)
        {
            Random random = new Random();
            string nombre;

            do
            {
                nombre = Enum.GetName(typeof(NombrePersonajes), random.Next(Enum.GetNames(typeof(NombrePersonajes)).Length));
            } while (nombresUsados.Contains(nombre));

            nombresUsados.Add(nombre);
            string tipo = Enum.GetName(typeof(Tipo), random.Next(1, Enum.GetNames(typeof(Tipo)).Length));
            int edad = random.Next(0, 100);
            var fechaNac = DateTime.Now.AddYears(-edad);
            int Salud = 100;
            int velocidad;
            int destreza;
            int fuerza;
            int nivel;
            int armadura;;

            Random indicerandom = new Random();
            velocidad = indicerandom.Next(1, 10);
            armadura = indicerandom.Next(1, 10);
            destreza = indicerandom.Next(1, 10);
            fuerza = indicerandom.Next(1, 10);
            nivel = indicerandom.Next(1, 7);


            Personaje personaje = new Personaje(nombre, tipo, fechaNac, edad, id, velocidad, destreza, armadura, fuerza, nivel, Salud);
            return personaje;
        }

        public async Task<List<Personaje>> CrearPersonajes(int cantidad)
        {
            var listaPjs = new List<Personaje>();

            for (int i = 0; i < cantidad; i++)
            {
                listaPjs.Add(await CrearPersonaje(i + 1));
            }

            return listaPjs;
        }

        public void MostrarPersonaje(List<Personaje> personajes)
        {
            foreach (var personaje in personajes)
            {
                var datosPj = personaje.Datos;
                var caracteristicasPJ = personaje.Caracteristicas;

                Console.WriteLine("ID: " + datosPj.Id);
                Console.WriteLine("Nombre: " + datosPj.Name);
                Console.WriteLine("Tipo: " + datosPj.Tipo);
                Console.WriteLine("Fecha de Nacimiento: " + datosPj.FechaNacimiento.ToString("dd/MM/yyyy"));
                Console.WriteLine("Edad: " + datosPj.Edad);
                Console.WriteLine("Velocidad: " + caracteristicasPJ.Velocidad);
                Console.WriteLine("Destreza: " + caracteristicasPJ.Destreza);
                Console.WriteLine("Fuerza: " + caracteristicasPJ.Fuerza);
                Console.WriteLine("Nivel: " + caracteristicasPJ.Nivel);
                Console.WriteLine("Armadura: " + caracteristicasPJ.Armadura);
                Console.WriteLine("Salud: " + caracteristicasPJ.Salud);
                Console.WriteLine();
            }
        }
        
        public void ListaDePersonaje(List<Personaje> personajes)
        {
            for (int i = 0; i < personajes.Count; i++)
            {
                Console.WriteLine("ID: " + personajes[i].Datos.Id + "   Nombre: " + personajes[i].Datos.Name);
                Console.WriteLine();
            }
        }

    }
}