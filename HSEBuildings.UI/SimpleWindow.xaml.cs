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

namespace HSEBuildings.UI
{
    /// <summary>
    /// Interaction logic for SimpleWindow.xaml
    /// </summary>
    public partial class SimpleWindow : Window
    {
        public SimpleWindow()
        {
            InitializeComponent();
            image.Source = new BitmapImage(new Uri("Resources/placeholder.png",UriKind.Relative));
                
        }
    }
}