using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Classes;
using TitaniumColector.SqlServer;

namespace TitaniumColector.Forms
{
    public partial class FrmProposta : Form
    {
        private Proposta proposta;
        private SizeF fStringSize;
        private string sql01;



        public FrmProposta()
        {
            InitializeComponent();
            configControls();
            carregaProposta();
            
        }

        public void carregaProposta() 
        {
            DataTable dt = new DataTable("Proposta");
            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,");
            sbSql01.Append("clientePROPOSTA,razaoEMPRESA,ordemseparacaoimpressaPROPOSTA");
            sbSql01.Append(" FROM vwMobile_tb1601_Proposta ");
            this.sql01 = sbSql01.ToString();
            this.fillObjProposta(this.sql01);
            this.preencherForm();
        }

        private void configControls()
        {
            // 
            // lbNumero
            // 
            this.lbNumero.Location = new System.Drawing.Point(MainConfig.intPositionX + 3, MainConfig.intPositionY + 3);
            this.lbNumero.Font  = MainConfig.FontPadraoBold;
            this.lbNumero.Text = "Prop.N° :";
            fStringSize = MainConfig.sizeStringEmPixel(this.lbNumero.Text, MainConfig.FontPadraoBold);
            this.lbNumero.Size = new System.Drawing.Size((int)fStringSize.Width + 2, (int)fStringSize.Height);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(lbNumero.Location.X + lbNumero.Size.Width + 5, lbNumero.Location.Y-3);
            this.txtNumero.Enabled = false;
            this.txtNumero.MaxLength = 12;
            this.txtNumero.Size = new System.Drawing.Size(78, 23);
            this.txtNumero.TabStop = false;

            //
            // lbLiberacao
            // 
            this.lbLiberacao.Location = new System.Drawing.Point(this.txtNumero.Location.X+ txtNumero.Size.Width + 5, this.txtNumero.Location.Y + 3);
            this.lbLiberacao.Text = "Data_Lib.:";
            this.lbLiberacao.Font = MainConfig.FontPadraoBold;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbLiberacao.Text, MainConfig.FontPadraoBold);
            this.lbLiberacao.Size = new System.Drawing.Size((int)fStringSize.Width, (int)fStringSize.Height);

            // 
            // txtDataLiberacao
            // 
            this.txtDataLiberacao.Location = new System.Drawing.Point(this.lbLiberacao.Location.X + lbLiberacao.Size.Width + 5, 
                                                                      this.lbLiberacao.Location.Y - 3 );
            this.txtDataLiberacao.MaxLength = 12;
            this.txtDataLiberacao.Enabled = false;
            this.txtDataLiberacao.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbNumero.Size.Width - txtNumero.Size.Width - lbLiberacao.Size.Width -23, 23);
            this.txtDataLiberacao.TabStop = false;

            //
            // lbCliente
            // 
            this.lbCliente.Location = new System.Drawing.Point(this.lbNumero.Location.X, 
                                                                this.lbNumero.Location.Y + lbNumero.Size.Height + 10);
            this.lbCliente.Text = "Cliente:";
            this.lbCliente.Font = MainConfig.FontPadraoBold;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbCliente.Text, MainConfig.FontPadraoBold);
            this.lbCliente.Size = new System.Drawing.Size((int)fStringSize.Width, (int)fStringSize.Height);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(this.lbCliente.Location.X + this.lbCliente.Size.Width + 2,
                                                                this.lbCliente.Location.Y -3);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Enabled = false;
            this.txtCliente.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbCliente.Size.Width - 10, 23);
            // 
            // lbItemProposta
            // 
            this.lbItemProposta.Font = MainConfig.FontPadraoBold;
            this.lbItemProposta.Text = "Itens_Proposta";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbItemProposta.Text, MainConfig.FontPadraoBold);
            this.lbItemProposta.Size = new System.Drawing.Size((int)fStringSize.Width+2, (int)fStringSize.Height);
            this.lbItemProposta.Location = new System.Drawing.Point(MainConfig.ScreenSize.Width / 2 - lbItemProposta.Size.Width / 2, txtCliente.Location.Y + txtCliente.Size.Height + 3);
            // 
            // dgProposta
            // 

            string str = this.ClientRectangle.Bottom + "\n" + this.ClientSize.Height + "\n" + this.ClientSize.Width + "\n" + MainConfig.ScreenSize.Height + "\n" + MainConfig.ScreenSize.Width;
            int sizeHeigth = txtCliente.Size.Height + txtDataLiberacao.Size.Height + lbItemProposta.Size.Height;
            this.dgProposta.Location = new System.Drawing.Point(MainConfig.intPositionX + 5 , lbItemProposta.Location.Y+lbItemProposta.Size.Height+5);
            this.dgProposta.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 12, this.ClientRectangle.Bottom - dgProposta.Location.Y);
            this.dgProposta.TabIndex = 0;

        }
            

        private Proposta fillObjProposta(string sql01)
        {

            System.Data.SqlClient.SqlDataReader dr = SqlServerConn.fillDataReader(sql01);
            if ((dr.FieldCount > 0))
            {
                while ((dr.Read()))
                {
                    
                    
                    proposta = new Proposta(Convert.ToInt64(dr["codigoPROPOSTA"]), (string)dr["numeroPROPOSTA"], (string)dr["dataLIBERACAOPROPOSTA"],
                                            Convert.ToInt32(dr["clientePROPOSTA"]), (string)dr["razaoEMPRESA"], (Proposta.statusOrdemSeparacao)dr["ordemseparacaoimpressaPROPOSTA"]); 
                }
            }

            SqlServerConn.closeConn();

            return proposta;

        }

        private void  preencherForm()
        {
            this.txtNumero.Text = proposta.Codigo.ToString();
            this.txtDataLiberacao.Text  = proposta.DataLiberacao.Substring(1,10);
            this.txtCliente.Text = proposta.RazaoCliente.ToString();
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmLogin frlLogin = new frmLogin();
            frlLogin.Show();
            this.Hide();
        }

    }
}