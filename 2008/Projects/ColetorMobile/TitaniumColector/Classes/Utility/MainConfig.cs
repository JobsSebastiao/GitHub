using System;
using System.Drawing;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TitaniumColector
{
    public static class MainConfig
    {

        private static string strVersaoSO;
        public static string HostName { get; set; }
        public static string DeviceIp { get; set; }
        private static string strUsuarioLogado;
        private static int intUsuarioLogado;
        private static Size screenSize;
        private static Size clienteSize;
        private static Int64 intCodigoAcesso;
        private static Font fontPadraoRegular;
        private static Font fontPadraoBold;
        private static Font fontGrande;

        //Contantes
        public const int intPositionX = 0;
        public const int intPositionY = 0;
        public const Char PasswordChar = '*';

        

        public static string VersaoSO
        {
            get {  return strVersaoSO != null ? strVersaoSO : "ND"; }

            set
            {
                if (value != null)
                {
                    strVersaoSO = value.Trim();
                }
            }
        }

        public static string UsuarioLogado 
        { 
            get {  return strUsuarioLogado; }
            set 
            {
                if (!(String.IsNullOrEmpty(value)))
                {
                    strUsuarioLogado = (string)value;
                }
            }
        }

        public static int CodigoUsuarioLogado
        {
            get { return intUsuarioLogado;}
            set { MainConfig.intUsuarioLogado = value;}
        }

        public static Font FontPadraoRegular
        {
            get  {  return fontPadraoRegular; }
            set  { fontPadraoRegular = value; }
        }

        public static Font FontPadraoBold
        {
            get {  return fontPadraoBold; }
            set { fontPadraoBold = value; }
        }

        public static Font FontGrandeRegular
        {
            get { return fontGrande; }
            set { fontGrande = value; }
        }

        public static Int64 CodigoAcesso
        {
            get  {  return intCodigoAcesso; }
            set  {  intCodigoAcesso = value; }
        }

        public static Size ScreenSize
        {
            get { return MainConfig.screenSize; }
            set { MainConfig.screenSize = value; }
        }

        public static Size ClienteSize
        {
            get { return MainConfig.clienteSize; }
            set { MainConfig.clienteSize = value; }
        }


        public static void setMainConfigurations()
        {
            defineScreenSize();
            capturaVersãoSo();
            capturaHostName();
            capturaIp();
            defineFontPadraoRegular();
            defineFontPadraoBold();
            defineFontGrandeRegular();
        }

        private static void defineScreenSize() 
        {
            Size size = new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            ScreenSize = (size);
        }

        public static void defineClienteSize(Size size)
        {
            ClienteSize = (size);
        }

        private static void capturaVersãoSo()
        {
            VersaoSO  = Environment.OSVersion.ToString();
        }

        private static void capturaHostName()
        {
           string hostName = System.Net.Dns.GetHostName();

           HostName = hostName;
        }

        private static void capturaIp()
        {
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(HostName);
            IPAddress addr = ipEntry.AddressList[ipEntry.AddressList.Length-1];
            DeviceIp = addr.ToString() ;
        }

        private static void defineFontPadraoRegular() 
        {
            Single tamanho = new Single();
            tamanho = 10F;
            FontStyle style = new FontStyle();
            style = FontStyle.Regular;
            fontPadraoRegular = new System.Drawing.Font("Arial",tamanho, style);

        }

        private static void defineFontPadraoBold()
        {
            Single tamanho = new Single();
            tamanho = 10F;
            FontStyle style = new FontStyle();
            style = FontStyle.Bold;
            fontPadraoBold = new System.Drawing.Font("Arial", tamanho, style);

        }

        private static void defineFontGrandeRegular()
        {
            Single tamanho = new Single();
            tamanho = 20F;
            FontStyle style = new FontStyle();
            style = FontStyle.Regular;
            FontGrandeRegular = new System.Drawing.Font("Arial", tamanho, style);
        }

        public static SizeF sizeStringEmPixel(string text,Font font)
        {
            SizeF size = new SizeF();
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
               size = graphics.MeasureString(text ,font);
            }
            return size;
        }

        /// <summary>
        /// Carregar Combox a partir de um List carregado com um tipo de objeto.
        /// </summary>
        /// <param name="cb">ComboBox a ser preenchida</param>
        /// <param name="objectList">List preenchida com um tipo de Objeto</param>
        /// <param name="displayName">parâmetro do objeto a ser mostrado na ComboBox</param>
        /// <param name="columnName">parâmetro que terá o seu valor utilizado na ComboBox. </param>
        public static void carregarComboBox(System.Windows.Forms.ComboBox cb, List<object> objectList, string displayName, string columnName)
        {
            cb.Items.Clear();
            cb.DataSource = objectList;
            cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb.DisplayMember = displayName;
            cb.ValueMember = columnName;
            cb.SelectedItem = null;
        }

        public static Control GetFocusedControl(Control parent)
        {
            if (parent.Focused)
            {
                return parent;
            }
            foreach (Control ctrl in parent.Controls)
            {
                Control temp = GetFocusedControl(ctrl);
                if (temp != null)
                {
                    return temp;
                }
            }
            return null;

        }


    }
}
