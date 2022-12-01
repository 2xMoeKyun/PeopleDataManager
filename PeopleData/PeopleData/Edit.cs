using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeopleData
{
    public partial class Edit : Form
    {
        private string[] _t;
        public Edit()
        {
            InitializeComponent();
            _t = Form1.CurrentPeople.Split(' ');
            textBox1.Text = _t[1];
            textBox2.Text = _t[2];
            textBox3.Text = _t[3];
            textBox4.Text = _t[4];
            textBox5.Text = _t[5];
        }

        private void Edit1_Click(object sender, EventArgs e)
        {
            People p = new People(Convert.ToInt32(_t[0]),textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            string jsonString = JsonConvert.SerializeObject(p);
            File.WriteAllText($"{_t[0]}.json", jsonString);


            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
