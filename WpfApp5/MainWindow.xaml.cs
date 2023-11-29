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
        Thread thread1 = new Thread(() => { });

        void TextTransfer()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                string ilkDosyaYolu = fromtxt.Text;
                string ikinciDosyaYolu = totxt.Text;
                using (StreamReader sr = new StreamReader(ilkDosyaYolu))
                {
                    using (StreamWriter sw = new StreamWriter(ikinciDosyaYolu))
                    {
                        int charr;
                        while ((charr = sr.Read()) != -1)
                        {
                            sw.Write((char)charr);
                            MessageBox.Show($"{charr}");
                        }
                    }
                }
            });
            Thread.Sleep(1000);


        }
        private void strbtn_Click(object sender, RoutedEventArgs e)
        {


            thread1 = new Thread(() =>
            {
                TextTransfer();
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
            openFileDialog.Filter = "Text(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                fromtxt.Text = openFileDialog.FileName;
            }


            string FilePathforCount = fromtxt.Text;
            using (StreamReader sr = new StreamReader(FilePathforCount))
            {
                int charcount = 0;

                while (sr.Read() != -1)
                {
                    charcount++;
                }
                loadingProgressBar.Maximum = charcount;
            }
        }

        private void open2btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text  (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                totxt.Text = openFileDialog.FileName;

            }
        }
    }
}
