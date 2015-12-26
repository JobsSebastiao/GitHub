using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes_alura.View;

namespace testes_alura
{
    public partial class Form1 : Form
    {
        Conta[] conta = new Conta[3];
        Conta contaEmUso;
        Conta contaTransferencia;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            conta[Conta.contador] = new Conta { Titular = "Victor",Saldo=250.0,Numero =1 };
            conta[Conta.contador] = new ContaCorrente { Titular = "Juvenal", Saldo = 290.0, Numero = 3 };
            conta[Conta.contador] = new ContaPoupanca { Titular = "Isidio", Saldo = 440.0, Numero = 2};
            carregarComboContas(comboContas);
            carregarComboContas(comboBox1);
        }

        private void botaoDeposita_Click(object sender, EventArgs e)
        {
            double i;

            if (!String.IsNullOrEmpty(textoValor.Text) && double.TryParse(textoValor.Text, out i))
            {
                contaEmUso.deposita(Convert.ToDouble(textoValor.Text));
                mostraConta(contaEmUso); 
                return;
            }

            MessageBox.Show("informar o valor a ser depositado!!\n o valor deve ser número ex(\"20.50\") ");
        }

        internal void cadastrarConta(Conta cadastraConta)
        {
            throw new NotImplementedException();
        }

        public void mostraConta(Conta conta)
        {

            this.textoNumero.Text = Convert.ToString(conta.Numero);
            this.textoSaldo.Text = Convert.ToString(conta.Saldo);
            this.textoTitular.Text = Convert.ToString(conta.Titular);   
        }

        private void botaoSacar_Click(object sender, EventArgs e)
        {
            double i;

            try
            {
                if (!String.IsNullOrEmpty(textoValor.Text) && double.TryParse(textoValor.Text, out i))
                {
                    contaEmUso.saca(i);
                    mostraConta(contaEmUso);
                    return;
                }

                MessageBox.Show("informar o valor a ser depositado!!\n o valor deve ser número ex(\"20.50\") ");

            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show("Depositar() "+ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Depositar() " +ex.Message);
            }
            
        }

        private void carregarComboContas(ComboBox combo)
        {
            foreach (Conta conta  in this.conta)
            {
                if (conta != null)
                {
                    combo.Items.Add(conta.Titular);
                    combo.ValueMember = Convert.ToString(conta.Numero);
                }
            }

            combo.SelectedIndex = 0;
            contaTransferencia = contaEmUso = conta[0];
            mostraConta(contaEmUso);
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            contaEmUso = conta[comboContas.SelectedIndex];
            mostraConta(contaEmUso);
        }

        private void transferir(Conta sacador,Conta receptor,double valor)
        {
            sacador.transferir(receptor, valor);
        }

        private void botaoTransferir_Click(object sender, EventArgs e)
        {
            if (contaEmUso != contaTransferencia)
            {
                transferir(contaEmUso, contaTransferencia, Convert.ToDouble(textoValor.Text));
                mostraConta(contaEmUso);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            contaTransferencia = conta[comboBox1.SelectedIndex];
            mostraConta(contaEmUso);
        }

       

        private void botaoCadastrar_Click(object sender, EventArgs e)
        {
            CadastroConta cadastro = new CadastroConta(this);
            cadastro.Show();
        }

        public void remover(int index)
        {
            this.conta[index] = null;
            organizarContasAposRemocao(index);
        }

        public void organizarContasAposRemocao(int indexRemovido)
        {
            for (int i = indexRemovido; i < conta.Length; i++)
            {
                conta[i] = conta[i + 1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReader lousa = new FrmReader();
            lousa.Show();
        }
    }
}
