using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void barcode1_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            String testes = readerData.Text;
        }

        private void barcode1_OnStatus(object sender, Symbol.Barcode.BarcodeStatus barcodeStatus)
        {
            string teste = barcodeStatus.State.ToString();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
              Symbol.Barcode.ReaderData a =  new Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text,1024);
              a = (Symbol.Barcode.ReaderData)sender;
              barcode1_OnRead(sender, a);
        }
    }
}