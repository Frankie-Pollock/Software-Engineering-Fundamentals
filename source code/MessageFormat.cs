using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Win32;

namespace BankFilteringSystem.Back_End
{
    class MessageFormat
    {
        public string FormatMsg(string msgMain)
        {

            try
            {
                /// Asking the user to select the file with textword abbreviations
                string filesLocation = Environment.CurrentDirectory;
                string csvPath = filesLocation + "\\textwords.csv";
                /// Getting all lines from the CSV file and assiging it to an array
                string[] csvLines = System.IO.File.ReadAllLines(csvPath);

                /// List of strings to hold the short versions of the textwords and the expanded versions
                List<string> short_ver = new List<string>();
                List<string> long_ver = new List<string>();

                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');
                    /// Getting the short and expanded words from each row of CSV
                    short_ver.Add(rowData[0]);
                    long_ver.Add(rowData[1]);
                }
                for (int i = 0; i < short_ver.Count; i++)
                {
                    /// If the message contains any short versions, add the long version next to it without replacing anything
                    if (msgMain.Contains(short_ver[i]))
                    {
                        msgMain = msgMain.Replace(short_ver[i].ToString(), short_ver[i].ToString() + "<" + long_ver[i].ToString() + ">");   
                    }
                }
            }
            /// Catch any error that could arise from textwords.csv not being opened correctly
            catch
            {
                MessageBox.Show("The CSV File 'textwords.csv' Could not be opened. Please make sure the file is closed if it is not");
            }
            return msgMain;
        }
        /// Method for removing URLs from email and assiging them to a quarentine list
        public static string RemoveURLFromEmail(string msgMain)
        {
            string[] words = msgMain.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains("https://") || words[i].Contains("HTTPS://") || words[i].Contains("http://") || words[i].Contains("HTTP://"))
                {
                    msgMain = msgMain.Replace(words[i], "<URL Quarentined>");
                }
            }
            return msgMain;
        }
    }
}