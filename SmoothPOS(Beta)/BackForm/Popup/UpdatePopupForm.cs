﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class UpdatePopupForm : Form
    {
        public int PopupID { get; set; }

        public UpdatePopupForm()
        {
            InitializeComponent();
        }

        private void InitializeData()
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            string JSON = dbHandle.GetPopupDetail(PopupID);

            if (JSON != null)
            {

            }
            else
            {
                //TODO MessangeBox ERROR and Close this form
            }
        }

    }
}
