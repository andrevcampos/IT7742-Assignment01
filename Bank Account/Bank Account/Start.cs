using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Account
{
    public partial class Start : Form
    {
        public static Start instance;
        public Start()
        {
            InitializeComponent();
            Start.instance = this;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerCP form = new CustomerCP();
            form.Show();
        }
    }
}
