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
    public partial class Scoreboard : Form
    {
        string scoreName;
        public Scoreboard(string inputName)
        {
            InitializeComponent();
            scoreName = inputName;
        }

        
        private void Scoreboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'verstoppertjeScoreboard.Scoreboard' table. You can move, or remove it, as needed.
            this.scoreboardTableAdapter.Fill(this.verstoppertjeScoreboard.Scoreboard);
            MessageBox.Show(scoreName);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Form1 mainmenu = new Form1();
            Hide();
            mainmenu.ShowDialog();
            Close();
        }
    }
}
