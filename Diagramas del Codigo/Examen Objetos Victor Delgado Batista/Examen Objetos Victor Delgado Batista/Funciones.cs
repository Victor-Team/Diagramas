using System.ComponentModel;

namespace Examen_Objetos_Victor_Delgado_Batista
{
    public class Funciones
    {

        public static List<Juegos> IntroducirJuegos(List<Juegos> lista)
        {
           
            Juegos Juego1 = new Juegos("Zelda", 35.75,"No alquilado",0);
            lista.Add(Juego1);
            Juegos Juego2 = new Juegos("Mario", 30 , "No alquilado",0);
            lista.Add(Juego2);
            Juegos Juego3 = new Juegos("Sonic", 27.40, "No alquilado", 0);
            lista.Add(Juego3);
            Juegos Juego4 = new Juegos("AlexKid", 15.20, "No alquilado", 0);
            lista.Add(Juego4);
            Juegos Juego5 = new Juegos("Wonder Boy", 21.90, "No alquilado", 0);
            lista.Add(Juego5);

            return lista;
        }
        public static Tienda DatosTienda(Tienda tienda)
        {
            string entrada = "";
            int numero = 0;
            bool comp = true;
            string encargado = "";
            Console.Clear();
            Console.WriteLine("Introduzca el nombre del encargado de la tienda:");
            encargado = Console.ReadLine();
            while (string.IsNullOrEmpty(encargado))
            {
                Console.Clear();
                Console.WriteLine("ERROR EL NOMBRE DEL ENCARGADO NO SE PUEDE DEJAR VACIO");
                Console.WriteLine("POR FAVOR ESCRIBA EL NOMBRE DE NUEVO");
                encargado = Console.ReadLine();
            }

            do
            {
                comp=true;
                Console.Clear();
                Console.WriteLine("Introduzca el numero de telefono de la tienda:");
                entrada = Console.ReadLine();
                if (entrada.Length != 9)
                {
                    comp = false;
                    Console.Clear();
                    Console.WriteLine("ERROR, EL NUMERO DEBE SER DE NUEVE DIGITOS");
                    Console.ReadKey();
                }
                else if (!entrada.Contains("922"))
                {
                    comp = false;
                    Console.WriteLine("ERROR, EL TELEFONO DEBE CONTENER DE PREFIJO 922");
                    Console.ReadKey();
                }
                else if (!Int32.TryParse(entrada, out numero) && numero <= 0)
                {
                    comp = false;
                    Console.WriteLine("ERROR, DEBE ESCRIBIR UN NUMERO ENTERO PARA CONTINUAR");
                    Console.ReadKey();
                }
            } while (!comp);
            tienda.SetNombre(encargado);
            tienda.SetNumTienda(numero);
            Console.Clear();
            Console.WriteLine("Datos de la tienda introducios");
            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
            return tienda;
        }
    
        public static void AlquilarJuego(List<Juegos>lista,Clientes cliente, ref double ganancias , List<Clientes>clientes, List<Alquileres> alquileres)
        {
            Alquileres datos = new Alquileres();
            int Select = 0;
            string entrada = "";
            Console.WriteLine("Cual es el nombre del cliente?");
            entrada = Console.ReadLine();
            while (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("ERROR OPCION INVALIDA");
                Console.WriteLine("Escriba un nombre para el cliente");
                entrada = Console.ReadLine();
            }

            Console.WriteLine("Que juego desea alquilar?");
        
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].GetAlquilado().Contains("No alquilado"))
                {
                    Console.WriteLine($"{i+1}){lista[i].ToString()}");
                }
            }
            while (!Int32.TryParse(Console.ReadLine(), out Select) && Select>lista.Count && Select<lista.Count)
            {
                Console.WriteLine("ERROR OPCION INVALIDA");
                Console.WriteLine("Escriba el id de uno de los juegos");
            }
            cliente.SetNombreCliente(entrada);
            cliente.SetNombreJuego(lista[Select-1].GetNombre());
            lista[Select-1].SetAlquilado("Alquilado");
            lista[Select - 1].SetGanancia(lista[Select - 1].GetGanancia()+lista[Select - 1].GetPrecio());
            datos.SetNombre(lista[Select - 1].GetNombre());
            datos.SetNombreCliente(entrada);
            clientes.Add(cliente);
            alquileres.Add(datos);
            Console.WriteLine("Juego alquilado");
            Console.WriteLine("Pulse cualquier tecla para volver");
            Console.ReadKey();
        }

        public static void DevolverJuego(List<Juegos> listaJuegos, List<Clientes> cliente)
        {
            int Select = 0;
            if (cliente.Count == 0)
            {
                Console.WriteLine("Actualmente no existen clientes registrados");
            }
            else
            {
                Console.WriteLine("Que cliente va a devolver el juego?");
                Console.WriteLine("Que juego desea alquilar?");

                for (int i = 0; i < cliente.Count; i++)
                {
                    Console.WriteLine($"{i + 1}){cliente[i].GetNombreCliente()}");                    
                }
                while (!Int32.TryParse(Console.ReadLine(), out Select) && Select > cliente.Count && Select < cliente.Count)
                {
                    Console.WriteLine("ERROR OPCION INVALIDA");
                    Console.WriteLine("Escriba el id de uno de los clientes");
                }
                Console.WriteLine($"De acuerdo se devolvera {cliente[Select-1].GetNombreJuego()}");
                Console.WriteLine("Pulse cualquier tecla para volver..");
                Console.ReadKey();
                for (int i = 0; i < listaJuegos.Count; i++)
                {
                    if (cliente[Select - 1].GetNombreJuego().Equals(listaJuegos[i]))
                    {
                        listaJuegos[i].SetAlquilado("No alquilado");
                    }
                }
                Console.ReadKey();
            }
        }

        public static void MostrarInfoTienda(Tienda tienda, List<Clientes> cliente, List<Juegos> juego)
        {
            Console.WriteLine($"Encargado de tienda: {tienda.GetNombre()}");
            Console.WriteLine($"Telefono de la tienda: {tienda.GetNumTienda()}");

            Console.WriteLine("Juegos disponibles:");
            for (int i = 0; i < juego.Count; i++)
            {
                if (juego[i].GetAlquilado().Contains("No alquilado"))
                {
                    Console.WriteLine($"{juego[i].ToString()}");
                }
            }
            
            Console.WriteLine("Juegos no disponibles:");
            for (int i = 0; i < cliente.Count; i++)
            { 
               Console.WriteLine($"Nombre del juego: {cliente[i].GetNombreJuego()} --Usuario que lo tiene: {cliente[i].GetNombreCliente()}");
            }
            Console.ReadKey();
        }

        public static void MostrarHistorial(List<Juegos>juegos)
        {
            //incompleto
            int Select = 0;
            string titulo = "";
            Console.WriteLine("De que juego desea ver el historial?");
            for (int i = 0; i < juegos.Count; i++)
            {
                Console.WriteLine($"{i+1}{juegos[i]}");
            }
            while (!Int32.TryParse(Console.ReadLine(), out Select) && Select > juegos.Count && Select < juegos.Count)
            {
                Console.WriteLine("ERROR OPCION INVALIDA");
                Console.WriteLine("Escriba el id de uno de los juegos");
            }
            titulo = juegos[Select - 1].GetNombre();

            
           
        }
    }
}
