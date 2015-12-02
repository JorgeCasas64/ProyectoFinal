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

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Proveedor_Click(object sender, RoutedEventArgs e)
        {
            VentanaProvedor vta = new VentanaProvedor();
            vta.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VentanaServicio vta = new VentanaServicio();
            vta.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            VentanaAsistente vta = new VentanaAsistente();
            vta.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            VentanaFactura vta = new VentanaFactura();
            vta.Show();
        }
    }
}
