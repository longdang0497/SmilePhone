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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_LapPhieuBanHang.xaml
    /// </summary>
    public partial class UI_LapPhieuBanHang : UserControl
    {
        private Grid gridMain;

        public UI_LapPhieuBanHang(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BanHang(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
    }
}
