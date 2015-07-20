namespace TitaniumColector
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainmnuLogin;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            //this.mainmnuLogin = new System.Windows.Forms.MainMenu();
            this.panelFrmLogin = new System.Windows.Forms.Panel();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.lbSenha = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.btSair = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.pboxFrmLogin = new System.Windows.Forms.PictureBox();
            this.ImgLogin = new System.Windows.Forms.ImageList();
            this.panelFrmLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFrmLogin
            // 
            this.panelFrmLogin.Controls.Add(this.lbDescricao);
            this.panelFrmLogin.Controls.Add(this.txtSenha);
            this.panelFrmLogin.Controls.Add(this.cbUsuario);
            this.panelFrmLogin.Controls.Add(this.lbSenha);
            this.panelFrmLogin.Controls.Add(this.lbUsuario);
            this.panelFrmLogin.Controls.Add(this.btSair);
            this.panelFrmLogin.Controls.Add(this.btLogin);
            this.panelFrmLogin.Controls.Add(this.pboxFrmLogin);
            this.panelFrmLogin.Location = new System.Drawing.Point(0, 0);
            this.panelFrmLogin.Name = "panelFrmLogin";
            this.panelFrmLogin.Size = new System.Drawing.Size(345, 455);
            // 
            // lbDescricao
            // 
            this.lbDescricao.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lbDescricao.Location = new System.Drawing.Point(30, 20);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(100, 20);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(85, 296);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 23);
            this.txtSenha.TabIndex = 7;
            // 
            // cbUsuario
            // 
            this.cbUsuario.Location = new System.Drawing.Point(85, 245);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(100, 23);
            this.cbUsuario.TabIndex = 6;
            // 
            // lbSenha
            // 
            this.lbSenha.Location = new System.Drawing.Point(25, 299);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(52, 20);
            this.lbSenha.Text = "Senha :";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Location = new System.Drawing.Point(19, 247);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(62, 20);
            this.lbUsuario.Text = "Usuário :";
            // 
            // btSair
            // 
            this.btSair.Location = new System.Drawing.Point(182, 354);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(72, 20);
            this.btSair.TabIndex = 2;
            this.btSair.Text = "Sair";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(85, 354);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(72, 20);
            this.btLogin.TabIndex = 1;
            this.btLogin.Text = "Login";
            // 
            // pboxFrmLogin
            // 
            this.pboxFrmLogin.Location = new System.Drawing.Point(0, 0);
            this.pboxFrmLogin.Name = "pboxFrmLogin";
            this.pboxFrmLogin.Size = new System.Drawing.Size(345, 77);
            this.ImgLogin.Images.Clear();
            this.ImgLogin.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(346, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panelFrmLogin);
            this.Menu = this.mainmnuLogin;
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelFrmLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFrmLogin;
        private System.Windows.Forms.PictureBox pboxFrmLogin;
        private System.Windows.Forms.ImageList ImgLogin;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label lbDescricao;
    }
}

