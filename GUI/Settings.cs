using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_GUI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_light.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to switch to light mode?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Voltage v = new Voltage();
                    v.BackColor = System.Drawing.Color.White;
                    v.Show();
                    Current c = new Current();
                    c.BackColor = System.Drawing.Color.White;
                    c.Show();
                    Power p = new Power();
                    p.BackColor = System.Drawing.Color.White;
                    p.Show();
                    Form1 f = new Form1();
                    f.BackColor = System.Drawing.Color.White;
                    f.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void radioButton_dark_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_dark.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to switch to dark mode?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Voltage v = new Voltage();
                    v.BackColor = System.Drawing.Color.LightGray;
                    v.Show();
                    Current c = new Current();
                    c.BackColor = System.Drawing.Color.LightGray;
                    c.Show();
                    Power p = new Power();
                    p.BackColor = System.Drawing.Color.LightGray;
                    p.Show();
                    Form1 f = new Form1();
                    f.BackColor = System.Drawing.Color.LightGray;
                    f.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
