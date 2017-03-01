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
using System.Windows.Threading;
using System.Timers;
using System.Text.RegularExpressions;

namespace TIMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { private DispatcherTimer Counttime = new DispatcherTimer();
        private int count = 0;
        
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int hour = GetValue(Hour);
            int minute = GetValue(Minute);
            int second = GetValue(Second);
            int time = hour * 3600 + minute * 60 + second;
            Process.Start("shutdown.exe", "-s -t " + time);
            this.count = time;
            Counttime.Interval = new TimeSpan(0, 0, 1);
            Counttime.Tick += new EventHandler(StartCount);
            Counttime.Start();
         }
        private void StartCount(object sender, EventArgs e)
        {
            this.count -= 1;
            HourCount.Content = (this.count / 3600).ToString();
            MinuteCount.Content = ((this.count % 3600)/60).ToString();
            SecondCount.Content = (this.count % 60).ToString();
        }
        private int GetValue(TextBox tb)
        {
            String string1 = tb.Text.Trim().ToString();
            Regex reg = new Regex("[0-9]");
            if (reg.IsMatch(string1) )
            {
                return int.Parse(string1);
            }else if (string1 == "")
            {
                return 0;
            }
            else
            {
                MessageBox.Show("输入不合法，请输入正整数");
                 return 0;
            }
            
        }
       
    }
}
