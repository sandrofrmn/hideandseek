using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hide_and_Seek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            Hide();
            game.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DAL dal = new DAL();

            //dal.WriteToDomDb("INSERT INTO VerstopperLog(Verstopper, Room, AmountOfSeconds) VALUES (1, 'Kitchen', 3)");
            dal.SelectToDb("SELECT * FROM VerstopperLog WHERE Hider=2");
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
    }
}
