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
using TitaniumColector.Forms;
using System.Reflection;
using System.Collections;


namespace TitaniumColector
{
    public partial class frmLogin : Form
    {   
        
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

        //PRINCIPAIS MÉTODOS DO FORMULÁRIO.
        #region "Métodos Principais"  


        /// <summary>
        /// Configurações do fomulário.
        /// </summary>
        private void configFrmLogin() 
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(MainConfig.ScreenWidth, MainConfig.ScreenHeigth);
            this.configControls();
            this.cbUsuario.Focus();
            this.ResumeLayout();
        }

        /// <summary>
        /// Carrega a combo de usuários
        /// </summary>
        private void carregarComboUsuario()
        {
            dt = new DataTable("Usuario");
            StringBuilder sbSql01 = new StringBuilder();
            sbSql01.Append(" SELECT codigoUSUARIO as Codigo,pastaUSUARIO as Pasta,nomeUSUARIO as Nome,");
            sbSql01.Append(" senhaUSUARIO as Senha,nomecompletoUSUARIO as NomeCompleto,ativoUSUARIO as StatusUsuario");
            sbSql01.Append(" FROM tb0201_usuarios ");
            sbSql01.Append(" ORDER BY nomeUSUARIO ");
            this.sql01 = sbSql01.ToString();

            listUsuario = new List<object>(this.fillArrayListUsuarios(dt, this.sql01));
            this.preencheComboBoxUsuario(cbUsuario, listUsuario, Usuario.usuarioProperty.NOME, false);

        }


        /// <summary>
        /// Preenche um List com objetos da classe Usuario
        /// </summary>
        /// <param name="dt">Data table utilizado para armazenar os dados vindos da base de dados.</param>
        /// <param name="sql01">Comando Sql que retorna dados para cada usuário.</param>
        /// <returns></returns>
        private List<object> fillArrayListUsuarios(DataTable dt, string sql01)
        {
            Usuario.statusUsuario status;

            List<object> listUsuario = new List<object>();
            DataRow dr = null;
            
            //'preenche um DataTable
           SqlServerConn.fillDataTable(dt, sql01);

            foreach (DataRow dr_loopVariable in dt.Rows)
            {
                dr = dr_loopVariable;
                if (Convert.ToInt32(dr["StatusUsuario"]) == 0) 
                {
                 status = Usuario.statusUsuario.DESATIVADO;  
                }else
                {
                    status = Usuario.statusUsuario.ATIVO;
                }
                objUsuario = new Usuario(Convert.ToInt32(dr["Codigo"]), Convert.ToInt32(dr["Pasta"]),(string)dr["Nome"], (string)dr["Senha"],(string)dr["NomeCompleto"],status);
                listUsuario.Add(objUsuario);
            }

            return listUsuario;

        }

        /// <summary>
        /// Preenche a ComboBox com um atributo de classe Usuario.
        /// </summary>
        /// <param name="cb">ComboBox a ser Preenchida</param>
        /// <param name="listUsuario">List carregada com objeto do tipo Usuario</param>
        /// <param name="prop">O atributo que será utilizado para carregar a ComboBox</param>
        /// <param name="dataSource">(TRUE)Define que a combo irá utilizar os dados da List como seu DataSource.
        ///                          (FALSE)Será feito um Loop nos objetos contidos na List não incluíndo na ComboBox os 
        ///                                 usuários com o statusUSUARIO = 0 (DESATIVADOS.)
        /// </param>
        private void preencheComboBoxUsuario(ComboBox cb, List<object> listUsuario, Usuario.usuarioProperty prop,bool useDataSource)
        {
            string columnName = null;
            string displayName = null;

            if (useDataSource == true)
            {

                switch (prop)
                {

                    case Usuario.usuarioProperty.CODIGO:
                        columnName = "Codigo";
                        displayName = "Codigo";
                        break;
                    case Usuario.usuarioProperty.NOME:
                        columnName = "Nome";
                        displayName = "Nome";
                        break;
                    case Usuario.usuarioProperty.NOMECOMPLETO:
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
                
                cb.Items.Clear();

                //Loop em cada objeto contido no array
                objUsuarioLoop = new Usuario();
                foreach (Usuario user in listUsuario)
                {

                    objUsuarioLoop = user;

                    if (user.StatusUsuario == Usuario.statusUsuario.ATIVO) 
                    {
                        switch (prop)
                        {

                            case Usuario.usuarioProperty.CODIGO:
                                cb.DisplayMember = "Codigo";
                                cb.ValueMember = "Codigo";
                                cb.Items.Add(objUsuarioLoop.Codigo);
                                continue;
                            case Usuario.usuarioProperty.NOME:
                                cb.DisplayMember = "Nome";
                                cb.ValueMember = "Nome";
                                cb.Items.Add(objUsuarioLoop);
                                continue;
                            case Usuario.usuarioProperty.NOMECOMPLETO:

                                cb.DisplayMember = "NomeCompleto";
                                cb.ValueMember = "NomeCompleto";
                                cb.Items.Add(objUsuarioLoop.NomeCompleto);
                                continue;
                            default:
                                cb.DisplayMember = "Nome";
                                cb.ValueMember = "Nome";
                                cb.Items.Add(objUsuarioLoop.NomeCompleto);
                                break;
                        }

                    }

                }
                objUsuarioLoop = null;
            }

        }

        /// <summary>
        /// Válida a combo de usuário antes que o foco seja mudado para a TextBox Senha.
        /// </summary>
        /// <param name="e">Tecla digitada</param>
        /// <remarks>Para que a validação seja realizada a tecla enviada deve ser o Enter  char(13)</remarks>
        private void validarComboUsuario(KeyEventArgs e)
        {

            if ((e.KeyValue == (char)Keys.Enter))
            {
                if (cbUsuario.SelectedItem != null && txtSenha.Text != "")
                {
                    btLogin.Focus();
                }
                else if (cbUsuario.SelectedItem != null)
                {
                    txtSenha.Enabled = true;
                    txtSenha.Text = "";
                    txtSenha.Focus();
                }
            }
            else if ((e.KeyValue == (char)Keys.Space))
            {
                cbUsuario.Text = cbUsuario.Text.Trim();
                cbUsuario.SelectionStart = cbUsuario.Text.Length + 1;
            }
        }

        private void Logar()
        {
            if (cbUsuario.SelectedItem != null && txtSenha.Text.Trim() != "")
            {

                if (cbUsuario.SelectedItem != null)
                {
                    objUsuario = new Usuario();
                    objUsuario = (Usuario)cbUsuario.SelectedItem;
                    if (objUsuario.validaUsuario(cbUsuario.SelectedItem, cbUsuario.Text, txtSenha.Text))
                    {
                        MainConfig.CodigoAcesso = (Int64)objUsuario.registrarAcesso(objUsuario, Usuario.statusLogin.LOGADO);
                        this.cbUsuario.Text = "";
                        this.txtSenha.Text = "";
                        FrmAcao frmAcao = new FrmAcao();
                        frmAcao.Show();
                        this.Hide();
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
                if (cbUsuario.SelectedItem != null && txtSenha.Text.Trim() == "")
                {
                    txtSenha.Text = "";
                    txtSenha.Focus();
                }
                else
                {
                    cbUsuario.Text = "";
                    cbUsuario.Focus();
                }
            }
        }


        #endregion  


        //MÉTODOS COMUNS AO FORMULÁRIO
        #region 

        //               //
        // CB_USUARIO    //
        //               //

        private void cbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                cbUsuario.Text = "";
            }
        }

        private void cbUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            this.validarComboUsuario(e);
        }


