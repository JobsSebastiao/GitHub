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
            this.components = new System.ComponentModel.Container();
            this.menuPedido = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lbPedido = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.itemPropostaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgProposta = new System.Windows.Forms.DataGrid();
            this.lbItemProposta = new System.Windows.Forms.Label();
            this.panelFrmProposta = new System.Windows.Forms.Panel();
            this.lbNomeCliente = new System.Windows.Forms.Label();
            this.lbNumeroPedido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemPropostaBindingSource)).BeginInit();
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
            // lbPedido
            // 
            this.lbPedido.Location = new System.Drawing.Point(88, 31);
            this.lbPedido.Name = "lbPedido";
            this.lbPedido.Size = new System.Drawing.Size(70, 23);
            this.lbPedido.Text = "Pedido :";
            // 
            // lbCliente
            // 
            this.lbCliente.Location = new System.Drawing.Point(94, 89);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(70, 23);
            this.lbCliente.Text = "Cliente :";
            // 
            // itemPropostaBindingSource
            // 
            this.itemPropostaBindingSource.DataSource = typeof(TitaniumColector.Classes.ItemProposta);
            // 
            // dgProposta
            // 
            this.dgProposta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProposta.DataSource = this.itemPropostaBindingSource;
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
            // panelFrmProposta
            // 
            this.panelFrmProposta.Controls.Add(this.lbNomeCliente);
            this.panelFrmProposta.Controls.Add(this.lbNumeroPedido);
            this.panelFrmProposta.Controls.Add(this.dgProposta);
            this.panelFrmProposta.Controls.Add(this.lbItemProposta);
            this.panelFrmProposta.Controls.Add(this.lbPedido);
            this.panelFrmProposta.Controls.Add(this.lbCliente);
            this.panelFrmProposta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFrmProposta.Location = new System.Drawing.Point(0, 0);
            this.panelFrmProposta.Name = "panelFrmProposta";
            this.panelFrmProposta.Size = new System.Drawing.Size(325, 455);
            // 
            // lbNomeCliente
            // 
            this.lbNomeCliente.Location = new System.Drawing.Point(244, 89);
            this.lbNomeCliente.Name = "lbNomeCliente";
            this.lbNomeCliente.Size = new System.Drawing.Size(70, 23);
            this.lbNomeCliente.Text = "Pedido";
            // 
            // lbNumeroPedido
            // 
            this.lbNumeroPedido.Location = new System.Drawing.Point(244, 31);
            this.lbNumeroPedido.Name = "lbNumeroPedido";
            this.lbNumeroPedido.Size = new System.Drawing.Size(70, 23);
            this.lbNumeroPedido.Text = "Pedido";
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
            ((System.ComponentModel.ISupportInitialize)(this.itemPropostaBindingSource)).EndInit();
            this.panelFrmProposta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void configControls()
        {
            this.Text = "Pedido";
            // 
            // lbNumero
            // 
            this.lbPedido.Location = new System.Drawing.Point(MainConfig.intPositionX + 3, MainConfig.intPositionY + 3);
            this.lbPedido.Font = MainConfig.FontPadraoBold;
            this.lbPedido.Text = "Pedido:";
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbPedido.Text, MainConfig.FontPadraoBold);
            this.lbPedido.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
             
            // lbNumeroPedido

            this.lbNumeroPedido.Location = new System.Drawing.Point(lbPedido.Location.X + lbPedido.Size.Width + 5, lbPedido.Location.Y);
            this.lbNumeroPedido.Font = MainConfig.FontPadraoBold;
            this.lbNumeroPedido.Text = "Nº Pedido";
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbPedido.Text, MainConfig.FontPadraoBold);
            this.lbNumeroPedido.Size = new System.Drawing.Size(78, 23);

            // lbCliente

            this.lbCliente.Location = new System.Drawing.Point(this.lbPedido.Location.X, this.lbPedido.Location.Y + lbPedido.Size.Height + 3);
            this.lbCliente.Text = "Cliente:";
            this.lbCliente.Font = MainConfig.FontPadraoBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbCliente.Text, MainConfig.FontPadraoBold);
            this.lbCliente.Size = new System.Drawing.Size((int)fontStringSize.Width, (int)fontStringSize.Height);

            // lbNomeCliente

            this.lbNomeCliente.Location = new System.Drawing.Point(this.lbCliente.Location.X + lbCliente.Size.Width + 5, this.lbPedido.Location.Y + lbPedido.Size.Height + 3);
            this.lbNomeCliente.Text = "Cliente Name";
            this.lbNomeCliente.Font = MainConfig.FontPadraoBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbCliente.Text, MainConfig.FontPadraoBold);
            this.lbNomeCliente.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbCliente.Size.Width - 5 , (int)fontStringSize.Height);


            // lbItemProposta

            this.lbItemProposta.Font = MainConfig.FontPadraoBold;
            this.lbItemProposta.Text = "Itens_Pedido";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbItemProposta.Text, MainConfig.FontPadraoBold);
            this.lbItemProposta.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbItemProposta.Location = new System.Drawing.Point(MainConfig.ScreenSize.Width / 2 - lbItemProposta.Size.Width / 2, lbCliente.Location.Y + lbCliente.Size.Height + 5);

            // dgProposta


            string str = this.ClientRectangle.Bottom + "\n" + this.ClientSize.Height + "\n" + this.ClientSize.Width + "\n" + MainConfig.ScreenSize.Height + "\n" + MainConfig.ScreenSize.Width;
            this.dgProposta.Location = new System.Drawing.Point(MainConfig.intPositionX + 5, lbItemProposta.Location.Y + lbItemProposta.Size.Height + 5);
            this.dgProposta.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 12, 100);
            this.dgProposta.TabIndex = 0;
            this.dgProposta.RowHeadersVisible = false;

            // txtCliente
             
            //this.txtCliente.Location = new System.Drawing.Point(this.lbCliente.Location.X + this.lbCliente.Size.Width + 2,
            //                                                    this.lbCliente.Location.Y - 3);
            //this.txtCliente.MaxLength = 50;
            //this.txtCliente.Enabled = false;
            //this.txtCliente.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbCliente.Size.Width - 10, 23);
             


        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label lbPedido;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.DataGrid dgProposta;
        private System.Windows.Forms.Label lbItemProposta;
        private System.Windows.Forms.Panel panelFrmProposta;
        private System.Windows.Forms.BindingSource itemPropostaBindingSource;
        private System.Windows.Forms.Label lbNomeCliente;
        private System.Windows.Forms.Label lbNumeroPedido;
    }
}