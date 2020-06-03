﻿using EO.Internal;
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
        public bool start = true;
        List<string> Rooms = new List<string>() { "Hallway", "Bedroom", "Toilet", "Bathroom", "Livingroom", "Kitchen" };
        List<int> MotionSensors = new List<int>() { 3, 9, 10, 11, 12, 13 };
        Random random = new Random();
        DAL dal = new DAL();
        Form1 mainmenu = new Form1();

        public Game()
        {
            InitializeComponent();
            timer1.Start();
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            
            if (start)
            {
                roomName.Text = "Hallway";
                dal.TurnGroupOff(2);
                dal.TurnOn(3);
                start = false;
            }
            timerRoom.Start();
            timerHall.Start();
            timerRoom.Interval = random.Next(4000, 8000);
            dal.TurnOff(3);
            dal.TurnOff(9);
            dal.TurnOff(11);
            timerRoom.Tick += new System.EventHandler(OnTimerEvent);
            
            /*
            DAL dal = new DAL();
            dal.TurnOn(sensor);*/
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            dal.TurnGroupOff(2);
            int current_room = random.Next(0, Rooms.Count());
            roomName.Text = Rooms.ElementAt(current_room);
            int sensor = MotionSensors.ElementAt(current_room);
            
            dal.TurnOn(sensor);
            timerRoom.Stop();

            timerHall.Start();
            timerHall.Interval = random.Next(7000, 45000);
            timerHall.Tick += new System.EventHandler(TimerHallEvent);
            
            
        }

        public void TimerHallEvent(object source, EventArgs e)
        {
            dal.TurnGroupOff(2);
            int number = random.Next(0,1);
            if ((number == 0 && roomName.Text == "Bedroom") || (number == 0 && roomName.Text == "Bathroom")) {
                if (roomName.Text == "Bedroom")
                {
                    roomName.Text = "Bathroom";
                    dal.TurnOn(11);
                    dal.TurnOff(9);
                    start = true;
                }
                else
                {
                    roomName.Text = "Bedroom";
                    dal.TurnOn(9);
                    dal.TurnOff(11);
                    start = true;
                }
            }
            else
            {  
                roomName.Text = "Hallway";
                dal.TurnOn(3);
            }

            
            timerHall.Stop();
            timerRoom.Start();
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

            
            if (_minutes >= mainmenu.numTime)
            {
                timer1.Stop();
                timerHall.Stop();
                timerRoom.Stop();
                time_elapsed.Text = "5:00";
                dal.TurnOn(14);
            }

        }


        
        private void lamp_test_Click(object sender, EventArgs e)
        { 
        }

        private void time_elapsed_Click(object sender, EventArgs e)
        {

        }  

    }
}