        private void cbUsuario_Validate(KeyPressEventArgs e)
        {
            this.validarComboUsuario(new KeyEventArgs(Keys.Enter));
        }


        private void cbUsuario_GotFocus(object sender, EventArgs e)
        {
            cbUsuario.Text = "";
            txtSenha.Text = "";
        }

        private void cbUsuario_LostFocus(object sender, EventArgs e)
        {
            if (cbUsuario.Text != null && cbUsuario.SelectedItem != null)
            {
                this.validarComboUsuario(new KeyEventArgs(Keys.Enter));
            }
            else if (cbUsuario.SelectedItem == null)
            {
                cbUsuario.Focus();
            }
        }


        //               //
        //   TXT_SENHA   //
        //               //
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MainConfig.GetFocusedControl(this);
                this.validarComboUsuario(new KeyEventArgs(Keys.Enter));
            }
        }


        //               //
        //  FRM_LOGIN    //
        //               //
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && MainConfig.GetFocusedControl(this) != cbUsuario)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }


        //               //
        //    BUTTONS    //
        //               //
        private void btLogin_Click(object sender, EventArgs e)
        {
            this.Logar();
        }


        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion 
       

        //CONFIGURAÇÂO DOS CONTROLES DURANTE A CARGA DO FORMULARIO
        #region "Configurações de Controls"

        private void configPictureBox()
        {
            this.pboxFrmLogin.Location = new System.Drawing.Point(0, 0);
            this.pboxFrmLogin.Size = new System.Drawing.Size(this.Size.Width, 77);
            //Tamanho da Imagem a ser mostrada no Picture Box
            this.ImgLogin.ImageSize = new Size((int)(this.Size.Width), 77);
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
            sizeString = MainConfig.sizeStringEmPixel(this.lbDescricao.Text, MainConfig.FontGrandeRegular);
            this.lbDescricao.Location = new System.Drawing.Point((int)(MainConfig.ScreenWidth / 2 - sizeString.Width / 2),
                                                                  this.panelFrmLogin.Location.Y + pboxFrmLogin.Size.Height + 10);

            //
            //Label Usuário
            //
            this.lbUsuario.Font = MainConfig.FontPadraoBold;
            this.lbUsuario.Size = new System.Drawing.Size(90, 35);
            this.lbUsuario.Text = "Usuário :";
            this.lbUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            sizeString = MainConfig.sizeStringEmPixel(this.lbUsuario.Text, MainConfig.FontGrandeRegular);
            this.lbUsuario.Location = new System.Drawing.Point((int)(MainConfig.intPositionX + 20),
                                                                  this.lbDescricao.Location.Y + 80);

            //
            //Label Senha
            //
            this.lbSenha.Font = MainConfig.FontPadraoBold;
            this.lbSenha.Text = "Senha :";
            this.lbSenha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            sizeString = MainConfig.sizeStringEmPixel(this.lbSenha.Text, MainConfig.FontGrandeRegular);
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
            sizeString = MainConfig.sizeStringEmPixel(this.lbSenha.Text, MainConfig.FontGrandeRegular);
            this.cbUsuario.Visible = true;
            this.cbUsuario.Size = new System.Drawing.Size(120, 27);
            this.cbUsuario.Location = new System.Drawing.Point((int)(this.lbUsuario.Location.X + this.lbUsuario.Size.Width),
                                                                   this.lbUsuario.Location.Y - 3);
            this.cbUsuario.DropDownStyle = ComboBoxStyle.DropDown;

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
            this.txtSenha.Enabled = false;
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

        #endregion


    }
}