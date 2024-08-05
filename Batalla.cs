
using personaje;
using seleccionPersonaje;
using CrearApi;
using fabrica;
using mostrar;
using funcionesDeBatalla;
using ArchivosJSON;
using funcionesControl;

namespace batalla
{
    public class Combate
    {
        public void guardarGanador(List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial, Personaje pjGanador)
        {
            listGanadores.Add(pjGanador);
            historial.GuardarJson(listGanadores, archivoHistorial);
        }
      
        private async Task verificarBonificacionClima(Personaje pjSeleccionado, Personaje pjSeleccionado2)
        {
            string weather = await ApiClima.TraerInfoClima();
            Console.WriteLine($"El clima en esta batalla es: {weather}");
            ApiClima.controlarClimaConPersonaje(pjSeleccionado, weather);
            ApiClima.controlarClimaConPersonaje(pjSeleccionado2, weather);
        }

        public async Task Pelea1vs1(List<Personaje> personajes, Combate combate, List<Personaje> listGanadores, GuardarYleerArchivosJson historial, string archivoHistorial, List<Personaje> pjFabricados, FabricaDePersonajes fabrica)
        {
            var pjGanador = await combate.peleaBot(personajes,pjFabricados,fabrica);
            guardarGanador(listGanadores, historial, archivoHistorial, pjGanador);
        }

        public async Task<Personaje> peleaBot(List<Personaje> personajes, List<Personaje> pjFabricados, FabricaDePersonajes fabrica)
        {
            var selec = new paraBatalla();
            fabrica.ListaDePersonaje(pjFabricados);
            var seleccion = new Seleccion();
            Personaje pjSeleccionado = selec.SeleccionarPJ(personajes, seleccion);
            Personaje pjSeleccionado2 = selec.SeleccionarPJ(personajes, seleccion, pjSeleccionado);
            await Task.Delay(1700);
            Console.WriteLine($"{pjSeleccionado.Datos.Name} VS {pjSeleccionado2.Datos.Name}");
            var clima = new Control();
            await verificarBonificacionClima(pjSeleccionado, pjSeleccionado2);
            var realcombate = new paraBatalla();

            return await realcombate.realizarCombate(pjSeleccionado, pjSeleccionado2);
        }

    
        public async Task<Personaje> TorneoDeBasurero(List<Personaje> pjPrincipal,List<Personaje> pjFabricados, FabricaDePersonajes fabrica, List<Personaje> PjSecundario, Combate combate, List<Personaje> listGanadores, /*HistorialJson historial*/GuardarYleerArchivosJson historial, string archivoHistorial)
        {
            var selec = new paraBatalla();
            fabrica.ListaDePersonaje(pjFabricados);
            var random = new Random();
            var seleccion = new Seleccion();
            Personaje pjSeleccionado = selec.SeleccionarPJ(pjPrincipal, seleccion);
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
                var controlS = new Control();
                await verificarBonificacionClima(pjSeleccionado, pjOponentes[i]);
                var realcombate = new paraBatalla();
                var pjGanador = await realcombate.realizarCombate(pjSeleccionado, pjOponentes[i]);

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
            Console.WriteLine($"                     {pj.Datos.Name}                        ");
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