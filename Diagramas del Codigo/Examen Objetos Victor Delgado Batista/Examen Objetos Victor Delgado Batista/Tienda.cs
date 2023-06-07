namespace Examen_Objetos_Victor_Delgado_Batista
{
    public class Tienda
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

        private int NumTienda { get; set; }

        public void SetNumTienda(int telefono)
        {
            if (telefono != 0)
            {
                this.NumTienda = telefono;
            }
            else
            {
                this.NumTienda = 0;
            }
        }
        public int GetNumTienda()
        {
            return NumTienda;
        }
        //Constructores
        public Tienda() { }

        public string ToString()
        {
            return $"-Nombre de encargado {Nombre} -Telefono de la tienda {NumTienda}";
        }

        public Tienda(string nombre, int telefono)
        {
            this.Nombre = nombre;
            this.NumTienda = telefono;
        }
    }
}
