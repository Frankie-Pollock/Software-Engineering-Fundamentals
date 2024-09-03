using BankFilteringSystem.Back_End;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankFilteringSystem.Front_end
{
    /// <summary>
    /// Interaction logic for MsgDisplay.xaml
    /// </summary>
    
    public partial class MsgDisplay : Window
    {
        ///List to store msgs in
        List<Object> msgs = new List<Object>();

        /// initialize the MsgDisplay Form
        public MsgDisplay()
        {
            InitializeComponent();
        }
        /// Display a message to the form and add the message to a message list
        public void Display(Message msg)
        {
            MIDTxtBlock.Text = msg.getMsgID;
            SenderTxtBlock.Text = msg.getSender;
            SubjectTxtBlock.IsEnabled = false;
            lblSubj.Content = "";
            MainTxtBlock.Text = msg.getMainBody;
            msgs.Add(msg);
        }
        /// Display an email message to the form and add the message to a message list
        public void DisplayEmail(Message msg)
        {
            MIDTxtBlock.Text = msg.getMsgID;
            SenderTxtBlock.Text = msg.getSender;
            SubjectTxtBlock.Text = msg.getSubject;
            MainTxtBlock.Text = msg.getMainBody;
            msgs.Add(msg);
        }
        /// Display a SIR message to the form and add the message to a message list
        public void DisplaySIR(Message msg)
        {
            MIDTxtBlock.Text = msg.getMsgID;
            SenderTxtBlock.Text = msg.getSender;
            SubjectTxtBlock.Text = msg.getSubject;
            MainTxtBlock.Text = "Sort code: " + msg.getSortCode + "\nNatue of Incident: " + msg.getNoI + "\n" + msg.getMainBody;
            msgs.Add(msg);
        }
        /// When the button "Exit" is clicked, the form will close, the message list will be saved and displayList form will be opepned
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
            string json = JsonConvert.SerializeObject(msgs);
            SaveToFile.JsonS(json);
            DisplayLists displaying = new DisplayLists();
            displaying.PopulateLists();
            displaying.ShowDialog();

        }
        /// When this button is clicked, the form will be hidden and the previous form will open
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            InputForm form = new InputForm();
            form.ShowDialog();
        }
        /// Whent this button is clicked, the current message will be closed and the next message displayed if used by a import system
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }


    }
}
