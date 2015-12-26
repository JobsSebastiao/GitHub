using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace testes_alura.View
{
    public partial class FrmReader : Form
    {
        public FrmReader()
        {
            InitializeComponent();
        }

        private void FrmReader_Load(object sender, EventArgs e)
        {
            if (File.Exists("texto.txt"))
            {
                Stream entrada = File.Open("texto.txt", FileMode.Open);
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string texto = leitor.ReadToEnd();

                    while (texto != null)
                    {
                        textoLousa.Text += texto;
                        texto = leitor.ReadLine();
                    }
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream saida = File.Open("texto.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);

            escritor.Write(textoLousa.Text);

          
            escritor.Close();
            saida.Close();
        }
    }
}
