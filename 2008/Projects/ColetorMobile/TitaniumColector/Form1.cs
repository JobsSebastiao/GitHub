using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TitaniumColector.SqlServer;
using System.Reflection;
namespace TitaniumColector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MainConfig.setMainConfigurations();
            SqlServerConn.configuraStrConnection(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "strConn");
            SqlServerConn.openConn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}