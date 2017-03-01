using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace TIMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String time = Time.Text.Trim().ToString();
            Regex reg = new Regex("[0-9]");
            if (reg.IsMatch(time)){
                Process.Start("shutdown.exe", "-s -t " + time);
            }
            else
            {
                MessageBox.Show("输入不合法，请输入正整数");
            }
        }
    }
}
