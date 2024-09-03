using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;


namespace BankFilteringSystem.Front_end
{
    /// <summary>
    /// Interaction logic for DisplayLists.xaml
    /// </summary>
    public partial class DisplayLists : Window
    {
        /// lists of strings to store mentions, trending, SIR and URLS for future display
        public static List<string> mentions = new List<string>();
        public static List<string> trending = new List<string>();
        public static List<string> SIR = new List<string>();
        public static List<string> URLS = new List<string>();

        public DisplayLists()
        {
            InitializeComponent();
        }
        /// Extracting any twitter mentions and adding them to a list of mentions
        public static void MentionsList(string text)
        {
        string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                {
                    if (words[i].Substring(0, 1) == "@")
                    {
                        mentions.Add(words[i]);
                    }
                }
            }
        }
        /// Extracting a list of hashtags and adding them to a trending list
        public static void TrendingList(string text)
        {

            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                {
                    if (words[i].Substring(0, 1) == "#")
                    {
                        trending.Add(words[i]);
                    }
                }
            }

        }
        /// Extracting any URLs contained in text, adding them to a qurentine list
        public static void QuarantineList(string text)
        {

            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                {
                    if (words[i].Contains("https://") || words[i].Contains("HTTPS://") || words[i].Contains("http://") || words[i].Contains("HTTP://"))
                    {
                        URLS.Add(words[i]);
                    }
                }
            }
        }
        /// Adding SIR to a list
        public static void SIRList(string text)
        {
            SIR.Add(text);
        }
        /// Checking if the SIR number is a real valid number
        public static string SNUMB(string text)
        {
            string snumb = "";
            string news = Regex.Replace(text, @"\n", " ");
            string[] words = news.Split(' ');

            if (Regex.Match(news, @"^[0-9]+[0-9]+-+[0-9]+[0-9]+-+[0-9]+[0-9].*$").Success)
            {
                snumb = words[0];
            }
            return snumb;
        }
        /// Getting the nature of incident and validating that is is a real case
        public static string NOI(string text)
        {
            string NoI = "";
            string news = Regex.Replace(text, @"\n", " ");
            string[] words = news.Split(' ');
            /// Regex to see if it is one of the following NoI
            if (Regex.Match(news, @"^[0-9]+[0-9]+-+[0-9]+[0-9]+-+[0-9]+[0-9]\s(Theft|Raid|Terrorism|Intelligence).*$").Success)
            {
                NoI = words[1];
            }
            /// Another Regex to see if it is another type of NoI
            else if (Regex.Match(news, @"^[0-9]+[0-9]+-+[0-9]+[0-9]+-+[0-9]+[0-9]\s(Staff\sAttack|ATM\sTheft|Customer\sAttack|Staff\sAbuse|Bomb\sTheft|Suspicious\sIncident|Cash\sLoss).*$").Success)
            {
                NoI = words[1] + " " + words[2];
            }
            return NoI;
        }
        /// Adding the lists to the display
        public void PopulateLists()
        {
            if (mentions.Count > 0)
            {
                for (int i = 0; i < mentions.Count; i++)
                {

                    lstMentions.Items.Add(mentions[i]);
                }
            }
           if (trending.Count > 0)
            {
                IOrderedEnumerable<KeyValuePair<string, string>> wordsDic = trending
                        .GroupBy(p => p)
                        .ToDictionary(p => p.Key, q => "Count: " + q.Count())
                        .OrderByDescending(key => key.Value);
                foreach (KeyValuePair<string, string> kvp in wordsDic)
                {
                    lstTrending.Items.Add($"{kvp.Key}, {kvp.Value}");
                }
            }
            if (SIR.Count > 0)
            {
                for (int i = 0; i < SIR.Count; i++)
                {
                   lstSIR.Items.Add(SIR[i]);
                }
            }
        }
        /// If this button is clicked, the application will end
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
