﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            //DT When finish
            txtPW.Text = "1234";
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "btn1":
                    txtPW.Text += "1";
                    break;
                case "btn2":
                    txtPW.Text += "2";
                    break;
                case "btn3":
                    txtPW.Text += "3";
                    break;
                case "btn4":
                    txtPW.Text += "4";
                    break;
                case "btn5":
                    txtPW.Text += "5";
                    break;
                case "btn6":
                    txtPW.Text += "6";
                    break;
                case "btn7":
                    txtPW.Text += "7";
                    break;
                case "btn8":
                    txtPW.Text += "8";
                    break;
                case "btn9":
                    txtPW.Text += "9";
                    break;
                case "btn0":
                    txtPW.Text += "0";
                    break;
                default:
                    break;
            }  
            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(RunMainForm);
            //thread.Start();
            //this.Close();
            
            //TODO Check in database
            if(txtPW.Text == "1234")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Password is incorrecet!");
            }

            

        }

        private void RunMainForm()
        {
            MainForm mainFm = new MainForm();
            mainFm.Show();
        }
    }
}
