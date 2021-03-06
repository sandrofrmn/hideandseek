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
        public bool runOnce = true;
        //USER VARIABLES
        public string chosenName;
        public int amountOfClicks;
        //public DateTime time1;
        //public DateTime time2;
        List<string> Rooms = new List<string>() { "Hallway", "Bedroom", "Toilet", "Bathroom", "Livingroom", "Kitchen" };
        List<int> MotionSensors = new List<int>() { 3, 9, 10, 11, 12, 13 };
        public int count = 0;
        Random random = new Random();
        DAL dal = new DAL();

        //TODO: fix bedroom -> bathroom and bathroom -> bedroom where it takes currently 4 to 8 seconds (timerRoom) instead of 7 to 45 (timerHall)
        //TODO: If hallway is logged into the database, it logs multiple times with the same AmountOfSeconds
        //TODO: In the seeker system a log from the pre round will be showed
        //TODO: The webpage must be cropped for a nicer look
        
        public Game(string inputName, int inputMinutes, string inputDifficulty)
        {
            InitializeComponent();
            allowedMinutes = inputMinutes;
            setDifficulty = inputDifficulty;
            chosenName = inputName;
            timer1.Start();
            dal.DeleteRecords();
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'verstoppertjeDatabaseDataSet1.VerstopperLog' table. You can move, or remove it, as needed.
            this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
            if (start)
            {
                roomName.Text = "Hallway";
                dal.TurnGroupOff(2);
                dal.TurnOn(3);
                webBrowser1.Refresh();
                start = false;
                timerRoom.Interval = random.Next(3000, 7000);
            }
            timerRoom.Start();
            timerHall.Start();
            dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerRoom.Interval / 1000));
                       
            dal.TurnOff(9);
            dal.TurnOff(11);
            timerRoom.Tick += new EventHandler(OnTimerEvent);
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            if (start)
            {
                roomName.Text = "Hallway";
                dal.TurnGroupOff(2);
                dal.TurnOn(3);
                webBrowser1.Refresh();
                start = false;
                timerRoom.Interval = random.Next(3000, 7000);
            }
            timerRoom.Start();
            timerHall.Start();
            

            webBrowser1.Refresh();
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
            timerHall.Interval = random.Next(6000, 30000);

            runOnce = true;
            timerHall.Tick += new EventHandler(TimerHallEvent);
        }

        public void TimerHallEvent(object source, EventArgs e)
        {
            if (runOnce)
            {
                dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerHall.Interval / 1000));
                Log.Update();
                Log.Refresh();
                this.verstopperLogTableAdapter.Fill(this.verstoppertjeDatabaseDataSet.VerstopperLog);
                dal.TurnGroupOff(2);

                int number = random.Next(0, 2);
                if ((number == 0 && roomName.Text == "Bedroom") || (number == 0 && roomName.Text == "Bathroom"))
                {
                    if (roomName.Text == "Bedroom")
                    {
                        roomName.Text = "Bathroom";

                        dal.TurnOn(11);
                        dal.TurnOff(9);
                        webBrowser1.Refresh();
                        start = true;
                    }
                    else
                    {
                        roomName.Text = "Bedroom";
                        dal.TurnOn(9);
                        dal.TurnOff(11);
                        webBrowser1.Refresh();

                        start = true;

                    }
                    timerRoom.Interval = random.Next(6000, 30000);
                }
                else
                {
                    roomName.Text = "Hallway";
                    dal.TurnOn(3);
                    timerRoom.Interval = random.Next(3000, 7000);
                }
                dal.WriteToDomDb(1, roomName.Text, Convert.ToInt32(timerRoom.Interval / 1000));

                Log.Update();
                Log.Refresh();
                
                timerHall.Stop();
                timerRoom.Start();

                runOnce = false;
            }     
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

            if (_seconds % 60 == 0 || _seconds >= 60)
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
                    Log.Visible = false;
                }
            }

            if (_minutes >= allowedMinutes)
            {
                time_elapsed.Text = allowedMinutes + ":00";
                timer1.Stop();
                if (preRound)
                {
                    preRound = false;
                    Log.Visible = false;
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
                    objectsLose();
                }
                dal.TurnOn(14);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //var floorplan = webBrowser1.Document.GetElementById("mFloorplan");
            //floorplan.Style = "zoom:200%";


            //  webBrowser1.Document.Body.Style = "zoom:100%";
        }

        public void objectsWin()
        {
            amountOfClicks += 1;
            buttonBathroom.Visible = false;
            buttonBedroom.Visible = false;
            buttonHallway.Visible = false;
            buttonKitchen.Visible = false;
            buttonLivingroom.Visible = false;
            buttonToilet.Visible = false;
            labelAgain.Visible = false;
            pictureBoxWin.Visible = true;
            labelWin.Visible = true;
            timerHall.Stop();
            timerRoom.Stop();
            timer1.Stop();
            EndGame();
        }
       public void objectsLose()
        {
            buttonBathroom.Visible = false;
            buttonBedroom.Visible = false;
            buttonHallway.Visible = false;
            buttonKitchen.Visible = false;
            buttonLivingroom.Visible = false;
            buttonToilet.Visible = false;
            labelAgain.Visible = false;
            timerHall.Stop();
            timerRoom.Stop();
            labelLoos.Visible = true;
            pictureBoxLoser.Visible = true;
            EndGame();
        }

        public void WrongChoice()
        {
            labelAgain.Visible = true;
            amountOfClicks += 1;
            _seconds += 20;
        }

        public void EndGame()
        {
            int totalTime = allowedMinutes * 60;
            int timeLeft = totalTime - (_minutes * 60 + _seconds);
            double score = (Math.Pow(amountOfClicks, -0.95) * timeLeft);
            double score2 = (double)180 / totalTime;
            score = Math.Floor(score * score2);
            if (amountOfClicks == 0)
            {
                score = 0;
            }

            if (setDifficulty == "0")
            {
                Math.Floor(score = score * .7);
            }
            Console.WriteLine("score: " + score);
            Scoreboard scoreboard = new Scoreboard(chosenName, score);
            scoreboard.ShowDialog();
        }



        private void buttonKitchen_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Kitchen")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }

        private void buttonToilet_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Toilet")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }

        private void buttonBedroom_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Bedroom")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }

        private void buttonHallway_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Hallway")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }

        private void buttonLivingroom_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Livingroom")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }

        private void buttonBathroom_Click(object sender, EventArgs e)
        {
            if (roomName.Text == "Bathroom")
            {
                objectsWin();
            }
            else
            {
                WrongChoice();
            }
        }



    }
}