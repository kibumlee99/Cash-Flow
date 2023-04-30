﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cash_Flow
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        private string message;
        public Message(string mssge)
        {
            InitializeComponent();
            messageLabel.Content = mssge;
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
