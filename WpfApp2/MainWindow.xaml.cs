using System;
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
using System.Text.RegularExpressions;
using iTextSharp;
using iTextSharp.text;
using Microsoft.Win32;
using System.IO;
using GemBox.Document;

namespace WpfApp2
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
  //    ITextSharp
  //    GemBox.Document

        private void txt_TextChanged(object sender, TextChangedEventArgs e )
        {
            string str = "znaki: ";
            string str2 = "słowa: ";
            count.Text = str + txt.Text.Count();

            countw.Text=str2+ Regex.Matches(txt.Text, @"[\w']+").Count;
        }

        private void MenuItem_Wyjdz(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Kopiuj(object sender, RoutedEventArgs e)
        {
            string contntText = txt.Text.ToString();
            Clipboard.SetText(contntText);
        }

        private void MenuItem_Wytnij(object sender, RoutedEventArgs e)
        {
            txt.Text = "";
        }

        private void MenuItem_Wklej(object sender, RoutedEventArgs e)
        {


        }

        private void MenuItem_Minus(object sender, RoutedEventArgs e)
        {
            txt.FontSize -= 1;
        } 
      

        private void MenuItem_Plus(object sender, RoutedEventArgs e)
        {
            txt.FontSize += 1;
        }

        private void MenuItem_Nowy(object sender, RoutedEventArgs e)
        { 
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file (*.txt) |*.txt|c# file(*.cs)|*.cs";

            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, txt.Text);  
            }
        }
      
        private void MenuItem_Zapisz(object sender, RoutedEventArgs e)
        {
            string filex = @"d:\Android\xxx.txt";
          
                File.WriteAllText(filex, txt.Text);
            
        }

        private void MenuItem_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Document (.txt |*.txt";
            if(dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;
                txt.Text = filename;
                txt.Text = File.ReadAllText(filename);
            }
        }
        double s = 1;
        string skala="Skala: ";
    /*    private void MenuItem_Pov(object sender, RoutedEventArgs e)
        {
            *//*    txt.LayoutTransform = new RotateTransform(0, 900, 9000);*//*

        }*/
        private void Pov_Minus(object sender, RoutedEventArgs e)
        {
            s-=0.05;
          txt.LayoutTransform = new ScaleTransform(s,s);
            scal.Text = skala + s;

        }
        private void Pov_Plus(object sender, RoutedEventArgs e)
        {
            s+=0.05;
            txt.LayoutTransform = new ScaleTransform(s, s);
            scal.Text = skala + s;
        }
    }
}