using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes_alura
{
    public class Conta
    {
        public double Saldo { get;  set; }
        public int Numero { get; set; }
        public string Titular { get; set; }
        public static int contador = 0;

        public Conta()
        {
            contador++;
        }

        public Conta(String nome,int numero,double saldo)
        {
            this.Titular = nome;
            this.Numero = numero;
            this.Saldo = saldo;
            contador++;
        }

        public virtual void deposita(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor informado é inválido!");

                this.Saldo += valor;
       }

        public virtual void saca(double valorSaque)
        {

            if (valorSaque < 0)
                throw new ArgumentException("O valor informado é inválido");
            if (this.Saldo - valorSaque < 0)
                throw new SaldoInsuficienteException("Você não possui saldo suficiente!");
            this.Saldo -= valorSaque;
  
        }

        public override string ToString()
        {
            return this.Titular;
        }

        public void transferir(Conta contaOutra,double  valor)
        {
            try
            {
                this.saca(valor);
                contaOutra.deposita(valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }

}
