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

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
            pwBox.Password = "1234";
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button btnTemp = sender as Button;

            switch (btnTemp.Name)
            {
                case "btn1":
                    pwBox.Password += "1";
                    break;
                case "btn2":
                    pwBox.Password += "2";
                    break;
                case "btn3":
                    pwBox.Password += "3";
                    break;
                case "btn4":
                    pwBox.Password += "4";
                    break;
                case "btn5":
                    pwBox.Password += "5";
                    break;
                case "btn6":
                    pwBox.Password += "6";
                    break;
                case "btn7":
                    pwBox.Password += "7";
                    break;
                case "btn8":
                    pwBox.Password += "8";
                    break;
                case "btn9":
                    pwBox.Password += "9";
                    break;
                case "btn0":
                    pwBox.Password += "0";
                    break;
                default:
                    break;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (pwBox.Password == "1234")
            {
                MainWindow mainForm = new MainWindow();
                mainForm.Show();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string pwText = pwBox.Password;
            if(pwText.Length > 0)
            {
                pwText = pwText.Remove(pwText.Length - 1);
                pwBox.Password = pwText;
            }
            else
            {
                return;
            }

        }
    }
}
