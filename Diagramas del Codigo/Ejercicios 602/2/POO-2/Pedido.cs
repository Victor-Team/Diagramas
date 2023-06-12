using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2
{
    public class Pedido
    {
        //Atributos

        private string Nombre { get; set; }

        public void SetNombre(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
                this.Nombre = nombre;
            else
                this.Nombre = "";
        }
        public string GetNombre()
        {
            return Nombre;
        }
        private double Precio { get; set; }

        public void SetPrecio(double precio)
        {
            if (precio != null)
                this.Precio = precio;
            else
                this.Precio = 0;
        }
        public double GetPrecio()
        {
            return Precio;
        }
        private int ID { get; set; }

        public void SetNumero(int numero)
        {
            if (ID<=0)
            {
                this.ID = numero;
            }
            else
            {
                this.ID = 0;
            }            
        }
        public int GetNumero()
        {
            return ID;
        }
        private DateTime Fecha { get; set; }

        public void SetFecha(DateTime fecha)
        {
            if (Fecha !=null )
                this.Fecha = fecha;
        }
        public DateTime GetFecha()
        {
            return Fecha;
        }
        //Constructores
        public Pedido()
        {
        }
        public string ToString()
        {
            return $"-Numero de Pedido: {ID} -Nombre del producto: {Nombre} -Precio: {Precio} -Fecha de Pedido: {Fecha}";
        }

        public Pedido(int numero, DateTime fecha, string nombre, double precio)
        {
            this.ID = numero;
            this.Fecha = fecha;
            this.Precio= precio;
            this.Nombre = nombre;
        }

        private List<string> productoPedido
        {
            get => default;
            set
            {
            }
        }

        public Producto Producto
        {
            get => default;
            set
            {
            }
        }
    }

    public class Class1
    {
    }
}
