using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Objetos_Victor_Delgado_Batista
{
    public  class Clientes
    {
        private string NombreCliente { get; set; }

        public void SetNombreCliente(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
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

        private string NombreJuego { get; set; }

        public void SetNombreJuego(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                this.NombreJuego = nombre;
            }
            else
            {
                this.NombreJuego = null;
            }
        }
        public string GetNombreJuego()
        {
            return NombreJuego;
        }
        public Clientes()
        {

        }

        public string ToString()
        {
            return $"-Nombre del Cliente: {NombreCliente} -Juego Alquilado: {NombreJuego}";
        }
        public Clientes(string nombre, string juego)
        {
            this.NombreCliente = nombre;
            this.NombreJuego = juego;
            
        }

    }
}
