namespace Examen_Objetos_Victor_Delgado_Batista
{
    public class Juegos : Clientes
    {


        //Atributos

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


        private double Precio { get; set; }

        public void SetPrecio(double precio)
        {
            if (precio != 0)
            {
                this.Precio = precio;
            }
            else
            {
                this.Precio = 0;
            }
        }
        public double GetPrecio()
        {
            return Precio;
        }

        private string Alquilado { get; set; }

        public void SetAlquilado(string alquilado)
        {
            if (!String.IsNullOrEmpty(alquilado))
            {
                this.Alquilado = alquilado;
            }
            else
            {
                this.Alquilado = "No alquilado";
            }
        }
        public string GetAlquilado()
        {
            return Alquilado;
        }
        private double Ganancia { get; set; }

        public void SetGanancia(double ganancia)
        {
            if (ganancia != 0)
            {
                this.Ganancia = ganancia;
            }
            else
            {
                this.Ganancia = 0;
            }
        }
        public double GetGanancia()
        {
            return Ganancia;
        }
        //Constructores
        public Juegos()
        {
            //se me ocurrio dejar Alquilado como booleano y aqui transformarlo a string pero no se como
        }

        public string ToString()
        {
            return $"-Nombre del juego: {Nombre} -Precio: {Precio} -Estado del juego: {Alquilado}";
        }

        public Juegos(string nombre, double precio, string alquilado, double Ganancia)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Alquilado = alquilado;
            this.Ganancia = Ganancia;
        }
    }
}
