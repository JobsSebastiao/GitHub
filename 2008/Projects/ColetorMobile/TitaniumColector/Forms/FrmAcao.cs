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
            this.controlsConfig();
            
        }

        private void mnuAcao_Logout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
          
        }

        private void mnuAcao_Exit_Click(object sender, EventArgs e)
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