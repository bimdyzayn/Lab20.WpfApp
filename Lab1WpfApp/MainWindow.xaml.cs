using System;
using System.Data;
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

namespace Lab1WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
               
            if (textLabel.Text == "0")
                textLabel.Text = "";
            else
                textLabel.Text = textLabel.Text + "";
            
            string str = (string)((Button)e.OriginalSource).Content;
            switch (str)
            {
                case "CE":
                    textLabel.Text = "0";
                    break;

                case "C":
                    textLabel.Text = "0";
                    break;

                case "=":
                    textLabel.Text = textLabel.Text.Replace(",", ".");
                    string value = new DataTable().Compute(textLabel.Text, null).ToString();
                    if (value.IndexOf(",0") >= 0)
                    {
                        value = value.Substring(0, value.IndexOf(",0"));

                    }
                    textLabel.Text = value;
                    break;

                case "←":
                    if (textLabel.Text.Length <= 1)
                    {
                        textLabel.Text = "0";
                    }else

                    textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length-1);
                    break;

                case "√x":
                    textLabel.Text = (Math.Sqrt(Convert.ToDouble(textLabel.Text))).ToString();
                        break;

                case "x²":
                    textLabel.Text = (Convert.ToDouble(textLabel.Text) * Convert.ToDouble(textLabel.Text)).ToString();
                    break;


                case ",":

                    textLabel.Text = textLabel.Text +",";
                    break;

                case "+/-":
                    if (textLabel.Text.Substring(0,1) == "-")
                    {
                        textLabel.Text = textLabel.Text.Substring(1, textLabel.Text.Length-1);
                    } else
                    {
                        textLabel.Text = "-" + textLabel.Text;

                    }
                    break;

                default:
                    textLabel.Text += str;
                    break;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
