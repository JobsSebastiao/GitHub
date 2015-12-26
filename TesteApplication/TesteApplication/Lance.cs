namespace TesteApplication
{
    public class Lance
    {
        private Usuario user;
        public double ValorLance{ get; set; }

        public Lance(Usuario user,double valorLance)
        {
            this.user = user;
            this.ValorLance = valorLance;
        }
    }
}