namespace TitaniumColector.Forms
{
    partial class FrmAcao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu menuFrmAcao;

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
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSaida = new System.Windows.Forms.Button();
            this.painelFrmAcao = new System.Windows.Forms.Panel();
            this.painelFrmAcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(44, 59);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(256, 129);
            this.btnEntrada.TabIndex = 0;
            this.btnEntrada.Text = "button1";
            // 
            // btnSaida
            // 
            this.btnSaida.Location = new System.Drawing.Point(44, 228);
            this.btnSaida.Name = "btnSaida";
            this.btnSaida.Size = new System.Drawing.Size(256, 129);
            this.btnSaida.TabIndex = 1;
            this.btnSaida.Text = "button2";
            // 
            // painelFrmAcao
            // 
            this.painelFrmAcao.Controls.Add(this.btnEntrada);
            this.painelFrmAcao.Controls.Add(this.btnSaida);
            this.painelFrmAcao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelFrmAcao.Location = new System.Drawing.Point(0, 0);
            this.painelFrmAcao.Name = "painelFrmAcao";
            this.painelFrmAcao.Size = new System.Drawing.Size(346, 455);
            // 
            // FrmAcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(346, 455);
            this.ControlBox = false;
            this.Controls.Add(this.painelFrmAcao);
            this.Name = "FrmAcao";
            this.Text = "FrmAcao";
            this.painelFrmAcao.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.MenuItem mnuAcao_Opcoes;
        private System.Windows.Forms.MenuItem mnuAcao_Exit;
        private System.Windows.Forms.MenuItem mnuAcao_Logout;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSaida;
        private System.Windows.Forms.Panel painelFrmAcao;
    }
}