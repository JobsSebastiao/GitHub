namespace testes_alura.View
{
    partial class CadastroConta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.comboTipoConta = new System.Windows.Forms.ComboBox();
            this.textoNome = new System.Windows.Forms.TextBox();
            this.textoSaldo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboTipoConta
            // 
            this.comboTipoConta.FormattingEnabled = true;
            this.comboTipoConta.Location = new System.Drawing.Point(13, 45);
            this.comboTipoConta.Name = "comboTipoConta";
            this.comboTipoConta.Size = new System.Drawing.Size(177, 21);
            this.comboTipoConta.TabIndex = 0;
            this.comboTipoConta.SelectedIndexChanged += new System.EventHandler(this.comboTipoConta_SelectedIndexChanged);
            // 
            // textoNome
            // 
            this.textoNome.Location = new System.Drawing.Point(13, 89);
            this.textoNome.Name = "textoNome";
            this.textoNome.Size = new System.Drawing.Size(100, 20);
            this.textoNome.TabIndex = 1;
            // 
            // textoSaldo
            // 
            this.textoSaldo.Location = new System.Drawing.Point(13, 125);
            this.textoSaldo.Name = "textoSaldo";
            this.textoSaldo.Size = new System.Drawing.Size(100, 20);
            this.textoSaldo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cadastrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CadastroConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textoSaldo);
            this.Controls.Add(this.textoNome);
            this.Controls.Add(this.comboTipoConta);
            this.Name = "CadastroConta";
            this.Text = "CadastroConta";
            this.Load += new System.EventHandler(this.CadastroConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTipoConta;
        private System.Windows.Forms.TextBox textoNome;
        private System.Windows.Forms.TextBox textoSaldo;
        private System.Windows.Forms.Button button1;
    }
}