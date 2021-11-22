using System;
using System.Collections.Generic;
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
using WPFTextGUI.ViewModels;

namespace WPFTextGUI
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var bookdir = @"C:\PROJECTS\IctPro\CNET2-2021-11\CNET2\Books";

            List<WordInfo> wordInfos = new();

            foreach (var file in GetFilesFromDir(bookdir))
            {
                var dict = TextTools.TextTools.FreqAnalysis(file);
                var top10 = TextTools.TextTools.GetTopWords(10, dict);
                var fi = new FileInfo(file);
                stckWords.Children.Add(new TextBlock() { Text = fi.Name, FontSize = 25 });
                //txbInfo.Text += fi.Name + Environment.NewLine;
                foreach (var kv in top10)
                {
                    //txbInfo.Text += $"{kv.Key}: {kv.Value} {Environment.NewLine}";
                    stckWords.Children.Add(new WordLineInfo(kv.Key));
                }
                //txbInfo.Text += Environment.NewLine;

                wordInfos.AddRange(top10.Select(x => new WordInfo() { Word = x.Key, Count = x.Value}));

                stckWords.Children.Add(new WordLineInfo());

            }
            stckWords.Children.Add(new WordLineInfo());
             
            //itemswords.ItemsSource = wordInfos;

        }

        static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir);
        }
    }
}
