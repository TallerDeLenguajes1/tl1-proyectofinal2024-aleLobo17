namespace personaje{
    public enum NombrePersonajes{
        Pikachu,
        Mickey,
        Jerry,
        Cerebro,
        Pinky,
        NiñoRata,
        SpeedyGonzales,
        RataComun,
        Chefcito,
        TopoGigio
    }

    public enum Tipo{
        Trueno,
        Viento,
        Hielo,
        Fuego,
        Tierra,
        Agua
    }
    
    public class Datos{
        private string tipo;
        private string name;
        private string apodo;
        private DateTime fechaNacimiento;
        private int edad;
        private int id;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Name { get => name; set => name = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Id { get => id; set => id = value; }

        public Datos(string name, string tipo, DateTime fechaNacimiento, int edad, int id){
            Name = name;
            Tipo = tipo;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            Id = id;
        }
    }

    public class Caracteristicas{
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }


        public Caracteristicas(int velocidad, int destreza, int armadura, int fuerza, int nivel, int salud){
            Velocidad = velocidad;
            Destreza = destreza;
            Armadura = armadura;
            Fuerza = fuerza;
            Nivel = nivel;
            Salud = salud;
        }
    }

    public class Personaje{
        public Datos Datos { get; set; }
        public Caracteristicas Caracteristicas { get; set; }

        public Personaje() { }

        public Personaje(string name, string tipo, DateTime fechaNacimiento, int edad, int id, int velocidad, int destreza, int armadura, int fuerza, int nivel, int salud){
            Datos = new Datos(name, tipo, fechaNacimiento, edad, id);
            Caracteristicas = new Caracteristicas(velocidad, destreza, armadura, fuerza, nivel, salud);
        }
    }
}