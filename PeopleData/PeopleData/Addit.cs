using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeopleData
{
    public partial class Addit : Form
    {
        public Addit()
        {
            InitializeComponent();
            
        }
        public void ShowInfo()
        {
            this.Show();
            string[] t = Form1.CurrentAddit.Split(' ');
            textBox4.Text = t[0];
            textBox5.Text = t[1];
        }
    }
}
