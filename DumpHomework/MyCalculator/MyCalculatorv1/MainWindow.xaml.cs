using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MyCalculatorv1
{
	// Token: 0x02000003 RID: 3
	public partial class MainWindow : Window
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002093 File Offset: 0x00000293
		public MainWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A4 File Offset: 0x000002A4
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			TextBox textBox = this.tb;
			textBox.Text += button.Content.ToString();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020DD File Offset: 0x000002DD
		private void Result_click(object sender, RoutedEventArgs e)
		{
			this.result();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020E8 File Offset: 0x000002E8
        private void result()
        {
            int num1 = 0;
            if (this.tb.Text.Contains("+"))
                num1 = this.tb.Text.IndexOf("+");
            else if (this.tb.Text.Contains("-"))
                num1 = this.tb.Text.IndexOf("-");
            else if (this.tb.Text.Contains("*"))
                num1 = this.tb.Text.IndexOf("*");
            else if (this.tb.Text.Contains("/"))
                num1 = this.tb.Text.IndexOf("/");
            string str = this.tb.Text.Substring(num1, 1);
            double num2 = Convert.ToDouble(this.tb.Text.Substring(0, num1));
            double num3 = Convert.ToDouble(this.tb.Text.Substring(num1 + 1, this.tb.Text.Length - num1 - 1));
            if (str == "+")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 + num3);
            }
            else if (str == "-")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 - num3);
            }
            else if (str == "*")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 * num3);
            }
            else
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 / num3);
            }
        }

		// Token: 0x06000008 RID: 8 RVA: 0x00002311 File Offset: 0x00000511
		private void Off_Click_1(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000231F File Offset: 0x0000051F
		private void Del_Click(object sender, RoutedEventArgs e)
		{
			this.tb.Text = "";
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002334 File Offset: 0x00000534
		private void R_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.tb.Text.Length > 0;
			if (flag)
			{
				this.tb.Text = this.tb.Text.Substring(0, this.tb.Text.Length - 1);
			}
		}
	}
}
