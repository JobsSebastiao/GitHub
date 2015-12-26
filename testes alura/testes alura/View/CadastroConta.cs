using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes_alura.View
{
    public partial class CadastroConta : Form
    {
        Conta tipoContaCadastro;
        Form1 appMain;
        public CadastroConta(Form1 appMain)
        {
            this.appMain = appMain;
            InitializeComponent();
        }

        private void CadastroConta_Load(object sender, EventArgs e)
        {
            carregarComboContas();

        }

        private  void carregarComboContas()
        {
            comboTipoConta.Items.Add("Conta Corrente");
            comboTipoConta.Items.Add("Conta Poupança");
            comboTipoConta.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta cadastraConta = selecionaTipoContaCadastro(comboTipoConta.SelectedIndex);
            cadastraConta.Titular = textoNome.Text;
            cadastraConta.Saldo = Convert.ToDouble(textoSaldo.Text);
            cadastraConta.Numero = Conta.contador;
            appMain.cadastrarConta(cadastraConta);

        }

        private Conta selecionaTipoContaCadastro(int conta)
        {
            switch (conta)
            {
                case 0:
                   return  new ContaCorrente();
                case 1:
                    return new ContaPoupanca();
                default:
                    return new ContaCorrente();
            }
        }

        private void comboTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
