namespace TitaniumColector.Forms
{
    partial class FrmProposta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu menuPedido;

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
            this.menuPedido = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbLiberacao = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.dgProposta = new System.Windows.Forms.DataGrid();
            this.lbItemProposta = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtDataLiberacao = new System.Windows.Forms.TextBox();
            this.panelFrmProposta = new System.Windows.Forms.Panel();
            this.panelFrmProposta.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPedido
            // 
            this.menuPedido.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Opções";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // lbNumero
            // 
            this.lbNumero.Location = new System.Drawing.Point(88, 31);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(70, 23);
            this.lbNumero.Text = "Prop. N°:";
            // 
            // lbLiberacao
            // 
            this.lbLiberacao.Location = new System.Drawing.Point(94, 63);
            this.lbLiberacao.Name = "lbLiberacao";
            this.lbLiberacao.Size = new System.Drawing.Size(70, 23);
            this.lbLiberacao.Text = "Liberação:";
            // 
            // lbCliente
            // 
            this.lbCliente.Location = new System.Drawing.Point(94, 89);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(70, 23);
            this.lbCliente.Text = "Cliente :";
            // 
            // dgProposta
            // 
            this.dgProposta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProposta.Location = new System.Drawing.Point(3, 187);
            this.dgProposta.Name = "dgProposta";
            this.dgProposta.Size = new System.Drawing.Size(319, 244);
            this.dgProposta.TabIndex = 6;
            // 
            // lbItemProposta
            // 
            this.lbItemProposta.Location = new System.Drawing.Point(88, 140);
            this.lbItemProposta.Name = "lbItemProposta";
            this.lbItemProposta.Size = new System.Drawing.Size(150, 20);
            this.lbItemProposta.Text = "Itens Proposta";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNumero.Location = new System.Drawing.Point(160, 31);
            this.txtNumero.MaxLength = 12;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(78, 23);
            this.txtNumero.TabIndex = 9;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCliente.Location = new System.Drawing.Point(160, 86);
            this.txtCliente.MaxLength = 12;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(78, 23);
            this.txtCliente.TabIndex = 12;
            // 
            // txtDataLiberacao
            // 
            this.txtDataLiberacao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDataLiberacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDataLiberacao.Location = new System.Drawing.Point(160, 59);
            this.txtDataLiberacao.MaxLength = 12;
            this.txtDataLiberacao.Name = "txtDataLiberacao";
            this.txtDataLiberacao.Size = new System.Drawing.Size(78, 23);
            this.txtDataLiberacao.TabIndex = 13;
            // 
            // panelFrmProposta
            // 
            this.panelFrmProposta.Controls.Add(this.dgProposta);
            this.panelFrmProposta.Controls.Add(this.txtDataLiberacao);
            this.panelFrmProposta.Controls.Add(this.lbItemProposta);
            this.panelFrmProposta.Controls.Add(this.txtCliente);
            this.panelFrmProposta.Controls.Add(this.txtNumero);
            this.panelFrmProposta.Controls.Add(this.lbNumero);
            this.panelFrmProposta.Controls.Add(this.lbCliente);
            this.panelFrmProposta.Controls.Add(this.lbLiberacao);
            this.panelFrmProposta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFrmProposta.Location = new System.Drawing.Point(0, 0);
            this.panelFrmProposta.Name = "panelFrmProposta";
            this.panelFrmProposta.Size = new System.Drawing.Size(325, 455);
            
