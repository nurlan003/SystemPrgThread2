using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ;
        }
        Thread thread1 = new Thread(()=> { });
        string b = null;
        private void strbtn_Click(object sender, RoutedEventArgs e)
        {
            
            loadingProgressBar.Maximum = b.Length;
            thread1 = new Thread(() =>
            {
                for (int i = 0; i < b.Length; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        totxt.Text += b[i];
                    loadingProgressBar.Value += 1;
                    });
                    Thread.Sleep(1000);
                }
            });
            thread1.Start();
        }

        private void rsmbtn_Click(object sender, RoutedEventArgs e)
        {
            thread1.Resume();


        }

        private void spnbtn_Click(object sender, RoutedEventArgs e)
        {
            thread1.Suspend();


        }

        private void open1btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string dosyaYolu = openFileDialog.FileName;

                try
                {
                    string metin = File.ReadAllText(dosyaYolu);

                   b = metin;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya okuma hatası: " + ex.Message);
                }
            }
        }
    }
}
