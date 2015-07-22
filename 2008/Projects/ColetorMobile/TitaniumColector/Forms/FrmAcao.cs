using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitaniumColector.Forms
{
    public partial class FrmAcao : Form
    {

        private System.Windows.Forms.MenuItem menuItemOpcao;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemLogin;

        public FrmAcao()
        {
            InitializeComponent();
            this.configMenu();
        }

        private void configMenu() 
        {

            ////menuItem Opções
            this.menuItemOpcao = new System.Windows.Forms.MenuItem();
            this.menuItemOpcao.Text = "Opção";
            this.menuItemOpcao.Enabled = true;


            ////menuItem Exit
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Enabled = true;

            ////MenuItem Logi
            this.menuItemLogin = new System.Windows.Forms.MenuItem();
            this.menuItemLogin.Text = "Logar";
            this.menuItemLogin.Enabled = true;

            //adiciona os menus ao menuprincipal.
            this.menuFrmAcao.MenuItems.Add(this.menuItemOpcao);
            this.menuItemOpcao.MenuItems.Add(this.menuItemLogin);
            this.menuItemOpcao.MenuItems.Add(this.menuItemExit);

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}