            // 
            // FrmProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(325, 455);
            this.Controls.Add(this.panelFrmProposta);
            this.Menu = this.menuPedido;
            this.Name = "FrmProposta";
            this.Text = "Proposta";
            this.panelFrmProposta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void configControls()
        {
            // 
            // lbNumero
            // 
            this.lbNumero.Location = new System.Drawing.Point(MainConfig.intPositionX + 3, MainConfig.intPositionY + 3);
            this.lbNumero.Font = MainConfig.FontPadraoBold;
            this.lbNumero.Text = "Prop.N° :";
            fStringSize = MainConfig.sizeStringEmPixel(this.lbNumero.Text, MainConfig.FontPadraoBold);
            this.lbNumero.Size = new System.Drawing.Size((int)fStringSize.Width + 2, (int)fStringSize.Height);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(lbNumero.Location.X + lbNumero.Size.Width + 5, lbNumero.Location.Y - 3);
            this.txtNumero.Enabled = false;
            this.txtNumero.MaxLength = 12;
            this.txtNumero.Size = new System.Drawing.Size(78, 23);
            this.txtNumero.TabStop = false;

            //
            // lbLiberacao
            // 
            this.lbLiberacao.Location = new System.Drawing.Point(this.txtNumero.Location.X + txtNumero.Size.Width + 5, this.txtNumero.Location.Y + 3);
            this.lbLiberacao.Text = "Data_Lib.:";
            this.lbLiberacao.Font = MainConfig.FontPadraoBold;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbLiberacao.Text, MainConfig.FontPadraoBold);
            this.lbLiberacao.Size = new System.Drawing.Size((int)fStringSize.Width, (int)fStringSize.Height);

            // 
            // txtDataLiberacao
            // 
            this.txtDataLiberacao.Location = new System.Drawing.Point(this.lbLiberacao.Location.X + lbLiberacao.Size.Width + 5,
                                                                      this.lbLiberacao.Location.Y - 3);
            this.txtDataLiberacao.MaxLength = 12;
            this.txtDataLiberacao.Enabled = false;
            this.txtDataLiberacao.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbNumero.Size.Width - txtNumero.Size.Width - lbLiberacao.Size.Width - 23, 23);
            this.txtDataLiberacao.TabStop = false;

            //
            // lbCliente
            // 
            this.lbCliente.Location = new System.Drawing.Point(this.lbNumero.Location.X,
                                                                this.lbNumero.Location.Y + lbNumero.Size.Height + 10);
            this.lbCliente.Text = "Cliente:";
            this.lbCliente.Font = MainConfig.FontPadraoBold;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbCliente.Text, MainConfig.FontPadraoBold);
            this.lbCliente.Size = new System.Drawing.Size((int)fStringSize.Width, (int)fStringSize.Height);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(this.lbCliente.Location.X + this.lbCliente.Size.Width + 2,
                                                                this.lbCliente.Location.Y - 3);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Enabled = false;
            this.txtCliente.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbCliente.Size.Width - 10, 23);
            // 
            // lbItemProposta
            // 
            this.lbItemProposta.Font = MainConfig.FontPadraoBold;
            this.lbItemProposta.Text = "Itens_Proposta";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            fStringSize = MainConfig.sizeStringEmPixel(this.lbItemProposta.Text, MainConfig.FontPadraoBold);
            this.lbItemProposta.Size = new System.Drawing.Size((int)fStringSize.Width + 2, (int)fStringSize.Height);
            this.lbItemProposta.Location = new System.Drawing.Point(MainConfig.ScreenSize.Width / 2 - lbItemProposta.Size.Width / 2, txtCliente.Location.Y + txtCliente.Size.Height + 3);
            // 
            // dgProposta
            // 

            string str = this.ClientRectangle.Bottom + "\n" + this.ClientSize.Height + "\n" + this.ClientSize.Width + "\n" + MainConfig.ScreenSize.Height + "\n" + MainConfig.ScreenSize.Width;
            int sizeHeigth = txtCliente.Size.Height + txtDataLiberacao.Size.Height + lbItemProposta.Size.Height;
            this.dgProposta.Location = new System.Drawing.Point(MainConfig.intPositionX + 5, lbItemProposta.Location.Y + lbItemProposta.Size.Height + 5);
            this.dgProposta.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 12, 100);
            this.dgProposta.TabIndex = 0;

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbLiberacao;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.DataGrid dgProposta;
        private System.Windows.Forms.Label lbItemProposta;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDataLiberacao;
        private System.Windows.Forms.Panel panelFrmProposta;
    }
}