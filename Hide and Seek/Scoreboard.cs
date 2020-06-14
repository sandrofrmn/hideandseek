using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hide_and_Seek
{
    public partial class Scoreboard : Form
    {
        string scoreName;
        double finalScore;
        DAL dal = new DAL();
        
        public Scoreboard(string inputName, double inputScore)
        {
            InitializeComponent();
            scoreName = inputName;
            finalScore = inputScore;
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            var prevScore = dal.SelectScore(scoreName);

            dal.SubmitScore(scoreName, finalScore);
            MessageBox.Show("Congratulations, you gained " + Math.Floor(finalScore) + " points");

            //dataGridView1.Rows.InsertRange();
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
            // TODO: This line of code loads data into the 'verstoppertjeScore.Scoreboard' table. You can move, or remove it, as needed.
            this.scoreboardTableAdapter1.Fill(this.verstoppertjeScore.Scoreboard);            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Form1 mainmenu = new Form1();
            Hide();
            mainmenu.ShowDialog();
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
