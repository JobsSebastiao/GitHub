using System;
using System.Drawing;
using System.Net;

namespace TitaniumColector
{
    public static class MainConfig
    {
        private static int intScreenHeigth;
        private static int intScreenWidth;
        private static string strVersaoSO;
        private static string HostName { get; set; }
        private static string DeviceIp { get; set; }
        private static string strUsuarioLogado;
        private static int intUsuarioLogado;
        private static Font fontPadraoRegular;
        private static Font fontPadraoBold;
        private static Font fontGrande;

        //Contantes
        public const int intPositionX = 0;
        public const int intPositionY = 0;
        public const Char PasswordChar = '*';

         public static int ScreenHeigth
        {
            get 
            {
                return intScreenHeigth;
            }
            set 
            {
                if ((value > 0))
                {
                    intScreenHeigth = value;
                }
            }

        }

         public static int ScreenWidth
        {
            get
            {
                return intScreenWidth;
            }
            set
            {
                if ((value > 0))
                {
                    intScreenWidth = value;
                }
            }

        }

        public static string VersaoSO
        {
            get
            {
                return strVersaoSO != null ? strVersaoSO : "ND";
            }

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
            get
            {
                return strUsuarioLogado;
            }
            set 
            {
                if (!(String.IsNullOrEmpty(value)))
                {
                    strUsuarioLogado = (string)value;
                }
            }
        }

        public static int codigoUsuarioLogado
        {
            get 
            {
                return intUsuarioLogado; 
            }
            set 
            { 
                MainConfig.intUsuarioLogado = value; 
            }
        }

        public static Font FontPadraoRegular
        {
            get 
            { 
                return fontPadraoRegular; 
            }
            set 
            { 
                fontPadraoRegular = value; 
            }
        }

        public static Font FontPadraoBold
        {
            get
            {
                return fontPadraoBold;
            }
            set
            {
                fontPadraoBold = value;
            }
        }

        public static Font FontGrandeRegular
        {
            get
            {
                return fontGrande;
            }
            set
            {
                fontGrande = value;
            }
        }

        public static void setMainConfigurations()
        {
            capturaScreenHeight();
            capturaScreenWeight();
            capturaVersãoSo();
            capturaHostName();
            capturaIp();
            defineFontPadraoRegular();
            defineFontPadraoBold();
            defineFontGrandeRegular();
        }

        private static void capturaScreenHeight()
        {
            ScreenHeigth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        }

        private static void capturaScreenWeight()
        {
            ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
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

        public static SizeF sizeXYString(string text,Font font)
        {
            SizeF size = new SizeF();
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
               size = graphics.MeasureString(text ,font);
            }
            return size;
        }

    }
}
