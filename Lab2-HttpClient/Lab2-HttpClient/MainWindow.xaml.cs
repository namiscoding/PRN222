﻿using System.Net.Http;
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

namespace Lab2_HttpClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        readonly HttpClient client = new HttpClient();

        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty;
            txtURL.Text = string.Empty;
        }

        private async void btnFetchData_Click(object sender, RoutedEventArgs e)
        {
            string uri = txtURL.Text;

            try
            {
                string responseBody = await client.GetStringAsync(uri);
                txtContent.Text = responseBody.Trim();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Message: {ex.Message}");
            }
        }
    }
}