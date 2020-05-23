using EO.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hide_and_Seek
{
    public partial class Game : Form
    {
        private int _seconds;
        private int _minutes;
        List<string> Rooms = new List<string>() { "Hallway", "Bedroom", "Toilet", "Bathroom", "Livingroom", "Kitchen" };
        List<int> MotionSensors = new List<int>() { 3, 9, 10, 11, 12, 13 };
        Random random = new Random();

        public Game()
        {
            InitializeComponent();
            timer1.Start();
            timerRoom.Start();
            timerHall.Start();
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            roomName.Text = "Hallway";
            dal.TurnOn(3);
            timerRoom.Interval = random.Next(7000, 60000);
            timerRoom.Tick += new System.EventHandler(OnTimerEvent);
            
            /*
            DAL dal = new DAL();
            dal.TurnOn(sensor);*/
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            int current_room = random.Next(1, Rooms.Count());
            roomName.Text = Rooms.ElementAt(current_room);
            int sensor = MotionSensors.ElementAt(current_room);
            timerHall.Interval = random.Next(4000, 8000);
            timerHall.Tick += new System.EventHandler(TimerHallEvent);
        }

        public void TimerHallEvent(object source, EventArgs e)
        {
            roomName.Text = "Hallway";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _seconds++;
            if (_seconds < 10)
            {
                time_elapsed.Text = _minutes.ToString() + ":" + "0"+_seconds.ToString();
            }
            else if (_seconds == 60)
            {
                time_elapsed.Text = (_minutes+1).ToString() + ":" + "00";
            }
            else
            {
                time_elapsed.Text = _minutes.ToString() + ":" + _seconds.ToString();
            }
            

            if (_seconds % 60 == 0)
            {
                _minutes++;
                _seconds = 0;
            }


            if (_minutes >= 5)
            {
                timer1.Stop();
                timerHall.Stop();
                timerRoom.Stop();
                time_elapsed.Text = "5:00";
            }

        }

        private void lamp_test_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            dal.ToggleSwitch(3);
        }

        private void time_elapsed_Click(object sender, EventArgs e)
        {

        }
    }
}
