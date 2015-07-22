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
            this.menuFrmAcao = new System.Windows.Forms.MainMenu();
            this.mnuAcao_Opcoes = new System.Windows.Forms.MenuItem();
            this.mnuAcao_Exit = new System.Windows.Forms.MenuItem();
            this.mnuAcao_Logout = new System.Windows.Forms.MenuItem();

            this.SuspendLayout();

            // FrmAcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(346, 455);
            this.ControlBox = false;
            this.Menu = this.menuFrmAcao;
            this.Name = "FrmAcao";
            this.Text = "FrmAcao";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuAcao_Opcoes;
        private System.Windows.Forms.MenuItem mnuAcao_Exit;
        private System.Windows.Forms.MenuItem mnuAcao_Logout;
    }
}