using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TitaniumColector
{
    public static class MainConfig
    {
        private static int intScreenHeigth;
        private static int intScreenWidth;
        public const int intPositionX = 0;
        public const int intPositionY = 0;
        private static string strVersaoSO;
        private static string HostName { get; set; }
        public static string DeviceIp { get; set; }

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
            IPAddress addr = ipEntry.AddressList[2];
            DeviceIp = addr.ToString() ;
        }

        public static void setMainConfigurations()
        {
            capturaScreenHeight();
            capturaScreenWeight();
            capturaVersãoSo();
            capturaHostName();
            capturaIp();
        }

    }
}
