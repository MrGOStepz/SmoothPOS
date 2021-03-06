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
    public partial class BackForm : Form
    {
        public BackForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPopup_Click(object sender, EventArgs e)
        {
            AddPopupForm addPopupForm = new AddPopupForm();
            addPopupForm.ShowDialog();
        }

        private void btnUpdatePopup_Click(object sender, EventArgs e)
        {
            SearchPopupForm searchPopupForm = new SearchPopupForm();
            searchPopupForm.ShowDialog();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
