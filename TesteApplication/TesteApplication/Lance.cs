namespace TesteApplication
{
    public class Lance 
    {
        public Usuario Usuario { get; private set; }
        public double ValorLance{ get; set; }

        public Lance(Usuario user,double valorLance)
        {
            this.Usuario = user;
            this.ValorLance = valorLance;
        }
    }
}