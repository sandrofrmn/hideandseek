using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Core;

namespace Hide_and_Seek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxDifficulty.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(numTime(), Difficulty());
            Hide();
            game.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(comboBoxDifficulty.SelectedItem.ToString());
            DAL dal = new DAL();

            //dal.WriteToDomDb("INSERT INTO VerstopperLog(Verstopper, Room, AmountOfSeconds) VALUES (1, 'Kitchen', 3)");
            //dal.SelectToDb("SELECT * FROM VerstopperLog WHERE Hider=2");
        }

        private void numberTime_ValueChanged(object sender, EventArgs e)
        {
            numberTime.Minimum = 3;
            numberTime.Maximum = 10;
            
        }

        public int numTime()
        {
            int time = Convert.ToInt32(numberTime.Value);
            return time;
        }

        public string Difficulty()
        {
            string difficulty = comboBoxDifficulty.SelectedItem.ToString();
            return difficulty;
        }
    }
}
