using System;
using personaje;
namespace mostrar{
    public class Mostrar{
        public void MostrarLogo(){
            console.WriteLine(@"
            
██████╗ ███████╗██╗     ███████╗ █████╗     ██████╗ ███████╗    ██████╗  █████╗ ████████╗ █████╗ ███████╗
██╔══██╗██╔════╝██║     ██╔════╝██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔════╝
██████╔╝█████╗  ██║     █████╗  ███████║    ██║  ██║█████╗      ██████╔╝███████║   ██║   ███████║███████╗
██╔═══╝ ██╔══╝  ██║     ██╔══╝  ██╔══██║    ██║  ██║██╔══╝      ██╔══██╗██╔══██║   ██║   ██╔══██║╚════██║
██║     ███████╗███████╗███████╗██║  ██║    ██████╔╝███████╗    ██║  ██║██║  ██║   ██║   ██║  ██║███████║
╚═╝     ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝    ╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝                                                                                                                                     
                                      ./%%%%%%%%%%%%%%%%%%%%#,                                      
                               .(%##%%%%%%%%%%##((%((#%%%%%%%%%%%%%%/.                              
                           #%#%%%###/            ,%            .(%%%%%%%%/                          
                       (%%%%#%(.     ./#%%#/,.   ,%    .*/#%%#*      ,#%%%%%%*                      
                    %#%%#%(     ,%%#             ,%             .#%%.     #%%%%#/                   
                 /%%%%%,    ,%%,                 .%                  *%#.    /%%%%%,                
               %%%%%(    *#(                     ,%                      #%.    #%%%%/              
             #%%%#,    ##   .&@&.                                          .#(    /%%%%/            
           /#%%%,    %(   ,@@@@@@*@@@@@                                       ##    (%%%%.          
          %%%#(    #(     ,@@@@@@@@@@@@(                                        #(    #%%%#         
        .#%%%.   *%   /@@@@@@@@@@@@@@@*   .*/((/*.                               *#.   *%%%%        
       ,%%%#    ##%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#                          #/   .#%%%       
      ,%%%%    %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,                       %/   .%%%%      
      %%%% .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                      #*   ,%%%#     
     #%%%* *@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(                    .%    (%%#,    
    .#%%%    %&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#                    (#   .#%%%    
    *%%%/   ,%     %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*                   ,%    %%%%.   
    (%%%.   (#             (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    #,   (%%%*   
    #%%%#####%########     %@@@@@@@@@@@@@@@@@@@@@%%%@@@@@@@@@@@@@@@           *########%#####%%%*   
    (%%%.   /%           @@@@*. @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,                   %.   #%%%,   
    *%%%/   .%        #@@@#      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#                  ,%    %%%%    
     %%%%    #/       @&&        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                  #(   .%%%#    
     (%%%/   ,#                 @@@@#    .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#%.   #%%%.    
      %%%%    /%               .@@@,         .(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&(     
      .%%%%    ##            .&@@@          ./%@@@@@@@@@@@@@@@@@@@@@@@@%,           %,   ,&@@@@@.   
       .%%%#.   /#          (@(@         *&@@@@@@@@@@@@@@@@@&                     .%.   /%%%%*@@%   
         %%%%*   .#*                                                             (%    #%%%#.@@%    
          #%%%#    /%                                                          ,#,   .%%%%&@(       
           .%%%%(    (#.                                                     ,%*..  #%%%#           
             *%%%%#    *%*                                                 (%.    %#%%%             
               ,#%%%%.    #%,                    .%                     /#/    *%%%%#.              
                  #%%%##     /##.                .%                 ,#%,    ,%#%%%#                 
                    ,#%%%%%*     *#%#.           ,%            ,%%#.     (%%#%%#                    
                       .#%#%#%%(       ,(%%%##(/*/%**/(##%%%/.      ,##%%%%%(                       
                           .#%%%%%%%%(,          ,%          .*#%#%%%%%%(                           
                                .(%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%%*                                
                                        .*(##%%%%%%%%%%%##(,  
            ");
            Console.WriteLine("");
        }

        public void CondicionInicial(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(@"");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║      ¡Bienvenido al mundo de las peleas de Ratas!          ║");
            Console.WriteLine("║  Las reglas son simples, no morder ni tirar de los pelos   ║");
            Console.WriteLine("║  tampoco esta permitido contagiar enfermedades             ║");
            Console.WriteLine("║  Fuera de eso lo demas es valido, aunque para ser sincero  ║");
            Console.WriteLine("║  carece de muchas opciones de ataque asi que               ║");
            Console.WriteLine("║  no desesperes y que gane el mejor!!                       ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  Antes de comenzar debes elegir entre 2 opcion             ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  1) - Usar personajes guardados: En nuestra base de datos  ║");
            Console.WriteLine("║  ya estan definidos los campeones de peleas previas        ║");
            Console.WriteLine("║  cada uno tiene habilidades y tipos aleatorios             ║");
            Console.WriteLine("║  2) - Afuera lo viejo adentro lo nuevo: se eliminaran      ║");
            Console.WriteLine("║  los personajes guardados y se generaran nuevos personajes ║");
            Console.WriteLine("║  con valores aleatorios                                    ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  Elije sabiamente y que comience el espectaculo!!          ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        }
    }
}