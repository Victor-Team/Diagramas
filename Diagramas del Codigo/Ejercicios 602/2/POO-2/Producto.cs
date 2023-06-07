namespace POO_2
{
    public class Producto
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
        //Constructores
        public Producto()
        {
        }
        public string ToString()
        {
            return $"-Nombre: {Nombre} -Precio: {Precio}";
        }

        public Producto(string nombre, double precio)
        {
            this.Nombre = nombre;
            this.Precio = precio;
        }


    }

    public class Producto
    {
    }
}
