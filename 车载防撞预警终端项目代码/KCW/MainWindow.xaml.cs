﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ADSDK.Bases;
using ADSDK.Device;
using ADSDK.Device.Reader;
using ADSDK.Device.Reader.Passive;
using System.IO;
using System.IO.Ports;


namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Vehicle1.Stroke = Brushes.Red;
            Vehicle1.Fill = Brushes.Red;
         //   Vehicle2.Fill = 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
