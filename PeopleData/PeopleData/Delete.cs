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
    public partial class Delete : Form
    {
        private string[] _t;
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _t = Form1.CurrentPeople.Split(' ');
            Form2 f = new Form2();
            f.DeleteFile(_t[0] + ".json");

            ReturnToMain();
        }

        private void ReturnToMain()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnToMain();
        }
    }
}
