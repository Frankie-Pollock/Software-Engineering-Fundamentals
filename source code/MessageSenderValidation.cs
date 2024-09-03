using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BankFilteringSystem.Back_End
{
    public class MessageSenderValidation
    {
        public string msgID = string.Empty;
        public bool validSender = false;



        /// Method to valodate the contents of the sender type and message length asocaited with the sender type
        public bool MessageValidation(string sender, string msgMain)
        {
            try
            {
                /// If the sender type is sms, then make sure the message is bewteen 1 to 140 characters
                if (sender.Substring(0, 1) == "+" && sender.Length >= 7 && msgMain.Length >0 && msgMain.Length <=139)
                {
                    return validSender = AdvValidation.ValidatePhone(sender);
                }
                /// If the sender type is tweet, then make sure the message is bewteen 1 to 140 characters
                else if (sender.Substring(0, 1) == "@" && sender.Length <= 14 && msgMain.Length > 0 && msgMain.Length <= 139)
                {
                    return validSender = AdvValidation.ValidateTweet(sender);

                }
                /// If the sender type is email, then make sure the message is bewteen 1 to 1028 characters
                else if (sender.Contains("@") && sender.Length <= 40 && msgMain.Length > 0 && msgMain.Length <= 1027)
                {
                    return validSender = AdvValidation.ValidateEmail(sender);
                }
                else
                {
                    /// If none match the sender type, return false
                    return false;
                }
            }
            /// Catch any errors that would arise from incorrect sender type of message
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
