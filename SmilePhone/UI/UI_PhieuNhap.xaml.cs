﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BUS;
using DAL;
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_PhieuNhap.xaml
    /// </summary>
    public partial class UI_PhieuNhap : UserControl
    {
        private Grid gridMain;
        private Regex regex;
        private bool isRefreshing = false;
        public UI_PhieuNhap(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            dgvStockImport.ItemsSource = BUS_PhieuNhap.showData();
            dpFromPC.SelectedDate = DateTime.Today.AddDays(0);
            dpToPC.SelectedDate = DateTime.Today.AddDays(0);
        }
        #region Highlight search
        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindListViewItem(dgvStockImport);
        }

        public void FindListViewItem(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DataGrid lv = obj as DataGrid;
                if (lv != null)
                {
                    HighlightText(lv);
                }
                FindListViewItem(VisualTreeHelper.GetChild(obj as DependencyObject, i));
            }
        }

        private void HighlightText(Object itx)
        {
            if (itx != null)
            {
                if (itx is TextBlock)
                {
                    regex = new Regex("(" + txtSearch.Text + ")", RegexOptions.IgnoreCase);
                    TextBlock tb = itx as TextBlock;
                    if (txtSearch.Text.Length == 0)
                    {
                        string str = tb.Text;
                        tb.Inlines.Clear();
                        tb.Inlines.Add(str);
                        return;
                    }
                    string[] substrings = regex.Split(tb.Text);
                    tb.Inlines.Clear();
                    foreach (var item in substrings)
                    {
                        if (regex.Match(item).Success)
                        {
                            Run runx = new Run(item);
                            runx.Background = Brushes.Yellow;
                            tb.Inlines.Add(runx);
                        }
                        else
                        {
                            tb.Inlines.Add(item);
                        }
                    }
                    return;
                }
                else
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(itx as DependencyObject); i++)
                    {
                        HighlightText(VisualTreeHelper.GetChild(itx as DependencyObject, i));
                    }
                }
            }
        }
        #endregion
        private void btnSearchStr_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvStockImport.ItemsSource = BUS_PhieuNhap.Instance.searchData(searchStr);
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromPC = dpFromPC.SelectedDate.Value;
            DateTime toPC = dpToPC.SelectedDate.Value;
            dgvStockImport.ItemsSource = BUS_PhieuNhap.Instance.searchDate(fromPC, toPC);
        }

        private void btnLapPhieu_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuNhap(gridMain, dgvStockImport.SelectedItem as DTO_PhieuNhap);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvStockImport.ItemsSource = BUS_PhieuNhap.Instance.searchData(searchStr);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvStockImport.SelectedItem != null)
                {
                    DTO_PhieuNhap obj = new DTO_PhieuNhap();
                    obj = dgvStockImport.SelectedItem as DTO_PhieuNhap;
                    String id = obj.MaPhieuNhap;

                    BUS_PhieuNhap.Delete(id);
                    dgvStockImport.ItemsSource = BUS_PhieuNhap.showData();

                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuNhap(gridMain, dgvStockImport.SelectedItem as DTO_PhieuNhap);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            isRefreshing = true;
            txtSearch.Clear();
            dpFromPC.SelectedDate = DateTime.Today.AddDays(0);
            dpToPC.SelectedDate = DateTime.Today.AddDays(0);
            dgvStockImport.ItemsSource = BUS_PhieuNhap.showData();
            isRefreshing = false;
        }

        private void onFromDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpToPC.SelectedDate != null)
                {
                    if (dpToPC.SelectedDate.Value < dpFromPC.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpFromPC.SelectedDate = dpToPC.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpFromPC.SelectedDate = null;
                dpToPC.SelectedDate = null;
            }
        }

        private void onToDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpFromPC.SelectedDate != null)
                {
                    if (dpToPC.SelectedDate.Value < dpFromPC.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpToPC.SelectedDate = dpFromPC.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpToPC.SelectedDate = null;
                dpFromPC.SelectedDate = null;
            }
        }
    }
}
