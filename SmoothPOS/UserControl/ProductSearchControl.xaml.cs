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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for SearchProductControl.xaml
    /// </summary>
    public partial class ProductSearchControl : UserControl
    {
        public ProductSearchControl()
        {
            InitializeComponent();
            Loaded += ProductSearchControl_Loaded;
        }

        private void ProductSearchControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DatabaseHandle dbHandle = new DatabaseHandle();

            //ProductModel productModel = new ProductModel();
            //productModel = dbHandle.GetPro
        }
    }
}
