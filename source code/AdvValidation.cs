using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BankFilteringSystem.Back_End
{

    /// <summary>
    /// This class is used to perform some simple text parsing functions using regex.
    /// </summary>
    class AdvValidation
    { 
        /// <summary>
        /// Regex function to check the phone number is in a valid format
        /// </summary>
    public static bool ValidatePhone(string Sender)
        {
            return Regex.Match(Sender, @"^(\+[0-9]{7,15})$").Success;
        }
        /// <summary>
        /// Using a random number generator, an ID for a SMS is generated.
        /// </summary>
        public static string SIDGenerator()
        {
            Random rnd = new Random();
            int numb = rnd.Next(100000000, 999999999);
            return "S" + numb;
        }
        /// <summary>
        /// Regex function to check the phone number is in a valid format.
        /// </summary>
        public static bool ValidateTweet(string Sender)
        {
            return Regex.Match(Sender, @"^(@[A-Za-z0-9_]{4,15})$").Success;

        }
        /// <summary>
        /// Using a random number generator, an ID for a tweet is generated.
        /// </summary>
        public static string TIDGenerator()
        {
            Random rnd = new Random();
            int numb = rnd.Next(100000000, 999999999);
            return "T" + numb;
        }
        /// <summary>
        /// Regex function to check the email is in a valid format.
        /// </summary>
        public static bool ValidateEmail(string Sender)
        {
            return Regex.Match(Sender, @"^([\w\.\-]+)@([\w\-]+).(com|net|org|gov|example)$", RegexOptions.IgnoreCase).Success;
        }
        /// <summary>
        /// Regex function to check the email is in a valid format.
        /// </summary>
        public static bool ValidateSubject(string Subject)
        {
            return Regex.Match(Subject, @"[^.*]{0,19}$").Success;
        }
        /// <summary>
        /// Using a random number generator, an ID for a email is generated.
        /// </summary>
        public static string EIDGenerator()
        {
            Random rnd = new Random();
            int numb = rnd.Next(100000000, 999999999);
            return "E" + numb;
        }
        /// <summary>
        /// Using a random number generator, an ID for a email is generated.
        /// </summary>
        public static bool SIRVerify(string text)
        {
            return Regex.Match(text, @"^[0-9]+[0-9]+-+[0-9]+[0-9]+-+[0-9]+[0-9]\s+(Theft|Raid|Terrorism|Intelligence|Staff\sAttack|ATM\sTheft|Customer\sAttack|Staff\sAbuse|Bomb\sTheft|Suspicious\sIncident|Cash\sLoss).*$").Success;
        }
    }
}
