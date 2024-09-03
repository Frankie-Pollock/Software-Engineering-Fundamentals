using BankFilteringSystem.Back_End;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        /// <summary>
        /// Start up Import form 
        /// </summary>
        public Import()
        {
            InitializeComponent();
        }
        /// When this button is clicked, the following will happen
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            /// Trying the following code
            try
            {
                /// Getting the current Messages.txt file from executables directory
                string filesLocation = Environment.CurrentDirectory;
                string filepath = filesLocation + "\\Messages.txt";

                /// Validating the correct file format
                if (!filepath.Contains(".txt"))
                {
                    MessageBox.Show("Incorrect file selected. Try again!");
                    return;
                    
                }
                /// Getting the sender, subject and mainMsg from each line. Firstly by reading in lines, then by taking 1-3 blocks of text seperated by ','
                string senders = File.ReadLines(filepath).Take(1).First();
                string[] sendersSplit = senders.Split(',');
                string subject = File.ReadLines(filepath).Skip(1).Take(1).First();
                string[] subjectSplit = subject.Split(',');
                string mainMsg = File.ReadLines(filepath).Skip(2).Take(1).First();
                string[] mainMsgSplit = mainMsg.Split(',');
                int length = sendersSplit.Length;
                for (int i = 0; i < sendersSplit.Length; i++)
                {
                    /// Notifying the user this is the final message in the input form
                    if (i == length - 1)
                    {
                        MessageBox.Show("THIS IS THE FINAL MESSAGE IMPORTED. IF YOU CLICK NEXT MESSAGE, THE APPLICATION WILL END ");
                    }
                    /// Calling the MessageProcessing class to process method
                    MessageProcessing.Process(sendersSplit[i], subjectSplit[i], mainMsgSplit[i]);

                }
                /// Ending the application
                Environment.Exit(1);
            }
            /// Catch any errors related to the filetype or contents
            catch (Exception)
            {
                MessageBox.Show("Incorrect file or contents");
            }


        }
        /// Clicking this button will return to the MainWindow
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }
    }
}