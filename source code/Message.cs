using System;
using System.Collections.Generic;
using System.Text;

namespace BankFilteringSystem.Back_End
{
    public class Message
    {
        /// Getter and Setters for Message object
        public string getMsgID { get; set; }
        public string getSender { get; set; }
        public string getSubject { get; set; }
        public string getMainBody { get; set; }
        public string getSortCode { get; set; }
        public string getNoI { get; set; }
        /// Message constructer 
        public Message()
        {
            getMsgID = string.Empty;
            getSender = string.Empty;
            getSubject = string.Empty;
            getMainBody = string.Empty;
        }
        /// Message contructer for SMS or Tweet
        public Message(string msgID, string sender, string main)
        {
            getMsgID = msgID;
            getSender = sender;
            getMainBody = main;
        }
        /// Message Constructor for Email
        public Message(string msgID, string sender, string subject, string main)
        {
            getMsgID = msgID;
            getSender = sender;
            getSubject = subject;
            getMainBody = main;
        }
        /// Message Constructor for SIR Report Email
        public Message(string msgID, string sender, string subject, string main, string sortcode, string NoI)
        {
            getMsgID = msgID;
            getSender = sender;
            getSubject = subject;
            getSortCode = sortcode;
            getMainBody = main;
            getNoI = NoI;
        }
    }
}
