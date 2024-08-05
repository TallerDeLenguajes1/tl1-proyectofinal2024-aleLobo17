
using personaje;
using seleccionPersonaje;
using CrearApi;
using fabrica;
using mostrar;
using batalla;
using ArchivosJSON;
using funcionesControl;
namespace funcionesDeBatalla{
    public class paraBatalla{

        //seleccion de Personajes
        public Personaje SeleccionarPJ(List<Personaje> personajes, Seleccion seleccion, Personaje pjExistente = null)
        {
            if (pjExistente == null)
            {
                Console.WriteLine("\nSeleccione el id del personaje que desea usar:");
            }
            else
            {
                Console.WriteLine("\nSeleccione el id del personaje que será su oponente:");
            }

            int.TryParse(Console.ReadLine(), out int op);

            if (op >= 1 && op <= 10)
            {
                var pjSeleccionado = seleccion.seleccionarPersonaje(personajes, op);
                if (pjSeleccionado == pjExistente)
                {
                    Console.WriteLine("\nNo puede seleccionar el mismo personaje.");
                    return SeleccionarPJ(personajes, seleccion, pjExistente);
                }
                seleccion.personajeSeleccionado(pjSeleccionado);
                return pjSeleccionado;
            }
            else
            {
                Console.WriteLine("\nNo seleccionó un ID correcto.");
                return SeleccionarPJ(personajes, seleccion, pjExistente);
            }
        }

        public async Task realizarAtaqueYDefensa(Personaje atacante, Personaje defensor)
        {
            var random = new Random();
            var datosPj = atacante.Datos;
            var caracteristicas = atacante.Caracteristicas;
            var datosPj2 = defensor.Datos;
            var caracteristicas2 = defensor.Caracteristicas;

            int ataque = caracteristicas.Destreza * caracteristicas.Fuerza * caracteristicas.Nivel;
            int efectividad = random.Next(1, 100);
            int defensa = caracteristicas2.Armadura * caracteristicas2.Velocidad;
            const int Ajuste = 500;

            int danioProvocado = ((ataque * efectividad) - defensa) / Ajuste+10;

            if (danioProvocado>20){
                danioProvocado = random.Next(12, 17);
            }
            Console.WriteLine($"\nEl atacante {datosPj.Name} realizó un daño de: {danioProvocado}");
            var control = new Control();
            control.controlDanio(danioProvocado);

            caracteristicas2.Salud -= danioProvocado;
            var controlS = new Control();
            controlS.controlarSaludNoNegativa(caracteristicas2);

            Console.WriteLine($"La salud de {datosPj2.Name} es de: {caracteristicas2.Salud}");
            await Task.Delay(1700);
        }

        public async Task<Personaje> realizarCombate(Personaje p1, Personaje p2)
        {
            var asci = new Mostrar();
            while (p1.Caracteristicas.Salud > 0 && p2.Caracteristicas.Salud > 0)
            {
                var controlPJ = new Control();
                await realizarAtaqueYDefensa(p1, p2);
                if (p2.Caracteristicas.Salud <= 0)
                {
                    return await controlPJ.ControlarSaludPJ(p1, p2, asci);
                }

                await realizarAtaqueYDefensa(p2, p1);

                if (p1.Caracteristicas.Salud <= 0)
                {
                    return await controlPJ.ControlarSaludPJ(p1, p2, asci);
                }
            }
            return null;
        }
    }
}