
using personaje;
using ArchivosJSON;
using fabrica;
using batalla;
using System;

namespace MenuInteractivo
{
    public static class Menu
    {
        public static async Task ControlarMenu(FabricaDePersonajes fabrica, HistorialJson historial, Combate combate, string archivoHistorial, List<Personaje> pjFabricados, List<Personaje> listGanadores)
        {
            int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║           MENU DE OPCIONES             ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║  1. Lista de Personajes                ║");
            Console.WriteLine("║  2. Pelea Mano a Mano                  ║");
            Console.WriteLine("║  3. Torneo del Basurero                ║");
            Console.WriteLine("║  4. Historial de ganadores             ║");
            Console.WriteLine("║  5. Huir con la cola entre las patas   ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.Write("Selecciona una opción (1-5): ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Por favor, introduce un número del 1 al 5.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    fabrica.MostrarPersonaje(pjFabricados);
                break;
                case 2:
                    await combate.Pelea1vs1(pjFabricados,combate,listGanadores,historial,archivoHistorial,pjFabricados,fabrica);
                    break;
                case 3:
                    await combate.TorneoDeBasurero(pjFabricados, pjFabricados, combate,listGanadores,historial,archivoHistorial);
                    break;
                case 4:
                    var leerPJ = historial.LeerGanador(archivoHistorial);
                    Console.WriteLine("\n--Historial ganadores--\n");
                    fabrica.MostrarPersonaje(leerPJ);
                    break;
                case 5:
                    Console.WriteLine("Saliendo del juego...");
                    Console.WriteLine(@"
#############%%%%%&,,,,,,,,&(#####################################################################&&
###########%(((((%%,,,,,,,,,,,,%##########################################%%%%%%%%%%%%%%%%&#,,,,,,%%
###########(((((((&&,,,,,,,,,,,,,,,&######################################%%%%%%%%%%&(,,,,,,,,,,,&%%
##########((((((((((%,,,,,,,,,,,,,,,,,*####################################%%%%&,,,,,,,,,,,,,,,,,%%%
#########((((((((####&,,,,,,,,,,,,,,,,,,,################################&*,,,,,,,,,,,,,,,,,,,,,&&%%
########(((((((((####%%,,,,,,,,,,,,,,,,,,,,,##%&&&#/,,,,,,,,,,,,,,,*&*,,,,,,,,,,,,,,,,,,,,,,,,,&%%%%
########((((((((####%%%%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,/#%%%%%
####################%%%%%%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,#######%
######%%%%%%%%%%%%%%%%%%%%%%%&,,,,&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&((((((####
#####%%%%%%%%%%%%%%%%%%%%%%%%%%&*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&,,,,&(((((((((####
####%%%%%%%%%%%%%%%%%%%%%%%%%%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&###(((((((######
###%%%%%%&&&&&&%%%%%%%%%%%%%%%,,,,,,,,,,&&&*,,,,,,,,,,,,,,,,,,,,,,,*&&&,,,,,,,,,,,,,,##############%
###%%%%%&&&&&&&&&%%%%%%%%%###,,,,,,,,,/*  #%%,,,,,,,,,,,,,,,,,,,,,%,  %%&,,,,,,,,,,,,,############%%
##%%%%%&&&&&&&&&%%%%%%%%%###,,,,,,,,,,,%%%%%&,,,,,,,,,,,,,,,,,,,,,*%%%%%&,,,,,,,,,,,,,(%########%%%%
#%%%%%&&&&&&&&&&&%%%%%%%%##%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&%%%%%%%%%%%%
#%%%%&&&&&&&&&&&&%%%%%%%##&,,,,,,,,,,,,,,,,,,,,,,,,&%%%&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,%%%%%%%%%%%%
%%%%%%%%&&&&&&&%%%%%%%%###*,/(((((((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,#((((((#,,,,,,/%%%%%%%%%%%
#%%%%%%%%%%%%%%%%%%#######,(((((((((#,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,(((((((((((,,,,,,&########%%
#%%######################&,,((((((((,,,,,,,,,,,,,,%(*******//,,,,,,,,,,,,(((((((((#,,,,,,,#########%
%#########((((((((((((((((,,,,,,,,,,,,,,,,,,,,,,,,**********(,,,,,,,,,,,,,,,(##/,,,,,,,,,,%(((######
%#####((((((((((((((((((((#,,,,,,,,,,,,,,,,,,,,,,,(/********%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,#((((####
%#####(((((((((((((((((((((#,,,,,,,,,,,,,,,,,,,,,,,,,,#%%%*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,%((((####
#######(((((((((((((((((((((#*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,#((#####

               
                            ");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, introduce un número del 1 al 5.");
                    break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }
    }
}