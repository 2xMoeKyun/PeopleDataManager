using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace PeopleData
{
    public partial class Form2 : Form
    {
        public int Id = 0;
        public static int CountId;
        public Form2()
        {
            string _genDoc = string.Empty;
            InitializeComponent();
            if (File.Exists("Id.json"))
                _genDoc = File.ReadAllText("Id.json");
            this.Id = 0;
            if (_genDoc != "")
                this.Id = JsonConvert.DeserializeObject<int>(_genDoc);
        }

        public void DeleteFile(string file)
        {
            File.Delete(file);
            Id--;
            SetTxtCount(Id);
            Form1.PersonIdCount--;
            File.WriteAllText("PersonId.json", Form1.PersonIdCount.ToString());
        }

        private int GetTxtCount()
        {
            string jsonString = JsonConvert.SerializeObject(Id);
            File.WriteAllText("Id.json", jsonString);

            return JsonConvert.DeserializeObject<int>(File.ReadAllText("Id.json"));
        }

        private void SetTxtCount(int id)
        {
            string jsonString = JsonConvert.SerializeObject(id);
            File.WriteAllText("Id.json", jsonString);
        }

        private string PeopleOp(TextBox textBox)
        {
            return textBox.Text.Replace(" ", "");
        }

        private void AddClick(object sender, EventArgs e)
        {
            People p = new People(GetTxtCount(), PeopleOp(textBox1), PeopleOp(textBox2), PeopleOp(textBox3), PeopleOp(textBox4), PeopleOp(textBox5));
            string jsonString = JsonConvert.SerializeObject(p);
            File.WriteAllText(GetTxtCount().ToString()+".json", jsonString);

            var read = JsonConvert.DeserializeObject<People>(File.ReadAllText(GetTxtCount().ToString() + ".json"));
            MessageBox.Show(read.ToString());
            Id++;
            SetTxtCount(Id);

            Form1.PersonIdCount++;
            File.WriteAllText("PersonId.json", Form1.PersonIdCount.ToString());

            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
