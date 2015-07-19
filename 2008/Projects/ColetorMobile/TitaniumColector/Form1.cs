using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.SqlServer;
namespace TitaniumColector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MainConfig.setMainConfigurations();
            SqlServerConn.openConn();
        }
    }
}