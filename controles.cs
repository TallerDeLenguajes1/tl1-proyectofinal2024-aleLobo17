
using personaje;
using seleccionPersonaje;
using CrearApi;
using fabrica;
using mostrar;
using batalla;
using ArchivosJSON;
namespace funcionesControl{
    public class Control{

        public void controlDanio(int danioProvocado)
        {
            if (danioProvocado > 15)
            {
                Console.WriteLine("GOLPE CRITICO!");
            }
        }

        public void controlarSaludNoNegativa(Caracteristicas caracteristicas2)
        {
            if (caracteristicas2.Salud < 0)
            {
                caracteristicas2.Salud = 0;
            }
        }

        public async Task<Personaje> ControlarSaludPJ(Personaje p1, Personaje p2, Mostrar asci)
        {
            if (p1.Caracteristicas.Salud <= 0){
                Console.WriteLine("El ganador fue " + p2.Datos.Name);
                p1.Caracteristicas.Salud = 100;
                p2.Caracteristicas.Salud = 100;
                asci.Finish();
                asci.Perdedor();
                return p2;
            }else{
                Console.WriteLine("El ganador fue " + p1.Datos.Name);
                p1.Caracteristicas.Salud = 100;
                p2.Caracteristicas.Salud = 100;
                asci.Finish();
                await verResultado(p1);
                return p1;
            } 
        }

        public static async Task verResultado(Personaje pjSeleccionado)
        {
            var asci = new Mostrar();
            await Task.Delay(1700);

            var random2 = new Random();
            int i = random2.Next(0, 2);
            if (i == 0)
            {
                Console.WriteLine("No recibiste una bonificación.");
                asci.mostrarPJ(pjSeleccionado);
                Console.WriteLine("---------COMBATE FINALIZADO--------");
            }
            else
            {
                Console.WriteLine($"Recibiste una bonificación +2 de fuerza y +2 de armadura.");
                pjSeleccionado.Caracteristicas.Fuerza += 2;
                pjSeleccionado.Caracteristicas.Armadura += 2;
                asci.mostrarPJ(pjSeleccionado);
                Console.WriteLine("---------COMBATE FINALIZADO--------");
            }
        }
    }
}