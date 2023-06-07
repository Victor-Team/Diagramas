using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Objetos_Victor_Delgado_Batista
{
    public class Alquileres : Juegos
    {
        private string NombreCliente { get; set; }

        public void SetNombreCliente(string nombre)
        {
            if (nombre != null)
            {
                this.NombreCliente = nombre;
            }
            else
            {
                this.NombreCliente = null;
            }
        }
        public string GetNombreCliente()
        {
            return NombreCliente;
        }
        private string Nombre { get; set; }

        public void SetNombre(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                this.Nombre = nombre;
            }
            else
            {
                this.Nombre = null;
            }
        }
        public string GetNombre()
        {
            return Nombre;
        }

        public Alquileres() { }

        public Alquileres(string nombreCliente, string nombre)
        {
            NombreCliente = nombreCliente;
            Nombre = nombre;
        }
    }
}
