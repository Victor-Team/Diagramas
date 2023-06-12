using System.Text;

namespace POO_2
{
    public class Funciones
    {
        public static List<Producto> CreacionMenu ( List<Producto> Lista)
        {
            //Menus disponibles 
            Producto Menu1 = new Producto ("Bocatica",2.20);
            Lista.Add (Menu1);
            Producto Menu2 = new Producto("Donut", 1.00);
            Lista.Add(Menu2);
            Producto Menu3 = new Producto("Sandwich Mixto", 1.40);
            Lista.Add(Menu3);
            Producto Menu4 = new Producto("Energetica pa programar", 1.20);
            Lista.Add(Menu4);
            Producto Menu5 = new Producto("Aguita buena", 0.80);
            Lista.Add(Menu5);
            return Lista;
        }

        public static void VerMenu(List<Producto>Lista)
        {
            Console.Clear();
            //Muestra del menu
            for (int i = 0; i < Lista.Count; i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine($"{i+1}){Lista[i].ToString()}");
            }
            Console.WriteLine("----------------");
        }

        public static void VerPedidos(List<Pedido> pedidos)
        {
            Console.Clear();
            if (pedidos.Count==0)
            {
                Console.WriteLine("NO HAY NINGUN PEDIDO EN COLA");
                Console.WriteLine("Pulse cualquier tecla para volver al menu");
                Console.ReadKey();
            }
            else
            {
                //Muestra de los pedidos
                for (int i = 0; i < pedidos.Count; i++)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine($"{pedidos[i].ToString()}");
                }
                Console.WriteLine("----------------");
                Console.ReadKey();
            }
        }

        public static Pedido RealizarPedido(ref double presupuesto, List<Producto> menus, List<Pedido> pedidos)
        {
            Pedido pedido = new Pedido();
            int i = pedidos.Count + 1;
            Producto salida = null;
              
            if (presupuesto < menus[0].GetPrecio())
            {
                Console.WriteLine("No posee presupuesto para ningun pedido");
                Console.WriteLine("Pulse cualquier tecla para volver...");
                Console.ReadKey();
                return pedido;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Menus Disponibles a su presupuesto");
                Console.WriteLine("----------------");
                foreach (var menu in menus)
                {
                    if (menu.GetPrecio() <= presupuesto)
                    {
                        Console.WriteLine(menu.ToString());
                    }

                }
                do
                {
                    // Pedir al usuario que seleccione un producto
                    Console.WriteLine("----------------");
                    Console.WriteLine("Escriba el nombre del menu que desea pedir");
                    string entrada = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        Console.Clear();
                        Console.WriteLine("ERROR EN EL FORMATO");
                        Console.WriteLine("DEBE ESCRIBIR EL NOMBRE DEL PRODUCTO");
                        Console.WriteLine("Pulse cualquier tecla para volver...");
                        Console.ReadKey();
                    }
                    else
                    {
                        salida = menus.Find(m => m.GetNombre().Trim().Equals(entrada));
                        if (salida == null)
                        {
                            Console.WriteLine($"El menu '{entrada}' no se encuentra en la lista");
                        }
                        else if (salida.GetPrecio() > presupuesto)
                        {
                            Console.WriteLine($"No dispone del presupuesto suficiente para el menu '{salida.GetNombre()}'");
                            salida = null;
                        }
                    }
                } while (salida == null);
            }
                // Se le aplica los datos al pedido
                pedido.SetNumero(i);
                pedido.SetNombre(salida.GetNombre());
                pedido.SetPrecio(salida.GetPrecio());
                pedido.SetFecha(DateTime.Now);
                return pedido;
        }
        public static void HacerCaja(List<Pedido>pedidos, ref double presupuesto)
        {
            Pedido carta = new Pedido();
            string entrada = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Actualmente posee estos pedidos:");

                for (int i = 0; i < pedidos.Count; i++)
                {
                    Console.WriteLine(pedidos[i].ToString());
                }

                Console.WriteLine("Desea seguir realizando pedidos o pasar ya por caja?");
                Console.WriteLine("SI(s) NO(n)");

                //No se si implementar un menu o controlarlo mediante un if
                //No estoy seguro de que opcion consume menos recusos

                entrada = Console.ReadLine().ToLower().Trim();

                switch (entrada)
                {
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Ha escogido no pasar por caja");
                        Console.WriteLine("Pulse cualquier tecla para regresar al menu...");
                        Console.ReadKey();
                        break;

                    case "s":
                        //Crear una funcionn en la cual mediante el presupuesto  se le cobre al cliente el menu solicitado
                        //realmente hace falta una funcion externa, no seria mas raapido crear el codigo en la opcion del menu?
                        Console.Clear();
                        CobroCaja(ref pedidos,ref presupuesto);
                        break;

                    default:
                        Console.WriteLine("ERROR, NO HA ESTCRITO UNA OPCION VALIDA");
                        Console.WriteLine("Por favor, pulse una tecla para restaurar el menu de caja ");
                        Console.ReadKey();
                        break;
                }

            } while (entrada != "n" && entrada!="s");
        }

        static void CobroCaja(ref List<Pedido> pedidos, ref double presupuesto)
        {
            Console.Clear();
            Console.WriteLine("Se efectuara el cobro de los pedidos soliciados");
            for (int i = 0; i < pedidos.Count; i++)
            {
                presupuesto -= pedidos[i].GetPrecio();
            }
            if (presupuesto < 0)
            {
                Console.Clear();
                Console.WriteLine("HA EXEDIDO EL PRESUPUESTO");
                Console.WriteLine("LOS SIMPAS NO ESTAN PERMITIDOS, ASI QUE SU PRESUPUESTO SE QUEDARA EN 0 Y NO PODRA COMPRAR NADA HASTA QUE LO CAMBIE");
                presupuesto = 0;
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"El cobro ha sido efectuado, su presupuesto se ha quedado en {presupuesto.ToString("F0")} ");
                Console.WriteLine("Su lista de pedidos sera eliminada");
                Console.WriteLine("Gracias por su compra");
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                pedidos = new List<Pedido>();
                Console.ReadKey();
            }
        }
    }
}