using BankFilteringSystem.Front_end;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace BankFilteringSystem.Back_End
{
    class MessageProcessing
    {


        public static void Process(string msgSender, string msgSubject, string msgMain)
        {

            ///Attribute that will hold the ID later
            string msgID = "";
            ///Calling a Method to check validity of Sender and assigning it to a true or false
            MessageSenderValidation Svalid = new MessageSenderValidation();
            bool senderValid = Svalid.MessageValidation(msgSender, msgMain);
            //Checks if Sender is false, asking for reinput 
            if (senderValid == false)
            {
                MessageBox.Show("Please Enter all required data");
                InputForm newForm = new InputForm();
                newForm.ShowDialog();

            }
            //Checks if Sender is True, and if the Sender is in the form of SMS, tweet or email
            else if (senderValid == true && (msgSender.Substring(0, 1) == "+" || msgSender.Substring(0, 1) == "@"))
            {
                //Calling a method and returning a new value of the Main Text
                MessageFormat Form = new MessageFormat();
                msgMain = Form.FormatMsg(msgMain);
                if (msgSender.Substring(0, 1) == "+")
                {
                    /// Call AdvValidation to generate a msgID
                    msgID = AdvValidation.SIDGenerator();
                    /// Call message constructor
                    Message msg = new Message(msgID, msgSender, msgMain);
                    /// Open Display form to display message
                    MsgDisplay Display = new MsgDisplay();
                    Display.Display(msg);
                    Display.ShowDialog();

                }
                else if (msgSender.Substring(0, 1) == "@")
                {
                    /// Call AdvValidation to generate a msgID
                    msgID = AdvValidation.TIDGenerator();
                    DisplayLists.TrendingList(msgMain);
                    DisplayLists.MentionsList(msgMain);

                    /// Call message constructor
                    Message msg = new Message(msgID, msgSender, msgMain);
                    /// Open Display form to display message
                    MsgDisplay Display = new MsgDisplay();
                    Display.Display(msg);
                    Display.ShowDialog();

                }
                /// Asking user to enter information again as something was wrong
                else Console.WriteLine("You have entered something invalid, please try again!");


            }
            else if (msgSender.Contains("@"))
            {
                /// Call AdvValidation to generate a msgID
                msgID = AdvValidation.EIDGenerator();
                /// Call a method to add URL to a qurentine list
                DisplayLists.QuarantineList(msgMain);
                /// Call a method to remove the URL from the message
                msgMain = MessageFormat.RemoveURLFromEmail(msgMain);
                /// Check if the subject is an SIR report
                if (Regex.Match(msgSubject, "^SIR .*$").Success)
                {
                    if (Regex.Match(msgSubject, "^SIR [0-9]{2}\\/[0-9]{2}\\/[0-9]{2}$").Success)
                    {
                        /// Make sure report date is valid
                        string date = msgSubject.Remove(0, 4);
                        DateTime parsedDate = DateTime.Parse(date);

                        if (parsedDate <= DateTime.Today)
                        {
                            /// Call method to extract sortcode
                            string sortcode = DisplayLists.SNUMB(msgMain);
                            /// Call method to extract nature of incident
                            string NoI = DisplayLists.NOI(msgMain);
                            msgMain = msgMain.Replace(sortcode, "");
                            msgMain = msgMain.Replace(NoI, "");
                            string SCNOI = "Sortcode: " + sortcode + "\nNature of incident: " + NoI;
                            /// Call method to add Sort Code and NoI to a list
                            DisplayLists.SIRList(SCNOI);
                            msgMain = msgMain.Trim();

                            /// Call message constructor
                            Message msg = new Message(msgID, msgSender, msgSubject, msgMain, sortcode, NoI);
                            /// Open Display form to display message
                            MsgDisplay Display = new MsgDisplay();
                            Display.DisplaySIR(msg);
                            Display.ShowDialog();
                        }
                        else
                        MessageBox.Show("The date is not right, try again");
                        InputForm newForm = new InputForm();
                        newForm.ShowDialog();
                    }

                    else MessageBox.Show("You entered the wrong SIR information, try again please.");
                    InputForm newForm2 = new InputForm();
                    newForm2.ShowDialog();
                }
                else
                {
                    /// Call message constructor
                    Message msg = new Message(msgID, msgSender, msgSubject, msgMain);
                    /// Open Display form to display message
                    MsgDisplay Display = new MsgDisplay();
                    Display.DisplayEmail(msg);
                    Display.ShowDialog();

                }
            }
        }
    }
}

