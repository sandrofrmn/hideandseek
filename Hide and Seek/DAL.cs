﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hide_and_Seek
{
    class DAL
    {
        //string connectionString = "Data Source=LAPTOP-7251AEHH;Initial Catalog=VerstoppertjeDatabase;Integrated Security=True";
        string connectionString = "Data Source=LAPTOP-LO42FTJT\\SQLEXPRESS;Initial Catalog=VerstoppertjeDatabase;Integrated Security=True";
        public string domoticz_checker(string domoticz_URL)
        {
            HttpWebRequest request =
            WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }
        public void domoticz_handler(string domoticz_URL)
        {
            HttpWebRequest request =
            WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
        }

        public void WriteToDomDb(int hider, string room, int amountOfSeconds)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string command = "INSERT INTO VerstopperLog VALUES (@Hider, @Room, @AmountOfSeconds)";
            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                cmd.Parameters.AddWithValue("@Hider", hider);
                cmd.Parameters.AddWithValue("@Room", room);
                cmd.Parameters.AddWithValue("@AmountOfSeconds", amountOfSeconds);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void SelectToDb(string command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["Hider"].ToString());
                Console.WriteLine(rdr["Room"].ToString());
                Console.WriteLine(rdr["AmountOfSeconds"].ToString());
            }
        }

        public void DeleteRecords()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string command = "DELETE FROM VerstopperLog";
            using (SqlCommand cmd = new SqlCommand(command, conn))
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void DomThreadURL(int switchID)
        {
            domoticz_handler(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + switchID));
        }

        public void ToggleSwitch(int switchID)
        {

            string output = domoticz_checker(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + switchID));
            if (output.Contains(@"""Status"" : ""On"""))
            {
                domoticz_handler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + switchID + "&switchcmd=Off");
            }
            else
            {
                domoticz_handler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + switchID + "&switchcmd=On");
            }
        }

        public void TurnOn(int switchID)
        {
            domoticz_handler(("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + switchID + "&switchcmd=On"));
        }

        public void TurnOff(int switchID)
        {
            domoticz_handler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + switchID + "&switchcmd=Off");
        }

        public void TurnGroupOff(int sceneGroupID)
        {
            domoticz_handler("http://127.0.0.1:8080/json.htm?type=command&param=switchscene&idx=" + sceneGroupID + "&switchcmd=Off");
        }

        public int SelectScore(string name)
        {
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Points FROM Scoreboard WHERE Name = @Name", conn);
            cmd.Parameters.AddWithValue("@Name", name);

            int oldscore = Convert.ToInt32(cmd.ExecuteScalar());
            return oldscore;
        }
        

        public void SubmitScore(string name, double score)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmdCount = new SqlCommand("SELECT COUNT(Name) FROM Scoreboard WHERE Name = @Name", conn);
            cmdCount.Parameters.AddWithValue("@Name", name);
            int count = Convert.ToInt32(cmdCount.ExecuteScalar());
            
            if (count == 0)
            {
                string command = "INSERT INTO Scoreboard(Name, Points) VALUES (@Name, @Score)";
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            } 
            else
            {
                string command = "UPDATE Scoreboard SET Points = Points + @Score WHERE Name = @Name";
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
