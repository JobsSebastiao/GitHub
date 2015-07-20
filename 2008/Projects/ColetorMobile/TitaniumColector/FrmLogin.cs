using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.SqlServer;
using System.Reflection;


namespace TitaniumColector
{
    public partial class frmLogin : Form
    {
        private System.Windows.Forms.MenuItem menuItemOpcao;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemLogin;
        private SizeF sizeString;

        public frmLogin()
        {
            
            InitializeComponent();
            MainConfig.setMainConfigurations();
            SqlServerConn.configuraStrConnection(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "strConn.txt");
             if (SqlServerConn.testConnection() == false) 
            {
                Application.Exit();
            }
            this.configFrmLogin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void configFrmLogin() 
        {
            this.SuspendLayout();
            //tamanho do Form.
            this.Size = new System.Drawing.Size(MainConfig.ScreenWidth, MainConfig.ScreenHeigth);
            this.configPictureBox();
            this.configPainel(); 
            this.configMenuItens();
            this.configLabel();
            this.configComboBox();
            this.configTextBox();
            this.configButton();
            this.ResumeLayout();
        }

        private void configPictureBox() 
        {
            this.pboxFrmLogin.Location = new System.Drawing.Point(0, 0);
            this.pboxFrmLogin.Size = new System.Drawing.Size(this.Size.Width, 77);
            //Tamanho da Imagem a ser mostrada no Picture Box
            this.ImgLogin.ImageSize  = new Size((int)(this.Size.Width)-2,77);
            this.pboxFrmLogin.BackColor = Color.Black;
            this.pboxFrmLogin.Image = ImgLogin.Images[0];
        
        }

        private void configPainel() 
        {
            this.panelFrmLogin.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 53);
            this.panelFrmLogin.BackColor = System.Drawing.SystemColors.ControlLight;
        }


        private void configMenuItens() 
        {
            ////menuItem Opções
            //this.menuItemOpcao = new System.Windows.Forms.MenuItem();
            //this.menuItemOpcao.Text = "Opções";
            //this.menuItemOpcao.Enabled = true;

            ////menuItem Exit
            //this.menuItemExit = new System.Windows.Forms.MenuItem();
            //this.menuItemExit.Text = "Exit";
            //this.menuItemExit.Enabled = true;

            ////MenuItem Logi
            //this.menuItemLogin = new System.Windows.Forms.MenuItem();
            //this.menuItemLogin.Text = "Logar";
            //this.menuItemLogin.Enabled = true;

            //adiciona os menus ao menuprincipal.
            //this.mainmnuLogin.MenuItems.Add(this.menuItemOpcao);
            //this.menuItemOpcao.MenuItems.Add(this.menuItemLogin);
            //this.menuItemOpcao.MenuItems.Add(this.menuItemExit);
        }

        private void configLabel()
        {
            // 
            // Label Descrição
            // 
            this.lbDescricao.Font = MainConfig.FontGrandeRegular;
            this.lbDescricao.Size = new System.Drawing.Size(90, 35);
            this.lbDescricao.Text = "Login :";
            this.lbDescricao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            sizeString = MainConfig.sizeXYString(this.lbDescricao.Text, MainConfig.FontGrandeRegular);
            this.lbDescricao.Location = new System.Drawing.Point((int)(MainConfig.ScreenWidth / 2 - sizeString.Width / 2) ,
                                                                  this.panelFrmLogin.Location.Y+pboxFrmLogin.Size.Height+10);

            //
            //Label Usuário
            //
            this.lbUsuario.Font = MainConfig.FontPadraoBold;
            this.lbUsuario.Size = new System.Drawing.Size(90, 35);
            this.lbUsuario.Text = "Usuário :";
            this.lbUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            sizeString = MainConfig.sizeXYString(this.lbUsuario.Text, MainConfig.FontGrandeRegular);
            this.lbUsuario.Location = new System.Drawing.Point((int)(MainConfig.intPositionX + 20),
                                                                  this.lbDescricao.Location.Y + 80);

            //
            //Label Senha
            //
            this.lbSenha.Font = MainConfig.FontPadraoBold;
            this.lbSenha.Text = "Senha :";
            this.lbSenha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            sizeString = MainConfig.sizeXYString(this.lbSenha.Text, MainConfig.FontGrandeRegular);
            this.lbSenha.Size = new System.Drawing.Size((int)sizeString.Width, (int)sizeString.Height);
            this.lbSenha.Location = new System.Drawing.Point((int)(this.lbUsuario.Location.X + 3),
                                                                   this.lbUsuario.Location.Y + 25);

        }

        private void configComboBox() 
        {
            //
            //ComboBox Usuário
            //
            this.cbUsuario.Font = MainConfig.FontPadraoRegular;
            sizeString = MainConfig.sizeXYString(this.lbSenha.Text, MainConfig.FontGrandeRegular);
            this.cbUsuario.Visible = true;
            this.cbUsuario.Size = new System.Drawing.Size(100, 27);
            this.cbUsuario.Location = new System.Drawing.Point((int)(this.lbUsuario.Location.X + this.lbUsuario.Size.Width),
                                                                   this.lbUsuario.Location.Y-3);

        }

        private void configTextBox()
        {
            //
            // TextBox Senha
            //
            this.txtSenha.Font = MainConfig.FontPadraoRegular;
            this.txtSenha.Text = "";
            this.txtSenha.MaxLength = 12;
            this.txtSenha.PasswordChar = MainConfig.PasswordChar;
            this.txtSenha.Visible = true;
            this.txtSenha.Size = new System.Drawing.Size(100, 23);
            this.txtSenha.Location = new System.Drawing.Point((int)(this.cbUsuario.Location.X),
                                                                    this.lbSenha.Location.Y - 3);
        }

        private void configButton() 
        {
            //
            //Button Login 
            //
            this.btLogin.Font = MainConfig.FontPadraoRegular;
            this.btLogin.Visible = true;
            this.btLogin.Size = new System.Drawing.Size(72, 20);
            this.btLogin.Location = new System.Drawing.Point((int)(MainConfig.ScreenWidth / 2 - btLogin.Size.Width - 3),
                                                                    this.lbSenha.Location.Y + 40);

            //
            //Button Sair
            //
            this.btSair.Font = MainConfig.FontPadraoRegular;
            this.btSair.Visible = true;
            this.btSair.Size = new System.Drawing.Size(72, 20);
            this.btSair.Location = new System.Drawing.Point((int)(MainConfig.ScreenWidth / 2 + 3),
                                                                    this.lbSenha.Location.Y + 40);
            
        }

    }
}