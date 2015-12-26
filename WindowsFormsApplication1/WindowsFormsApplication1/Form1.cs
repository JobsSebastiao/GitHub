using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //multipliN(10);
            MessageBox.Show(fibo(30).ToString());
        }

        public void multipliN(int n)
        {
            string mensagem = "";


            for (int i = 1; i <= n; i++)
            { 
                for (int j = 1; j <= i; j++)
                {
                    mensagem += (i * j).ToString() + " ";
                }
                mensagem += "\n"; 
            }

            MessageBox.Show(mensagem);

        }

        static long fibo(int n) {
            return (n < 2) ? n : fibo(n - 1) + fibo(n - 2);
        }

    }
}
