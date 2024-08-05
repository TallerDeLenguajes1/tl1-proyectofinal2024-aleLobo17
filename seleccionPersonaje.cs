using personaje;

namespace seleccionPersonaje
{
    public class Seleccion
    {
        public Personaje seleccionarPersonaje(List<Personaje> personajes, int id)
        {
            foreach (var item in personajes)
            {
                var datos = item.Datos;
                if (datos.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
        public void personajeSeleccionado(Personaje pj)
        {
            var datosPj = pj.Datos;
            var caracteristicasPJ = pj.Caracteristicas;
            
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
}