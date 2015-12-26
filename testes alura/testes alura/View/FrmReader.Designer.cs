namespace testes_alura.View
{
    partial class FrmReader
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
            this.textoLousa = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoLousa
            // 
            this.textoLousa.Location = new System.Drawing.Point(18, 23);
            this.textoLousa.Multiline = true;
            this.textoLousa.Name = "textoLousa";
            this.textoLousa.Size = new System.Drawing.Size(324, 249);
            this.textoLousa.TabIndex = 0;
            this.textoLousa.Text = "Escreva aqui.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textoLousa);
            this.Name = "FrmReader";
            this.Text = "FrmReader";
            this.Load += new System.EventHandler(this.FrmReader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoLousa;
        private System.Windows.Forms.Button button1;
    }
}