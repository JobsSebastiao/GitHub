using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TitaniumColector.Classes.Model
{
    class Embalagem
    {

        private Int32 codigo;
        private String nome;
        private Int32 produtoEmbalagem;
        private Double quantidade;
        private PadraoEmbalagem isPadrao;
        private Int32 tipoEmbalagem;
        private String ean13Embalagem;

        public enum PadraoEmbalagem { NAOPADRAO = 0, PADRAO = 1 }


        public Embalagem() { }

        public Embalagem(Int32 codigo,String nome,Int32 produtoEmb,Double qtd,
            PadraoEmbalagem isPadrao,Int32 tipo,String ean13Emb) 
        {

            this.Codigo = codigo;
            this.Nome = nome;
            this.ProdutoEmbalagem = produtoEmb;
            this.Quantidade = qtd;
            this.IsPadrao = isPadrao;
            this.TipoEmbalagem = tipo;
            this.Ean13Embalagem = ean13Emb;

        }


    #region "GET E SETS"

        public String Ean13Embalagem
        {
            get { return ean13Embalagem; }
            set { ean13Embalagem = value; }
        }

        public Int32 TipoEmbalagem
        {
            get { return tipoEmbalagem; }
            set { tipoEmbalagem = value; }
        }

        public PadraoEmbalagem IsPadrao
        {
            get { return isPadrao; }
            set { isPadrao = value; }
        }

        public Double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public Int32 ProdutoEmbalagem
        {
            get { return produtoEmbalagem; }
            set { produtoEmbalagem = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Int32 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    #endregion
        
    }
}
