using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.SqlServer;
using TitaniumColector.Classes;
using System.Reflection;
using System.Collections;


namespace TitaniumColector
{
    public partial class frmLogin : Form
    {   
        
        //não uso o menu no form Login
        //private System.Windows.Forms.MenuItem menuItemOpcao;
        //private System.Windows.Forms.MenuItem menuItemExit;
        //private System.Windows.Forms.MenuItem menuItemLogin;
        private Usuario objUsuario;
        private Usuario objUsuarioLoop;
        private SizeF sizeString;
        private DataTable dt;
        private string sql01;
        private List<object> listUsuario;


        public frmLogin()
        {
            try
            {
                InitializeComponent();
                MainConfig.setMainConfigurations();
                SqlServerConn.configuraStrConnection(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "strConn.txt");
                if (SqlServerConn.testConnection() == false)
                {
                    Application.Exit();
                }

                this.configFrmLogin();
                this.carregarComboUsuario();
            }
            catch (System.Data.SqlClient.SqlException sqlEx) 
            {
                StringBuilder bdMsg = new StringBuilder();
                bdMsg.Append("Ocorreu um problema durante a tentativa de conexão com a base de dados!");
                bdMsg.AppendLine();
                bdMsg.Append("A aplicação não poderá ser iniciada.");
                bdMsg.AppendLine();
                bdMsg.Append("Description :" + sqlEx.Message);
                bdMsg.AppendLine();
                bdMsg.Append("Source :" + sqlEx.Source);
                string msg = bdMsg.ToString();
                MessageBox.Show(msg, "Conection Error.");
                Application.Exit();
            }
            catch (Exception ex)
            {
                StringBuilder bdMsg = new StringBuilder();
                bdMsg.Append("O sistema não pode ser iniciado.");
                bdMsg.AppendLine();
                bdMsg.Append("Favor contate o administrador do sitema.");
                bdMsg.AppendLine();
                bdMsg.Append("Description :" + ex.Message);
                bdMsg.AppendLine();
                string msg = bdMsg.ToString();
                MessageBox.Show(msg, "Application Error.");
                Application.Exit();
            }

        }

        private void configFrmLogin() 
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(MainConfig.ScreenWidth, MainConfig.ScreenHeigth);
            this.configControls(); 
            this.ResumeLayout();
        }


        //Configuração dos controle exibidos na tela de login
        #region "Configurações de Controls"

        private void configPictureBox() 
        {
            this.pboxFrmLogin.Location = new System.Drawing.Point(0, 0);
            this.pboxFrmLogin.Size = new System.Drawing.Size(this.Size.Width, 77);
            //Tamanho da Imagem a ser mostrada no Picture Box
            this.ImgLogin.ImageSize  = new Size((int)(this.Size.Width),77);
            this.pboxFrmLogin.BackColor = Color.Black;
            this.pboxFrmLogin.Image = ImgLogin.Images[0];
        
        }

