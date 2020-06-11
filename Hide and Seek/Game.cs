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
        public int allowedMinutes;
        public string setDifficulty;
        public bool start = true;
        public bool preRound = true;
        public bool lockDifficulty = false;
        List<string> Rooms = new List<string>() { "Hallway", "Bedroom", "Toilet", "Bathroom", "Livingroom", "Kitchen" };
        List<int> MotionSensors = new List<int>() { 3, 9, 10, 11, 12, 13 };
        public int count = 0;
        Random random = new Random();
        DAL dal = new DAL();

        //TODO: fix bedroom -> bathroom and bathroom -> bedroom where it takes currently 4 to 8 seconds (timerRoom) instead of 7 to 45 (timerHall)
        //TODO: If hallway is logged into the database, it logs multiple times with the same AmountOfSeconds
        //TODO: In the seeker system a log from the pre round will be showed
        //TODO: The webpage must be cropped for a nicer look
        

        public Game(int inputMinutes, string inputDifficulty)
        {
            InitializeComponent();
            allowedMinutes = inputMinutes;
            setDifficulty = inputDifficulty;
            timer1.Start();
            dal.DeleteRecords();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
            if (start)
            {
                roomName.Text = "Hallway";
                dal.TurnGroupOff(2);
                dal.TurnOn(3);
                webBrowser1.Refresh();
                
                start = false;
            }
            timerRoom.Start();
            timerHall.Start();
            timerRoom.Interval = random.Next(2000, 3000);
            dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerRoom.Interval / 1000));

            dal.TurnOff(3);
            dal.TurnOff(9);
            dal.TurnOff(11);
            timerRoom.Tick += new EventHandler(OnTimerEvent);
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            count = count + 1;
            Console.WriteLine(count);
            Log.Update();
            Log.Refresh();
            this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
            
            dal.TurnGroupOff(2);
            int current_room = random.Next(0, Rooms.Count());
            roomName.Text = Rooms.ElementAt(current_room);
            
            
            int sensor = MotionSensors.ElementAt(current_room);
            dal.TurnOn(sensor);

            webBrowser1.Refresh();
            
            timerRoom.Stop();

            timerHall.Start();
            timerHall.Interval = random.Next(3000, 5000);
            
                        
            timerHall.Tick += new EventHandler(TimerHallEvent);
        }

        public void TimerHallEvent(object source, EventArgs e)
        {

            dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerHall.Interval / 1000)+1);
            Log.Update();
            Log.Refresh();
            this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
            dal.TurnGroupOff(2);
            /*
            int number = random.Next(0, 1);
            if ((number == 0 && roomName.Text == "Bedroom") || (number == 0 && roomName.Text == "Bathroom"))
            {
                if (roomName.Text == "Bedroom")
                {
                    roomName.Text = "Bathroom";
                    
                    dal.TurnOn(11);
                    dal.TurnOff(9);
                    webBrowser1.Refresh();
                    Log.Update();
                    Log.Refresh();
                    start = true;
                }
                else
                {
                    roomName.Text = "Bedroom";
                    
                    dal.TurnOn(9);
                    dal.TurnOff(11);
                    webBrowser1.Refresh();
                    
                    Log.Update();
                    Log.Refresh();
                    this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
                    start = true;
                }
            }
            else
            {
                roomName.Text = "Hallway";
                
                dal.TurnOn(3);
                webBrowser1.Refresh();
                Log.Update();
                Log.Refresh();
            }
            */


            timerHall.Stop();
            timerRoom.Start();
            timerRoom.Interval = random.Next(4000, 6000);

            roomName.Text = "test kamer";
            dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerHall.Interval / 1000) + 1);


            Log.Update();
            Log.Refresh();
            this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _seconds++;
            if (_seconds < 10)
            {
                time_elapsed.Text = _minutes.ToString() + ":" + "0" + _seconds.ToString();
            }
            else if (_seconds == 60)
            {
                time_elapsed.Text = (_minutes + 1).ToString() + ":" + "00";
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

            if (lockDifficulty == false)
            {
                if (setDifficulty == "Easy")
                {
                    setDifficulty = "0";
                }
                else
                {
                    setDifficulty = "1";
                }
                lockDifficulty = true;
            }


            if (_minutes == (allowedMinutes - Convert.ToInt32(setDifficulty)) && _seconds == 0)
            {
                roomName.Visible = false;
                if (setDifficulty == "1")
                {
                    webBrowser1.Visible = false;
                }
            }

            if (_minutes >= allowedMinutes)
            {
                timer1.Stop();
                if (preRound)
                {
                    preRound = false;
                    _minutes = 0;
                    _seconds = 0;
                    timer1.Start();
                    webBrowser1.Visible = false;
                    buttonBathroom.Visible = true;
                    buttonBedroom.Visible = true;
                    buttonHallway.Visible = true;
                    buttonKitchen.Visible = true;
                    buttonLivingroom.Visible = true;
                    buttonToilet.Visible = true;
                } 
                else
                {
                    timerHall.Stop();
                    timerRoom.Stop();
                }
                

                //time_elapsed.Text = allowedMinutes + ":00";
                dal.TurnOn(14);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Navigate("localhost:8080/#/Floorplans");
            webBrowser1.Document.Body.Style = "zoom:100%";
            webBrowser1.ScriptErrorsSuppressed = true;
        }
}
}