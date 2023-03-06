using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace kalkulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int baza = 2;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox2.Text));
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text));
        }

        private void Decimal_Checked(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBoxAns.Text, baza), 10);
            baza = 10;
        }

        private void Heksadecimal_Checked(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToInt32(textBoxAns.Text).ToString("X");
            baza = 16;
        }

        private void Binary_Checked(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBoxAns.Text,baza),2);
            baza = 2;
        }

        private void Octal_Checked(object sender, RoutedEventArgs e)
        {
            textBoxAns.Text = Convert.ToString(Convert.ToInt32(textBoxAns.Text, baza), 8);
            baza = 8;
        }

        private void textBox1_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string pattern = "";
            switch(baza)
            {
                case (2):
                    pattern = "[^0-1]";
                    break;
                case (8):
                    pattern = "[^0-7]";
                    break;

                case (10):
                    pattern = "[^0-9]";
                    break;

                case (16):
                    pattern = "[^0-F]";
                    break;
            }
            if(Regex.IsMatch(textBox1.Text,pattern))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }
    }
}