        private void configPainel() 
        {
            this.panelFrmLogin.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 53);
            this.panelFrmLogin.BackColor = System.Drawing.SystemColors.ControlLight;
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
            this.cbUsuario.Size = new System.Drawing.Size(120, 27);
            this.cbUsuario.Location = new System.Drawing.Point((int)(this.lbUsuario.Location.X + this.lbUsuario.Size.Width),
                                                                   this.lbUsuario.Location.Y-3);
            this.cbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;

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
            this.txtSenha.Size = new System.Drawing.Size(cbUsuario.Size.Width, 23);
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
        private void configControls() 
        {
            this.configPictureBox();
            this.configPainel();
            this.configLabel();
            this.configComboBox();
            this.configTextBox();
            this.configButton();
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

        #endregion

        private void carregarComboUsuario()
        {
            dt = new DataTable("Usuario");
            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append("SELECT codigoUSUARIO as Codigo,pastaUSUARIO as Pasta,nomeUSUARIO as Nome,");
            sbSql01.Append("senhaUSUARIO as Senha,nomecompletoUSUARIO as NomeCompleto ");
            sbSql01.Append("FROM tb0201_usuarios ");
            sbSql01.Append("ORDER BY nomeUSUARIO ");
            this.sql01 = sbSql01.ToString();

            listUsuario = new List<object>(this.fillArrayListUsuarios(dt, this.sql01));
            this.preencheComboBoxUsuario(cbUsuario, listUsuario, Usuario.usuarioProperty.Nome, true);

            objUsuario = new Usuario();
            objUsuario = (Usuario)listUsuario[0];
        }

        private List<object> fillArrayListUsuarios(DataTable dt, string sql01)
        {

            List<object> listUsuario = new List<object>();
            DataRow dr = null;

            //'preenche um DataTable
           SqlServerConn.fillDataTable(dt, sql01);

            foreach (DataRow dr_loopVariable in dt.Rows)
            {
                dr = dr_loopVariable;
                objUsuario = new Usuario(Convert.ToInt32(dr["Codigo"]), Convert.ToInt32(dr["Pasta"]), (string)dr["Nome"], (string)dr["Senha"], (string)dr["NomeCompleto"]);
                listUsuario.Add(objUsuario);
            }

            return listUsuario;

        }

        /// <summary>
        /// Preenche a ComboBox com um atributo de classe Usuario.
        /// </summary>
        /// <param name="cb">ComboBox a ser Preenchida</param>
        /// <param name="listUsuario">List carregada com objeto do tipo Usuario</param>
        /// <param name="prop"></param>
        /// <param name="dataSource"></param>
        private void preencheComboBoxUsuario(ComboBox cb, List<object> listUsuario, Usuario.usuarioProperty prop,bool dataSource)
        {

            if (dataSource == true)
            {
                string columnName = null;
                string displayName = null;

                switch (prop)
                {

                    case Usuario.usuarioProperty.Codigo:
                        columnName = "Codigo";
                        displayName = "Codigo";
                        break;
                    case Usuario.usuarioProperty.Nome:
                        columnName = "Nome";
                        displayName = "Nome";
                        break;
                    case Usuario.usuarioProperty.NomeCompleto:
                        columnName = "NomeCompleto";
                        displayName = "NomeCompleto";
                        break;
                    default:
                        columnName = "Nome";
                        displayName = "Nome";
                        break;
                }

                cb.Items.Clear();
                cb.DataSource = listUsuario;
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.DisplayMember = displayName;
                cb.ValueMember = columnName;
                cb.SelectedItem = null;
            }
            else 
            {
                string columnName = null;
                cb.Items.Clear();

                //Loop em cada objeto contido no array
                objUsuarioLoop = new Usuario();
                foreach (Usuario user in listUsuario)
                {

                    objUsuarioLoop = user;
                    switch (prop)
                    {

                        case Usuario.usuarioProperty.Codigo:
                            columnName = "Codigo";
                            cb.Items.Add(objUsuarioLoop.Codigo);
                            continue;
                        case Usuario.usuarioProperty.Nome:
                            columnName = "Nome";
                            cb.Items.Add(objUsuarioLoop.Nome);
                            continue;
                        case Usuario.usuarioProperty.NomeCompleto:
                            columnName = "NomeCompleto";
                            cb.Items.Add(objUsuarioLoop.NomeCompleto);
                            continue;
                        default:
                            columnName = "Nome";
                            cb.Items.Add(objUsuarioLoop.NomeCompleto);
                            break;
                    }
                    objUsuarioLoop = null;
                }

                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.DisplayMember = columnName;
                cb.ValueMember = columnName;
            }

        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (cbUsuario.SelectedItem != null && txtSenha.Text != null)
            {
                BindingSource bSource = new BindingSource();
                bSource.DataSource 
                if (cbUsuario.Items.Contains(cbUsuario.Text))
                {
                    objUsuario = new Usuario();
                    objUsuario = (Usuario)cbUsuario.SelectedItem;
                    if (objUsuario.validaUsuario(cbUsuario.SelectedItem, cbUsuario.Text, txtSenha.Text))
                    {
                        MessageBox.Show("Nasceu");
                    }
                    else
                    {
                        MessageBox.Show(" A senha digitada \n é inválida!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        txtSenha.Text = "";
                        txtSenha.Focus();
                    }
                }
            }
            else 
            {
                cbUsuario.Text = "";
                cbUsuario.Focus();
            }
        }
    }
}