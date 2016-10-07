using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calendar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTexts();
            Left = SystemParameters.PrimaryScreenWidth - Width - 10;
            Top = SystemParameters.PrimaryScreenHeight - Height - 50;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Methods.ExtendAeroToFullWindow(this);
        }

        private int myYear = DateTime.Now.Year, myMonth = DateTime.Now.Month;
        private int current_month = DateTime.Now.Month;//当前月,是不变的
        
        private void SetTexts()
        {
            DateTime tempDateTime = new DateTime(myYear, myMonth, 1); //获取当年当月的第一天
            tempDateTime = tempDateTime.AddDays((int)tempDateTime.DayOfWeek == 0 ? -7 : -(int)tempDateTime.DayOfWeek);//计算第一个位置是那一天
            for (int i = 10; i < myGrid.Children.Count; i++) //遍厉所有日期,改变他们的content,对应上日期
            {
                ((Label)myGrid.Children[i]).Foreground = tempDateTime.Month == myMonth ? Brushes.Black : Brushes.Gray;//为日期上色
                #region 给这个月的星期六,星期日上红色
                if (((int)tempDateTime.DayOfWeek == 6 || (int)tempDateTime.DayOfWeek == 0) && tempDateTime.Month == myMonth)
                {
                    ((Label)myGrid.Children[i]).Foreground = Brushes.Red;
                }
                #endregion
                #region 高亮当前日
                if (DateTime.Now.Day == tempDateTime.Day && tempDateTime.Month == current_month)
                    ((Label)myGrid.Children[i]).Background = Brushes.Gray;
                else
                    ((Label)myGrid.Children[i]).Background = Brushes.White;
                #endregion

                ((Label)myGrid.Children[i]).Content = tempDateTime.Day;//改变他们的content
                tempDateTime = tempDateTime.AddDays(1);//日期加1
            }
            txtCMonth.Text = myYear.ToString() + "-" + (myMonth < 10 ? "0" : "") + myMonth.ToString();//改变年月的内容

            

        }

        private void RightArrowClicked(object sender, MouseButtonEventArgs e)
        {
            myMonth++;
            if(myMonth == 13)
            {
                myYear++;
                myMonth = 1;
            }
            SetTexts();
        }

        private void LeftArrowClicked(object sender, MouseButtonEventArgs e)
        {
            myMonth--;
            if (myMonth == 0)
            {
                myYear--;
                myMonth = 12;
            }
            SetTexts();
        }

        private void NumMouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = new SolidColorBrush(Color.FromArgb(128, 125, 125, 125));
        }

        private void NumMouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = null;
        }

        private void NumMouseClick(object sender, MouseEventArgs e)
        {
            if (((Label)sender).Foreground == Brushes.Gray)
            {
                if ((int)((Label)sender).Content > 17)
                    LeftArrowClicked(null, null);
                else
                    RightArrowClicked(null, null);
            }
        }

        private void GoMouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = Brushes.Black;
        }

        private void GoMouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = Brushes.Gray;
        }

    }
}
