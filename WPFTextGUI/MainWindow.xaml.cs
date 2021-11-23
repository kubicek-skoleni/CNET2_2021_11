using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace WPFTextGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string bigfilesdir = @"C:\Users\Student\Documents\BigFiles";

        static IEnumerable<string> GetBigFiles()
        {
            return Directory.EnumerateFiles(bigfilesdir, "*.txt");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private async void LoadBooks()
        {
            //var bookdir = @"C:\Users\Student\source\repos\CNET2\Books";

            //foreach (var file in GetFilesFromDir(bookdir))
            //{
            //    var dict = await TextTools.TextTools.FreqAnalysisAsync(file);
            //    var top10 = TextTools.TextTools.GetTopWords(10, dict);
            //    var fi = new FileInfo(file);

            //    txbInfo.Text += fi.Name + Environment.NewLine;
            //    foreach (var kv in top10)
            //    {
            //        txbInfo.Text += $"{kv.Key}: {kv.Value} {Environment.NewLine}";
            //    }
            //    txbInfo.Text += Environment.NewLine;
            //}
        }
       
        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            Stopwatch stopwatch = new();
            stopwatch.Start();

            var files = GetBigFiles();

            foreach(var file in files)
            {
                var wordsstats = await TextTools.TextTools.FreqAnalysisFromFileAsync(file, Environment.NewLine);
                var top10 = TextTools.TextTools.GetTopWords(10, wordsstats);

                var fi = new FileInfo(file);
                txbInfo.Text += fi.Name + Environment.NewLine;
                foreach (var kv in top10)
                {
                    txbInfo.Text += $"{kv.Key}: {kv.Value} {Environment.NewLine}";
                }
                txbInfo.Text += Environment.NewLine;
                txbDebugInfo.Text += stopwatch.ElapsedMilliseconds + Environment.NewLine;

                //progressBar1.Value += 10;
            }

            stopwatch.Stop();
            txbDebugInfo.Text = "elapsed ms: " + stopwatch.ElapsedMilliseconds;

            Mouse.OverrideCursor = null;
        }

        private void btnStatsAll_Click(object sender, RoutedEventArgs e)
        {
            var files = GetBigFiles();

            var allwords = 
                string.Join(Environment.NewLine, 
                files.Select(f => File.ReadAllText(f)));

            txbDebugInfo.Text = "ok";
        }
    }
}
