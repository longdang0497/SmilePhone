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
using DAL;
using BUS;
using DTO;
using SmilePhone.CrystalReports;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemPhieuChi.xaml
    /// </summary>
    public partial class UI_ThemPhieuChi : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private DTO_PhieuChi item = new DTO_PhieuChi();

        public UI_ThemPhieuChi(Grid gridMain, DTO_PhieuChi obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            if (obj == null)
            {
                AutoGenerateID();
                isNew = true;
            }
            else
            {
                txtReceiptID.Text = obj.MaPhieuChi;
                cbbEmployeeName.Text = obj.TenNhanVien;
                cbbImportID.Text = obj.MaPhieuNhap;
                txtReceiptNote.Text = obj.GhiChu;
                txtSumMoney.Text = BUS_PhieuChi.Instance.sumMoneyPC(obj.MaPhieuNhap).ToString();
                dpReceiptDate.SelectedDate = obj.NgayChi;
                dpReceiptEditDate.SelectedDate = obj.NgayChinhSua;
                isNew = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbEmployeeName.ItemsSource = BUS_NhanVien.showData();
            cbbImportID.ItemsSource = BUS_PhieuChi.Instance.showPN();
        }

        private void AutoGenerateID()
        {
            txtReceiptID.Text = BUS_PhieuChi.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {                
                if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && cbbEmployeeName.Text != "")
                {
                    item.MaPhieuChi = txtReceiptID.Text.Trim();
                    item.NgayChi = dpReceiptDate.SelectedDate.Value;
                    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                    item.MaPhieuNhap = cbbImportID.Text;
                    item.TenNhanVien = cbbEmployeeName.Text;
                    item.GhiChu = txtReceiptNote.Text.Trim();

                    BUS_PhieuChi.Instance.InsertPC(item);
                    AutoGenerateID();
                    cbbEmployeeName.Text = "";
                    cbbImportID.Text = "";
                    txtReceiptNote.Clear();
                    txtSumMoney.Clear();
                    dpReceiptDate.SelectedDate = null;
                    dpReceiptEditDate.SelectedDate = null;
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {                
                if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && cbbEmployeeName.Text != "")
                {
                    item.MaPhieuChi = txtReceiptID.Text.Trim();
                    item.NgayChi = dpReceiptDate.SelectedDate.Value;
                    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                    item.MaPhieuNhap = cbbImportID.Text;
                    item.TenNhanVien = cbbEmployeeName.Text;
                    item.GhiChu = txtReceiptNote.Text.Trim();

                    BUS_PhieuChi.Instance.UpdatePC(item);
                    AutoGenerateID();
                    cbbEmployeeName.Text = "";
                    cbbImportID.Text = "";
                    txtReceiptNote.Clear();
                    txtSumMoney.Clear();
                    dpReceiptDate.SelectedDate = null;
                    dpReceiptEditDate.SelectedDate = null;
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuChi(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && cbbEmployeeName.Text != "")
            {
                item.MaPhieuChi = txtReceiptID.Text.Trim();
                item.NgayChi = dpReceiptDate.SelectedDate.Value;
                item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                item.MaPhieuNhap = cbbImportID.Text;
                item.TenNhanVien = cbbEmployeeName.Text;
                item.GhiChu = txtReceiptNote.Text.Trim();

                UserControl usc = new PrintForm_PhieuChi(gridMain, item);
                gridMain.Children.Clear();
                gridMain.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtReceiptID.Clear();
            cbbEmployeeName.Text = "";
            cbbImportID.Text = "";
            txtReceiptNote.Clear();
            txtSumMoney.Clear();
            dpReceiptDate.SelectedDate = null;
            dpReceiptEditDate.SelectedDate = null;
            isNew = true;
            AutoGenerateID();
        }

        private void onChangeMoney(object sender, SelectionChangedEventArgs e)
        {
            PhieuNhap phieuNhap = cbbImportID.SelectedItem as PhieuNhap;
            txtSumMoney.Text = BUS_PhieuChi.Instance.sumMoneyPC(phieuNhap.MaPhieuNhap).ToString();
        }
    }
}