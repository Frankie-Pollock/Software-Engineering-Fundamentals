using BankFilteringSystem.Back_End;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for InputForm.xaml
    /// </summary>
    public partial class InputForm : Window
    {
        /// <summary>
        /// Start up InputForm 
        /// </summary>
        public InputForm()
        {
            InitializeComponent();
        }

        /// When this button is clicked, the attributes will be assigned, this form will be hidden and the MessageProcessingn class will be called to operate
        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            ///Defining Attributes From TextBox To new Attributes for Processing
            string msgSender = SenderTxtBox.Text;

            string msgSubject = SubjectTxtBox.Text;

            string msgMain = MainTxtBox.Text;
            Hide();
            MessageProcessing.Process(msgSender, msgSubject, msgMain);

        }
        /// When this button is clicked, the current form will be hidden and MainWindow will be reopened
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();

        }


    }
}
