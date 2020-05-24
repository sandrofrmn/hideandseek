﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hide_and_Seek
{
    class DAL
    {
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
    }
}
