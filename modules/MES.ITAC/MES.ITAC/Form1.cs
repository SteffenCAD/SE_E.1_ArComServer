using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.ITAC
{
    public partial class Form1 : Form
    {
        public ITACapi ITACapi = new ITACapi();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            ITACapi.init();
        }
    }
}
