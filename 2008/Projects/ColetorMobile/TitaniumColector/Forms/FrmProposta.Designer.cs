using System.Drawing;
namespace TitaniumColector.Forms
{
    partial class FrmProposta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu menuPedido;
        private SizeF fontStringSize;

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
            this.mnuPropostas = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.lbPedido = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.itemPropostaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgProposta = new System.Windows.Forms.DataGrid();
            this.lbItemProposta = new System.Windows.Forms.Label();
            this.pnlFrmProposta = new System.Windows.Forms.Panel();
            this.lbProduto = new System.Windows.Forms.Label();
            this.lbLote = new System.Windows.Forms.Label();
            this.lbSequencia = new System.Windows.Forms.Label();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.tbMensagem = new System.Windows.Forms.TextBox();
            this.tbSequencia = new System.Windows.Forms.TextBox();
            this.tbLote = new System.Windows.Forms.TextBox();
            this.tbProduto = new System.Windows.Forms.TextBox();
            this.pnCentral = new System.Windows.Forms.Panel();
            this.tbQuantidade = new System.Windows.Forms.TextBox();
            this.tbLocal = new System.Windows.Forms.TextBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.lbQtdItens = new System.Windows.Forms.Label();
            this.lbQtdPecas = new System.Windows.Forms.Label();
            this.lbNomeCliente = new System.Windows.Forms.Label();
            this.lbNumeroPedido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemPropostaBindingSource)).BeginInit();
            this.pnlFrmProposta.SuspendLayout();
            this.pnCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPedido
            // 
            this.menuPedido.MenuItems.Add(this.mnuPropostas);
            // 
            // mnuPropostas
            // 
            this.mnuPropostas.MenuItems.Add(this.menuItem1);
            this.mnuPropostas.Text = "Opções";
            this.mnuPropostas.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.Text = "Testes";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Gerar Etiquetas";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Próximo Item";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // lbPedido
            // 
            this.lbPedido.Location = new System.Drawing.Point(3, 31);
            this.lbPedido.Name = "lbPedido";
            this.lbPedido.Size = new System.Drawing.Size(70, 23);
            this.lbPedido.Text = "Pedido :";
            // 
            // lbCliente
            // 
            this.lbCliente.Location = new System.Drawing.Point(2, 54);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(70, 23);
            this.lbCliente.Text = "Cliente :";
            // 
            // itemPropostaBindingSource
            // 
            this.itemPropostaBindingSource.DataSource = typeof(TitaniumColector.Classes.ProdutoProposta);
            // 
            // dgProposta
            // 
            this.dgProposta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProposta.DataSource = this.itemPropostaBindingSource;
            this.dgProposta.Location = new System.Drawing.Point(3, 90);
            this.dgProposta.Name = "dgProposta";
            this.dgProposta.Size = new System.Drawing.Size(41, 37);
            this.dgProposta.TabIndex = 6;
            // 
            // lbItemProposta
            // 
            this.lbItemProposta.Location = new System.Drawing.Point(3, 72);
            this.lbItemProposta.Name = "lbItemProposta";
            this.lbItemProposta.Size = new System.Drawing.Size(83, 17);
            this.lbItemProposta.Text = "Itens Proposta";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlFrmProposta
            // 
            this.pnlFrmProposta.Controls.Add(this.lbProduto);
            this.pnlFrmProposta.Controls.Add(this.lbLote);
            this.pnlFrmProposta.Controls.Add(this.lbSequencia);
            this.pnlFrmProposta.Controls.Add(this.lbMensagem);
            this.pnlFrmProposta.Controls.Add(this.tbMensagem);
            this.pnlFrmProposta.Controls.Add(this.tbSequencia);
            this.pnlFrmProposta.Controls.Add(this.tbLote);
            this.pnlFrmProposta.Controls.Add(this.tbProduto);
            this.pnlFrmProposta.Controls.Add(this.pnCentral);
            this.pnlFrmProposta.Controls.Add(this.lbQtdItens);
            this.pnlFrmProposta.Controls.Add(this.lbQtdPecas);
            this.pnlFrmProposta.Controls.Add(this.lbNomeCliente);
            this.pnlFrmProposta.Controls.Add(this.lbNumeroPedido);
            this.pnlFrmProposta.Controls.Add(this.dgProposta);
            this.pnlFrmProposta.Controls.Add(this.lbItemProposta);
            this.pnlFrmProposta.Controls.Add(this.lbPedido);
            this.pnlFrmProposta.Controls.Add(this.lbCliente);
            this.pnlFrmProposta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrmProposta.Location = new System.Drawing.Point(0, 0);
            this.pnlFrmProposta.Name = "pnlFrmProposta";
            this.pnlFrmProposta.Size = new System.Drawing.Size(325, 455);
            // 
            // lbProduto
            // 
            this.lbProduto.Location = new System.Drawing.Point(14, 281);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(69, 16);
            this.lbProduto.Text = "Produto";
            // 
            // lbLote
            // 
            this.lbLote.Location = new System.Drawing.Point(14, 328);
            this.lbLote.Name = "lbLote";
            this.lbLote.Size = new System.Drawing.Size(31, 15);
            this.lbLote.Text = "Lote";
            // 
            // lbSequencia
            // 
            this.lbSequencia.Location = new System.Drawing.Point(203, 326);
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(68, 17);
            this.lbSequencia.Text = "Sequência";
            // 
            // lbMensagem
            // 
            this.lbMensagem.Location = new System.Drawing.Point(13, 374);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(70, 16);
            this.lbMensagem.Text = "Mensagem";
            // 
            // tbMensagem
            // 
            this.tbMensagem.Location = new System.Drawing.Point(14, 392);
            this.tbMensagem.Name = "tbMensagem";
            this.tbMensagem.Size = new System.Drawing.Size(296, 23);
            this.tbMensagem.TabIndex = 14;
            this.tbMensagem.Text = "produto não existe no pedido";
            // 
            // tbSequencia
            // 
            this.tbSequencia.Location = new System.Drawing.Point(203, 344);
            this.tbSequencia.Name = "tbSequencia";
            this.tbSequencia.Size = new System.Drawing.Size(107, 23);
            this.tbSequencia.TabIndex = 13;
            this.tbSequencia.Text = "12451542";
            // 
            // tbLote
            // 
            this.tbLote.Location = new System.Drawing.Point(14, 344);
            this.tbLote.Name = "tbLote";
            this.tbLote.Size = new System.Drawing.Size(84, 23);
            this.tbLote.TabIndex = 12;
            this.tbLote.Text = "lt1070";
            // 
            // tbProduto
            // 
            this.tbProduto.Location = new System.Drawing.Point(14, 299);
            this.tbProduto.Name = "tbProduto";
            this.tbProduto.Size = new System.Drawing.Size(296, 23);
            this.tbProduto.TabIndex = 11;
            this.tbProduto.Text = "70220 - Terminal Olhal";
            // 
            // pnCentral
            // 
            this.pnCentral.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnCentral.Controls.Add(this.tbQuantidade);
            this.pnCentral.Controls.Add(this.tbLocal);
            this.pnCentral.Controls.Add(this.tbDescricao);
            this.pnCentral.Controls.Add(this.tbPartNumber);
            this.pnCentral.Location = new System.Drawing.Point(14, 100);
            this.pnCentral.Name = "pnCentral";
            this.pnCentral.Size = new System.Drawing.Size(296, 129);
            // 
            // tbQuantidade
            // 
            this.tbQuantidade.Font = new System.Drawing.Font("Tahoma", 32F, System.Drawing.FontStyle.Bold);
            this.tbQuantidade.Location = new System.Drawing.Point(148, 71);
            this.tbQuantidade.Multiline = true;
            this.tbQuantidade.Name = "tbQuantidade";
            this.tbQuantidade.Size = new System.Drawing.Size(148, 58);
            this.tbQuantidade.TabIndex = 3;
            this.tbQuantidade.Text = "4000";
            this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLocal
            // 
            this.tbLocal.Font = new System.Drawing.Font("Tahoma", 32F, System.Drawing.FontStyle.Bold);
            this.tbLocal.Location = new System.Drawing.Point(0, 71);
            this.tbLocal.Multiline = true;
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Size = new System.Drawing.Size(148, 58);
            this.tbLocal.TabIndex = 2;
            this.tbLocal.Text = "A1";
            this.tbLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDescricao
            // 
            this.tbDescricao.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.tbDescricao.Location = new System.Drawing.Point(0, 42);
            this.tbDescricao.Multiline = true;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(296, 29);
            this.tbDescricao.TabIndex = 1;
            this.tbDescricao.Text = "Terminal Olhal";
            this.tbDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.tbPartNumber.Location = new System.Drawing.Point(0, 0);
            this.tbPartNumber.Multiline = true;
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(296, 42);
            this.tbPartNumber.TabIndex = 0;
            this.tbPartNumber.Text = "7020";
            this.tbPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbQtdItens
            // 
            this.lbQtdItens.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbQtdItens.Location = new System.Drawing.Point(252, 31);
            this.lbQtdItens.Name = "lbQtdItens";
            this.lbQtdItens.Size = new System.Drawing.Size(70, 23);
            this.lbQtdItens.Text = "0000 Itens";
            // 
            // lbQtdPecas
            // 
            this.lbQtdPecas.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbQtdPecas.Location = new System.Drawing.Point(252, 54);
            this.lbQtdPecas.Name = "lbQtdPecas";
            this.lbQtdPecas.Size = new System.Drawing.Size(70, 23);
            this.lbQtdPecas.Text = "00000 pçs";
            // 
            // lbNomeCliente
            // 
            this.lbNomeCliente.Location = new System.Drawing.Point(58, 54);
            this.lbNomeCliente.Name = "lbNomeCliente";
            this.lbNomeCliente.Size = new System.Drawing.Size(136, 23);
            this.lbNomeCliente.Text = "Nome   Cliente";
            // 
            // lbNumeroPedido
            // 
            this.lbNumeroPedido.Location = new System.Drawing.Point(58, 31);
            this.lbNumeroPedido.Name = "lbNumeroPedido";
            this.lbNumeroPedido.Size = new System.Drawing.Size(136, 23);
            this.lbNumeroPedido.Text = "000001";
            // 
            // FrmProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(325, 455);
            this.Controls.Add(this.pnlFrmProposta);
            this.KeyPreview = true;
            this.Menu = this.menuPedido;
            this.Name = "FrmProposta";
            this.Text = "Proposta";
            this.Load += new System.EventHandler(this.FrmProposta_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmProposta_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.itemPropostaBindingSource)).EndInit();
            this.pnlFrmProposta.ResumeLayout(false);
            this.pnCentral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void configControls()
        {
            this.Text = "Pedido";

            // 
            // lbPedido
            //
            this.lbPedido.Font = MainConfig.FontPequenaBold;
            this.lbPedido.Text = "Pedido:";
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbPedido.Text, MainConfig.FontPequenaBold);
            this.lbPedido.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbPedido.Location = new System.Drawing.Point(MainConfig.intPositionX + 2, MainConfig.intPositionY );
            this.lbPedido.Tag = "N";
             
            // lbNumeroPedido

            this.lbNumeroPedido.Font = MainConfig.FontPadraoBold;
            this.lbNumeroPedido.Text = "000000001";
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbPedido.Text, MainConfig.FontPadraoBold);
            this.lbNumeroPedido.Size = new System.Drawing.Size(78, 23);
            this.lbNumeroPedido.Location = new System.Drawing.Point(lbPedido.Location.X + lbPedido.Size.Width + 1, lbPedido.Location.Y - 2);
            this.lbNumeroPedido.Tag = "L";

            // lbQtdItens

            this.lbQtdItens.Text = "1000_Itens";
            this.lbQtdItens.TextAlign = ContentAlignment.TopRight;
            this.lbQtdItens.Font = MainConfig.FontPadraoItalicBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbQtdItens.Text, MainConfig.FontPadraoItalicBold);
            this.lbQtdItens.BackColor = System.Drawing.Color.Black;
            this.lbQtdItens.ForeColor = System.Drawing.Color.White;
            this.lbQtdItens.Size = new System.Drawing.Size((int)fontStringSize.Width + 7  , (int)fontStringSize.Height);
            this.lbQtdItens.Location = new System.Drawing.Point(MainConfig.ScreenSize.Width - this.lbQtdItens.Width - 10, lbNumeroPedido.Location.Y);
            this.lbQtdItens.Tag= "L";

            // lbCliente

            this.lbCliente.Text = "Cliente:";
            this.lbCliente.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbCliente.Text, MainConfig.FontPequenaBold);
            this.lbCliente.Size = new System.Drawing.Size((int)fontStringSize.Width, (int)fontStringSize.Height);
            this.lbCliente.Location = new System.Drawing.Point(this.lbPedido.Location.X , this.lbPedido.Location.Y + lbPedido.Size.Height + 6);
            this.lbCliente.Tag = "N";
           
            // lbQtdPeças

            this.lbQtdPecas.Text = "100000_Pçs";
            this.lbQtdPecas.TextAlign = ContentAlignment.TopRight;
            this.lbQtdPecas.Font = MainConfig.FontPadraoItalicBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbQtdPecas.Text, MainConfig.FontPadraoItalicBold);
            this.lbQtdPecas.BackColor = System.Drawing.Color.Black;
            this.lbQtdPecas.ForeColor = System.Drawing.Color.White;
            this.lbQtdPecas.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbQtdPecas.Location = new System.Drawing.Point(lbQtdItens.Location.X, lbQtdItens.Location.Y  + lbQtdPecas.Size.Height + 3);
            this.lbQtdPecas.Tag = "L";

            // lbNomeCliente

            this.lbNomeCliente.Text = "Nome cliente prosposta";
            this.lbNomeCliente.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbNomeCliente.Text, MainConfig.FontPequenaBold);
            this.lbNomeCliente.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - lbCliente.Size.Width - lbQtdPecas.Size.Width - 13, (int)fontStringSize.Height);
            this.lbNomeCliente.Location = new System.Drawing.Point(this.lbCliente.Location.X + lbCliente.Size.Width + 1, lbCliente.Location.Y);
            this.lbNomeCliente.Tag = "L";
           
            // lbItemProposta

            this.lbItemProposta.Font = MainConfig.FontPequenaBold;
            this.lbItemProposta.Text = "Itens_Pedido";
            this.lbItemProposta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbItemProposta.Text, MainConfig.FontPadraoBold);
            this.lbItemProposta.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbItemProposta.Location = new System.Drawing.Point(MainConfig.ScreenSize.Width / 2 - lbItemProposta.Size.Width / 2, lbCliente.Location.Y + lbCliente.Size.Height + 5);
            this.lbItemProposta.Visible = false;
            this.lbItemProposta.Tag = "N";

            // dgProposta

            this.dgProposta.Font = MainConfig.FontPequenaRegular;
            string str = this.ClientRectangle.Bottom + "\n" + this.ClientSize.Height + "\n" + this.ClientSize.Width + "\n" + MainConfig.ScreenSize.Height + "\n" + MainConfig.ScreenSize.Width;
            this.dgProposta.Location = new System.Drawing.Point(MainConfig.intPositionX + 5, lbItemProposta.Location.Y + lbItemProposta.Size.Height + 5);
            this.dgProposta.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 12, 100);
            this.dgProposta.TabIndex = 0;
            this.dgProposta.RowHeadersVisible = false;
            this.dgProposta.Visible = false;
            this.dgProposta.Tag = "N";

            //pnCentral

            this.pnCentral.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 30, 150);
            this.pnCentral.Location = new System.Drawing.Point(this.Size.Width / 2 - pnCentral.Size.Width/ 2, lbCliente.Location.Y + lbCliente.Size.Height + 5);

            //TbPartNumber

            this.tbPartNumber.Size = new System.Drawing.Size(this.pnCentral.Size.Width, 32);
            this.tbPartNumber.Font = MainConfig.FontGrandeBold;
            this.tbPartNumber.Enabled = false;
            this.tbPartNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbPartNumber.Location = new System.Drawing.Point(0,0);
            this.tbPartNumber.Tag = "L";

            //tbDescricao

            this.tbDescricao.Size = new System.Drawing.Size(this.pnCentral.Size.Width, 23);
            this.tbDescricao.Font = MainConfig.FontMediaBold;
            this.tbDescricao.Enabled = false;
            this.tbDescricao.BackColor = System.Drawing.SystemColors.Window;
            this.tbDescricao.Location = new System.Drawing.Point(0, this.tbPartNumber.Location.Y + tbPartNumber.Size.Height);
            this.tbDescricao.Tag = "L";

            //tbLocal

            this.tbLocal.Size = new System.Drawing.Size(this.pnCentral.Size.Width/2,47);
            this.tbLocal.Font = MainConfig.FontMuitoGrandeBold;
            this.tbLocal.Enabled = false;
            this.tbLocal.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocal.Location = new System.Drawing.Point(0, tbDescricao.Location.Y + tbDescricao.Size.Height);
            this.tbLocal.Tag = "L";

            //tbQuantidade

            this.tbQuantidade.Size = new System.Drawing.Size(this.pnCentral.Size.Width / 2, 47);
            this.tbQuantidade.Font = MainConfig.FontMuitoGrandeBold;
            this.tbQuantidade.Enabled = false;
            this.tbQuantidade.BackColor = System.Drawing.SystemColors.Window;
            this.tbQuantidade.Location = new System.Drawing.Point(pnCentral.Size.Width/2, tbDescricao.Location.Y + tbDescricao.Size.Height);
            this.tbQuantidade.Tag = "L";

            //pnCentral
            this.pnCentral.Size = new System.Drawing.Size(MainConfig.ScreenSize.Width - 30, 
                                  tbPartNumber.Size.Height+ tbDescricao.Size.Height+ tbLocal.Size.Height);

            //lbProduto

            this.lbProduto.Location = new System.Drawing.Point(pnCentral.Location.X,pnCentral.Location.Y + pnCentral.Size.Height);
            this.lbProduto.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbProduto.Text, MainConfig.FontPequenaBold);
            this.lbProduto.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbProduto.Tag = "N";

            //tbProduto

            this.tbProduto.Location = new System.Drawing.Point(pnCentral.Location.X,lbProduto.Location.Y + lbProduto.Size.Height);
            this.tbProduto.Enabled = false;
            this.tbProduto.Multiline = true;
            this.tbProduto.Font = MainConfig.FontPequenaBold;
            this.tbProduto.Size = new System.Drawing.Size(this.pnCentral.Size.Width,15);
            this.tbProduto.BackColor = System.Drawing.SystemColors.Window;
            this.tbProduto.Tag = "L";

            //lbLote

            this.lbLote.Location = new System.Drawing.Point(tbProduto.Location.X, tbProduto.Location.Y + tbProduto.Size.Height);
            this.lbLote.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbLote.Text, MainConfig.FontPequenaBold);
            this.lbLote.Size = new System.Drawing.Size((int)fontStringSize.Width+2, (int)fontStringSize.Height);
            this.lbLote.Tag = "N";

            //tbLote

            this.tbLote.Location = new System.Drawing.Point(lbLote.Location.X, lbLote.Location.Y + lbLote.Size.Height);
            this.tbLote.Multiline = true;
            this.tbLote.Font = MainConfig.FontPequenaBold;
            this.tbLote.Size = new System.Drawing.Size(this.tbLote.Size.Width,15);
            this.tbLote.Enabled = false;
            this.tbLote.BackColor = System.Drawing.SystemColors.Window;
            this.tbLote.Tag = "L";

            //lbSequencia

            this.lbSequencia.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbSequencia.Text, MainConfig.FontPequenaBold);
            this.lbSequencia.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbSequencia.Location = new System.Drawing.Point(this.Size.Width / 2 + 10, lbLote.Location.Y);
            this.lbSequencia.Tag = "N";

            //tbSequencia

            this.tbSequencia.Enabled = false;
            this.tbSequencia.Multiline = true;
            this.tbSequencia.Font = MainConfig.FontPequenaBold;
            this.tbSequencia.Size = new System.Drawing.Size(tbQuantidade.Size.Width-10, 15);
            this.tbSequencia.BackColor = System.Drawing.SystemColors.Window;
            this.tbSequencia.Location = new System.Drawing.Point(this.Size.Width/2+10, tbLote.Location.Y);
            this.tbSequencia.Tag = "L";

            //lbMensagem

            this.lbMensagem.Font = MainConfig.FontPequenaBold;
            fontStringSize = MainConfig.sizeStringEmPixel(this.lbMensagem.Text, MainConfig.FontPequenaBold);
            this.lbMensagem.Size = new System.Drawing.Size((int)fontStringSize.Width + 2, (int)fontStringSize.Height);
            this.lbMensagem.Location = new System.Drawing.Point(this.lbLote.Location.X, tbSequencia.Location.Y + tbSequencia.Size.Height);
            this.lbMensagem.Tag = "N";

            //tbMensagem

            this.tbMensagem.Location = new System.Drawing.Point(lbMensagem.Location.X, lbMensagem.Location.Y + lbMensagem.Size.Height);
            this.tbMensagem.Enabled = false;
            this.tbMensagem.Multiline = true;
            this.tbMensagem.Font = MainConfig.FontPequenaBold;
            this.tbMensagem.Size = new System.Drawing.Size(this.pnCentral.Size.Width, 15);
            this.tbMensagem.BackColor = System.Drawing.SystemColors.Window;
            this.tbMensagem.Tag = "L";

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuPropostas;
        private System.Windows.Forms.Label lbPedido;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.DataGrid dgProposta;
        private System.Windows.Forms.Label lbItemProposta;
        private System.Windows.Forms.Panel pnlFrmProposta;
        private System.Windows.Forms.BindingSource itemPropostaBindingSource;
        private System.Windows.Forms.Label lbNomeCliente;
        private System.Windows.Forms.Label lbNumeroPedido;
        private System.Windows.Forms.Label lbQtdItens;
        private System.Windows.Forms.Label lbQtdPecas;
        private System.Windows.Forms.Panel pnCentral;
        private System.Windows.Forms.TextBox tbQuantidade;
        private System.Windows.Forms.TextBox tbLocal;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.Label lbProduto;
        private System.Windows.Forms.Label lbLote;
        private System.Windows.Forms.Label lbSequencia;
        private System.Windows.Forms.Label lbMensagem;
        private System.Windows.Forms.TextBox tbMensagem;
        private System.Windows.Forms.TextBox tbSequencia;
        private System.Windows.Forms.TextBox tbLote;
        private System.Windows.Forms.TextBox tbProduto;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
    }
}