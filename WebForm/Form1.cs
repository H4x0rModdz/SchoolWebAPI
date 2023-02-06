using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.Start("C:\\Users\\lucas\\source\\repos\\WebAPI\\WebAPI\\bin\\Debug\\net6.0\\WebAPI.exe");
        }

        private void btnControl_Click(object sender, EventArgs e)
        {

        }
    }
}
