using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.Utility;

namespace TitaniumColector.Forms
{
    public partial class FrmAcao : Form
    {

        public FrmAcao()
        {
            InitializeComponent();
            this.configForm();
            
        }

        private void configMenu() 
        {

            ////menuItem Opções
            this.mnuAcao_Opcoes = new System.Windows.Forms.MenuItem();
            this.mnuAcao_Opcoes.Text = "Opção";
            this.mnuAcao_Opcoes.Enabled = true;

            ////menuItem Exit
            this.mnuAcao_Exit = new System.Windows.Forms.MenuItem();
            this.mnuAcao_Exit.Text = "Exit";
            this.mnuAcao_Exit.Enabled = true;
            this.mnuAcao_Exit.Click += new EventHandler(mnuAcao_Exit_Click);

            ////MenuItem Logout
            this.mnuAcao_Logout = new System.Windows.Forms.MenuItem();
            this.mnuAcao_Logout.Text = "Logout";
            this.mnuAcao_Logout.Enabled = true;
            this.mnuAcao_Logout.Click += new EventHandler(mnuAcao_Logout_Click);

            ////Adiciona os menus ao MenuPrincipal.
            this.menuFrmAcao = new System.Windows.Forms.MainMenu();
            this.menuFrmAcao.MenuItems.Add(mnuAcao_Opcoes);
            this.mnuAcao_Opcoes.MenuItems.Add(this.mnuAcao_Exit);
            this.mnuAcao_Opcoes.MenuItems.Add(this.mnuAcao_Logout);
            this.Menu = this.menuFrmAcao;
        }

        private void configForm()
        {
            this.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width, MainConfig.ScreenSize.Height);
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.configMenu();
            this.configButton();
        }

        private void configButton()
        {
            this.btnVenda.Location = new System.Drawing.Point(MainConfig.intPositionX + 20 ,MainConfig.intPositionY + 30);
            this.btnVenda.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 40, MainConfig.ScreenSize.Height / 3);
            this.btnVenda.Text = "Entrada";
            this.btnVenda.Font = MainConfig.FontPadraoBold;

            this.btnSaida.Location = new System.Drawing.Point(MainConfig.intPositionX + 20, btnVenda.Location.Y+ btnVenda.Size.Height + 10);
            this.btnSaida.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 40, MainConfig.ScreenSize.Height / 3);
            this.btnSaida.Text = "Saída";
            this.btnSaida.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaida.Font = MainConfig.FontPadraoBold;
        }

        void mnuAcao_Logout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
          
        }

        void mnuAcao_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            FrmProposta proposta = new FrmProposta();
            proposta.Show();
        }




    }
}