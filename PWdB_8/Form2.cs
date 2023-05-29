using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWdB_8
{
    public partial class Form2 : Form
    {
        private Dictionary<string, int> countSubstrings;
        public Form2(Dictionary<string, int> countSubstrings)
        {
            InitializeComponent();
            this.countSubstrings = countSubstrings ?? throw new ArgumentNullException(nameof(countSubstrings));

            foreach(KeyValuePair<string, int> item in countSubstrings)
            {
                listView1.Items.Add($"'{item.Key}' {item.Value}");
            }

            Controls.Add(listView1);
            this.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.Title = "Zapisz wyniki do pliku CSV";
            sfd.ShowDialog();

            if(sfd.FileName != " ")
            {
                using(StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    writer.WriteLine("Substring,Count");
                    foreach(KeyValuePair<string, int> item in countSubstrings)
                    {
                        writer.WriteLine($"{item.Key},{item.Value}");
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
