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
    public partial class Form1 : Form
    {
        public static int PersonIdCount;
        public static string CurrentPeople;
        public static string CurrentAddit;
        public Addit ad = new Addit();
        public Form1()
        {
            InitializeComponent();
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void UpdateList()
        {
            People read;
            GetPersonIdCount();
            for (int i = 0; i < PersonIdCount+1; i++)
            {
                try
                {
                    read = JsonConvert.DeserializeObject<People>(File.ReadAllText(i.ToString() + ".json"));
                }
                catch { continue; }
                listBox1.Items.Add(read.ToString());
            }
            SavePersonIdCount();
        }

        private void GetPersonIdCount()
        {
            string genDoc = string.Empty;
            if (File.Exists("PersonId.json"))
                genDoc = File.ReadAllText("PersonId.json");
            if (genDoc != "")
                PersonIdCount = JsonConvert.DeserializeObject<int>(genDoc);
        }

        private void SavePersonIdCount()
        {
            string jsonString = JsonConvert.SerializeObject(PersonIdCount);
            File.WriteAllText("PersonId.json", jsonString);
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > -1)
            CurrentPeople = listBox1.Items[Convert.ToInt32(listBox1.SelectedIndex)].ToString();
            CurrentAddit = People.addit[Convert.ToInt32(listBox1.SelectedIndex)];
            try
            {
               var a =  ad.AccessibilityObject.Parent;
            }
            catch { ad = new Addit(); }
            ad.ShowInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(CurrentPeople == null)
            {
                return;
            }
            Edit ed = new Edit();
            ed.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentPeople == null)
            {
                return;
            }
            Delete d = new Delete();
            d.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(var file in Directory.GetFiles("."))
            {
                if (file.Contains(".json"))
                    File.Delete(file);
            }
            Application.Exit();
        }
    }


    [Serializable]
    public class People
    {
        [NonSerialized]
        public static List<String> addit = new List<string>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otchestvo { get; set; }
        public string Gender { get; set; }
        public string SkinColour { get; set; }

        public People(int id, string name, string surname, string blalba, string gender, string skinColour)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Otchestvo = blalba;
            //additionals
            this.Gender = gender;
            this.SkinColour = skinColour;
        }

        public override string ToString()
        {
            addit.Add($"{Gender} {SkinColour}");
            return $"{Id} {Name} {Surname} {Otchestvo}";
        }
    }
}
