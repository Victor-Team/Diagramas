namespace Examen_Objetos_Victor_Delgado_Batista
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clientes> clientes = new List<Clientes>();
            List<Juegos> listaJuegos = new List<Juegos>();
            List<Alquileres> alquileres = new List<Alquileres>();
            Tienda tienda = new Tienda();
            Clientes cliente= new Clientes();
            double ganancias = 0;
            string entrada = "";
            int Select = 0;
            Funciones.IntroducirJuegos(listaJuegos);

            Funciones.DatosTienda(tienda);
            do
            {
                Console.Clear();
                Console.WriteLine("Elija una de las siguientes opciones:");
                Console.WriteLine("1.- Alquilar Juego");
                Console.WriteLine("2.- Devolver Juego");
                Console.WriteLine("3.- Mostrar info tienda");
                Console.WriteLine("4.- Mostrar Historial");
                Console.WriteLine("0.- Salir");
                entrada = Console.ReadLine();
                while (!Int32.TryParse(entrada, out Select))
                {
                    Console.WriteLine("ERROR, DEBE ESCRIBIR EL NUMERO DE OPCION");
                    entrada = Console.ReadLine();
                }
                switch (Select)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Fin de Programa");
                        break;
                    case 1:
                        Console.Clear();
                        Funciones.AlquilarJuego(listaJuegos,cliente,ref ganancias, clientes, alquileres);
                        break;
                    case 2:
                        Console.Clear();
                        Funciones.DevolverJuego(listaJuegos,clientes);
                        break;
                    case 3:
                        Console.Clear();
                        Funciones.MostrarInfoTienda(tienda,clientes, listaJuegos);
                        break;
                    case 4:
                        Console.Clear();
                       // Funciones.MostrarHistorial(listaJuegos);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("OPCION INVALIDA");
                        break;

                }
            } while (Select!=0);



        }
    }
    
}
