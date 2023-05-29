using System.Text.RegularExpressions;

namespace PWdB_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(this.dnaSequence_KeyPress);
        }

        private void dnaSequence_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex("[ATGCatgc]");
            if (!regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dna = textBox1.Text.ToUpper();

            Dictionary<string, int> countSubstrings = new Dictionary<string, int>();

            for(int i=0; i<dna.Length-3; i++)
            {
                string substring = dna.Substring(i, 4);
                if(countSubstrings.ContainsKey(substring))
                {
                    countSubstrings[substring]++;
                }
                else
                {
                    countSubstrings[substring] = 1;
                }
            }

            Form2 result = new Form2(countSubstrings);
            result.Show();
        }
    }
}