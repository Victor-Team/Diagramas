using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace POO_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //menu   
            string entrada = "";
            int Select = 0;
            double presupuesto = 0;
            string aux = "";
            List<Producto> menus = new List<Producto>();
            List<Pedido> pedidos = new List<Pedido>();
            Funciones.CreacionMenu(menus);
            do
            {
                Console.Clear();
                Console.WriteLine("----------");
                Console.WriteLine("---MENU---");
                Console.WriteLine("----------");
                Console.WriteLine("1) Ver los menus disponibles");
                Console.WriteLine("2) Realizar un pedido");
                Console.WriteLine("3) Ver la cola de pedidos");
                Console.WriteLine("4) Realizar caja");
                Console.WriteLine("5) Finalizar el programa");
                Console.WriteLine("----------");
                Console.WriteLine("Escoja una opcion");
                entrada=Console.ReadLine();
                while (!Int32.TryParse(entrada, out Select))
                {
                    Console.WriteLine("ERROR, DEBE ESCRIBIR EL NUMERO DE OPCION");
                    entrada = Console.ReadLine();
                }
                switch (Select)
                {
                    case 1:
                        Console.Clear();
                        Funciones.VerMenu(menus);
                        Console.WriteLine("Pulse cualquier tecla para continuar");
                        Console.ReadKey();
                    break;
                    
                    case 2:
                        if (pedidos.Count==5)
                        {
                            Console.Clear();
                            Console.WriteLine("LA COLA DE PEDIDOS ESTA SATURADA");
                            Console.WriteLine("");
                        }
                        do
                        {
                            Console.WriteLine($"Actualmente posee un presupuesto de {presupuesto}");
                            Console.WriteLine("Desea cambiar el presupuesto? SI(s)/NO(n)");
                            aux = Console.ReadLine();
                            switch (aux.ToLower())
                            {
                                case "n":
                                    Console.Clear();
                                    Console.WriteLine($"Ha escogido mantener el presupuesto en {presupuesto}");
                                    Console.WriteLine($"Pulse cualquier tecla para realizar el pedido");
                                    Console.ReadKey();
                                    break;
                                case "s":
                                    Console.Clear();
                                    Presupuesto(ref presupuesto);
                                    Console.WriteLine($"Ahora su presupuesto es de {presupuesto}");
                                    Console.WriteLine("Pulse cualquier tecla para realizar el pedido");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("ERROR,OPCION INVALIDA");
                                    break;
                            }
                        } while (aux.ToLower() != "n" && aux.ToLower() != "s");
                        pedidos.Add(Funciones.RealizarPedido(ref presupuesto, menus, pedidos));
                    break;

                    case 3:
                        Console.Clear();
                        Funciones.VerPedidos(pedidos);
                       break;

                    case 4:
                        Console.Clear();
                        Funciones.HacerCaja(pedidos, ref presupuesto);
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("FIN DE PROGRAMA");
                        Console.WriteLine("Pulse cualquier tecla para finalizar");
                        Console.ReadKey();
                        break;

                    default:
                            Console.Clear();
                            Console.WriteLine("OPCION INVALIDA");
                            Console.WriteLine("Pulse una tecla para regresar al menu");
                            Console.ReadKey();
                        break;
                }
            } while (Select!=0);
        }
        public static double Presupuesto( ref double presupuesto)
        {
            Console.WriteLine("De cuanto presupuesto dispone?:");
            while (!Double.TryParse(Console.ReadLine(), out presupuesto) || presupuesto<=0)
            {
                Console.Clear();
                Console.WriteLine("ERROR");
                Console.WriteLine("ESCRIBA DE NUEVO EL PRESUPUESTO");
            }
            return presupuesto;
        }
    }
}