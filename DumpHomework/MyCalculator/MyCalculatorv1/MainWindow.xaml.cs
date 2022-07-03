using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MyCalculatorv1
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			TextBox textBox = tb;
			textBox.Text += button.Content.ToString();
		}

		private void Result_click(object sender, RoutedEventArgs e)
		{
			result();
		}

        private void result()
        {
            if (!Regex.IsMatch(tb.Text, @"^\d+[\+\-\*\/]\d+$"))
            {
                tb.Text = "Invalid input";
                return;
            }

            int num1 = 0;
            if (tb.Text.Contains("+"))
                num1 = tb.Text.IndexOf("+");
            else if (tb.Text.Contains("-"))
                num1 = tb.Text.IndexOf("-");
            else if (tb.Text.Contains("*"))
                num1 = tb.Text.IndexOf("*");
            else if (tb.Text.Contains("/"))
                num1 = tb.Text.IndexOf("/");
            string str = tb.Text.Substring(num1, 1);
            double num2 = Convert.ToDouble(tb.Text.Substring(0, num1));
            double num3 = Convert.ToDouble(tb.Text.Substring(num1 + 1, tb.Text.Length - num1 - 1));
            if (str == "+")
            {
                tb.Text = tb.Text + "=" + (num2 + num3);
            }
            else if (str == "-")
            {
                tb.Text = tb.Text + "=" + (num2 - num3);
            }
            else if (str == "*")
            {
                tb.Text = tb.Text + "=" + num2 * num3;
            }
            else
            {
                tb.Text = tb.Text + "=" + num2 / num3;
            }
        }

		private void Off_Click_1(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Del_Click(object sender, RoutedEventArgs e)
		{
			tb.Text = "";
		}

		private void R_Click(object sender, RoutedEventArgs e)
		{
			bool flag = tb.Text.Length > 0;
			if (flag)
			{
				tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
			}
		}
	}
}
