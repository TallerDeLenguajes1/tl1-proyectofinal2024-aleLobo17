
using personaje;
using seleccionPersonaje;
using CrearApi;
using fabrica;
using mostrar;
using ArchivosJSON;

namespace batalla
{
    public class Combate
    {
        //  FUNCIONES GENERALES PARA EL COMBATE      
        private static Personaje SeleccionarPJ(List<Personaje> personajes, Seleccion seleccion, Personaje pjExistente = null)
        {
            if (pjExistente == null)
            {
                Console.WriteLine("\nSeleccione el id del personaje que desea usar:");
            }
            else
            {
                Console.WriteLine("\nSeleccione el id de su oponente:");
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
            controlDanio(danioProvocado);

            caracteristicas2.Salud -= danioProvocado;

            controlarSaludNoNegativa(caracteristicas2);

            Console.WriteLine($"La salud de {datosPj2.Name} es de: {caracteristicas2.Salud}");
            await Task.Delay(1700);
        }

        private async Task<Personaje> realizarCombate(Personaje p1, Personaje p2)
        {
            var asci = new Mostrar();
            while (p1.Caracteristicas.Salud > 0 && p2.Caracteristicas.Salud > 0)
            {
                await realizarAtaqueYDefensa(p1, p2);
                if (p2.Caracteristicas.Salud <= 0)
                {
                    return await ControlarSaludPJ(p1, p2, asci);
                }

                await realizarAtaqueYDefensa(p2, p1);

                if (p1.Caracteristicas.Salud <= 0)
                {
                    return await ControlarSaludPJ(p1, p2, asci);
                }
            }
            return null;
        }

        public void guardarGanador(List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial, Personaje pjGanador)
        {
            listGanadores.Add(pjGanador);
            //historial.GuardarGanador(listGanadores, archivoHistorial);
            historial.GuardarJson(listGanadores, archivoHistorial);
        }
        

        //CONTROLES
        private async Task verificarBonificacionClima(Personaje pjSeleccionado, Personaje pjSeleccionado2)
        {
            string weather = await ApiClima.TraerInfoClima();
            Console.WriteLine($"El clima en esta batalla es: {weather}");
            ApiClima.controlarClimaConPersonaje(pjSeleccionado, weather);
            ApiClima.controlarClimaConPersonaje(pjSeleccionado2, weather);
        }

        private static void controlDanio(int danioProvocado)
        {
            if (danioProvocado > 15)
            {

                Console.WriteLine("GOLPE CRITICO!");
            }
        }

        private static void controlarSaludNoNegativa(Caracteristicas caracteristicas2)
        {
            if (caracteristicas2.Salud < 0)
            {
                caracteristicas2.Salud = 0;
            }
        }

        private static async Task<Personaje> ControlarSaludPJ(Personaje p1, Personaje p2, Mostrar asci)
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

        private static async Task verResultado(Personaje pjSeleccionado)
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

        // SECCION DE BATALLAS
        public async Task Pelea1vs1(List<Personaje> personajes, Combate combate, List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial, List<Personaje> pjFabricados, FabricaDePersonajes fabrica)
        {
            var pjGanador = await combate.peleaBot(personajes,pjFabricados,fabrica);
            guardarGanador(listGanadores, historial, archivoHistorial, pjGanador);
        }

        public async Task<Personaje> peleaBot(List<Personaje> personajes, List<Personaje> pjFabricados, FabricaDePersonajes fabrica)
        {
            fabrica.ListaDePersonaje(pjFabricados);
            var seleccion = new Seleccion();
            Personaje pjSeleccionado = SeleccionarPJ(personajes, seleccion);
            Personaje pjSeleccionado2 = SeleccionarPJ(personajes, seleccion, pjSeleccionado);
            await Task.Delay(1700);
            Console.WriteLine($"{pjSeleccionado.Datos.Name} VS {pjSeleccionado2.Datos.Name}");
            await verificarBonificacionClima(pjSeleccionado, pjSeleccionado2);

            return await realizarCombate(pjSeleccionado, pjSeleccionado2);
        }

    
        public async Task<Personaje> TorneoDeBasurero(List<Personaje> pjPrincipal,List<Personaje> pjFabricados, FabricaDePersonajes fabrica, List<Personaje> PjSecundario, Combate combate, List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial)
        {
            fabrica.ListaDePersonaje(pjFabricados);
            var random = new Random();
            var seleccion = new Seleccion();
            Personaje pjSeleccionado = SeleccionarPJ(pjPrincipal, seleccion);
            int nivel = 3;
            int contador = 0;
            int elemento = 0;
            var pjOponentes = new List<Personaje>();
            CargarOponentes(PjSecundario, random, pjSeleccionado, nivel, pjOponentes);
            return await realizarCombateBasurero(listGanadores, historial, archivoHistorial, pjSeleccionado, contador, pjOponentes, elemento);
        }

        private async Task<Personaje> realizarCombateBasurero(List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial, Personaje pjSeleccionado, int contador, List<Personaje> pjOponentes, int elemento)
        {
                var restaura = pjSeleccionado.Caracteristicas.Fuerza;
                var restaura2 = pjSeleccionado.Caracteristicas.Armadura;
            for (int i = 0; i < pjOponentes.Count; i++)
            {
                if (elemento==2){
                    break;
                }
                Console.WriteLine($"\nNivel {contador + 1}: {pjSeleccionado.Datos.Name} vs {pjOponentes[i].Datos.Name}");
                await verificarBonificacionClima(pjSeleccionado, pjOponentes[i]);

                var pjGanador = await realizarCombate(pjSeleccionado, pjOponentes[i]);

                if (pjGanador == pjSeleccionado)
                {
                    await MostrarTransicionDeNivel(pjGanador, contador + 1);
                }
                else
                {
                    Console.WriteLine($"\nEl personaje {pjSeleccionado.Datos.Name} perdió en el nivel {contador + 1}");
                    elemento=2;
                    i+=10;
                    break;
                    return pjGanador;
                    break;
                }
                contador++;
            }

            if (elemento==0)
            {
                Console.WriteLine("\n¡Felicidades, ganaste el torneo!");
                Console.WriteLine($"\nEl personaje {pjSeleccionado.Datos.Name} ganó todos los niveles");
                pjSeleccionado.Caracteristicas.Fuerza = restaura;
                pjSeleccionado.Caracteristicas.Armadura = restaura2;
                Console.WriteLine("\nPor ganar el torneo ganaste +3 Fuerza y +3 Armadura");
                bonificacionTorneo(pjSeleccionado);
                guardarGanador(listGanadores, historial, archivoHistorial, pjSeleccionado);
                Console.WriteLine("-------------------------------------------------------------");
                return pjSeleccionado;
            }
            else
            {
                Console.WriteLine("Usted Perdio");
                return pjSeleccionado;
            }
        }

        private static void bonificacionTorneo(Personaje pjSeleccionado)
        {
            pjSeleccionado.Caracteristicas.Fuerza += 3;
            pjSeleccionado.Caracteristicas.Armadura += 3;
        }

        private async Task MostrarTransicionDeNivel(Personaje pj, int nivelActual)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine($"                    {pj.Datos.Name}                        ");
            Console.WriteLine($"                     Nivel {nivelActual}                     ");
            Console.WriteLine("************************************************************");
            Console.WriteLine("\nSubiendo al siguiente nivel...");
            await Task.Delay(1700);
        }

        private static void CargarOponentes(List<Personaje> PjSecundario, Random random, Personaje pjSeleccionado, int nivel, List<Personaje> pjOponentes)
        {
            for (int i = 0; i < nivel; i++)
            {
                Personaje pjSeleccionado2 = PjSecundario[random.Next(PjSecundario.Count)];

                while (pjSeleccionado2 == pjSeleccionado || pjOponentes.Contains(pjSeleccionado2))
                {
                    pjSeleccionado2 = PjSecundario[random.Next(PjSecundario.Count)];
                }

                pjOponentes.Add(pjSeleccionado2);
            }
            MostrarOponentesTorneo(pjOponentes);
        }

        private static void MostrarOponentesTorneo(List<Personaje> pjOponentes)
        {
            int cont = 0;
            Console.WriteLine("Estos seran tus oponentes!\n");
            foreach (var item in pjOponentes)
            {
                Console.WriteLine($"Nivel {1 + cont} {item.Datos.Name} ");
                cont++;
            }
        }
    }
}
