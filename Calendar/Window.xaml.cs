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
            show_lunar_day(DateTime.Now);
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
            if (((Label)sender).Background != Brushes.Gray) //保留当前天的高亮
                ((Label)sender).Background = new SolidColorBrush(Color.FromArgb(128, 125, 125, 125));
        }

        private void NumMouseLeave(object sender, MouseEventArgs e)
        {
            if (((Label)sender).Background != Brushes.Gray) //保留当前天的高亮
                ((Label)sender).Background = null;
        }

        private void NumMouseClick(object sender, MouseEventArgs e)
        {
            #region 点到灰色的日期,转跳月份
            if (((Label)sender).Foreground == Brushes.Gray)
            {
                if ((int)((Label)sender).Content > 17)
                    LeftArrowClicked(null, null);
                else
                    RightArrowClicked(null, null);
            }
            #endregion
            #region 点击日期,计算农历
            string selected_day = myMonth.ToString() + "/"+ ((Label)sender).Content + "/" + myYear;
            DateTime get_selected_day = Convert.ToDateTime(selected_day);
            show_lunar_day(get_selected_day);
            #endregion
        }

        private void GoMouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = Brushes.Black;
        }

        private void GoMouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = Brushes.Gray;
        }

        #region 显示农历日期
        private void show_lunar_day(DateTime day_time_now)
        {
            LunDay lun_day = new LunDay();
            string s_lun_day = lun_day.GetLunarCalendar(day_time_now);
            textBlock.Text = s_lun_day;
            textBlock.FontSize = 20;
        }
        #endregion

    }
    #region 农历算法
    /// <summary>
    /// LunDay 的摘要说明。
    /// 用法说明
    /// 直接调用即可 public string GetLunarCalendar(DateTime dtDay),比较简单
    /// </summary>
    public class LunDay
    {
        public LunDay()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //天干
        private static string[] TianGan = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        //地支
        private static string[] DiZhi = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        //十二生肖
        private static string[] ShengXiao = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        //农历日期
        private static string[] DayName =   {"*","初一","初二","初三","初四","初五",
             "初六","初七","初八","初九","初十",
             "十一","十二","十三","十四","十五",
             "十六","十七","十八","十九","二十",
             "廿一","廿二","廿三","廿四","廿五",
             "廿六","廿七","廿八","廿九","三十"};

        //农历月份
        private static string[] MonthName = { "*", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        //公历月计数天
        private static int[] MonthAdd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //农历数据
        private static int[] LunarData = {2635,333387,1701,1748,267701,694,2391,133423,1175,396438
            ,3402,3749,331177,1453,694,201326,2350,465197,3221,3402
            ,400202,2901,1386,267611,605,2349,137515,2709,464533,1738
            ,2901,330421,1242,2651,199255,1323,529706,3733,1706,398762
            ,2741,1206,267438,2647,1318,204070,3477,461653,1386,2413
            ,330077,1197,2637,268877,3365,531109,2900,2922,398042,2395
            ,1179,267415,2635,661067,1701,1748,398772,2742,2391,330031
            ,1175,1611,200010,3749,527717,1452,2742,332397,2350,3222
            ,268949,3402,3493,133973,1386,464219,605,2349,334123,2709
            ,2890,267946,2773,592565,1210,2651,395863,1323,2707,265877};
        /// <summary>
        /// 获取对应日期的农历
        /// </summary>
        /// <param name="dtDay">公历日期</param>
        /// <returns></returns>
        public string GetLunarCalendar(DateTime dtDay)
        {
            string sYear = dtDay.Year.ToString();
            string sMonth = dtDay.Month.ToString();
            string sDay = dtDay.Day.ToString();
            int year;
            int month;
            int day;
            try
            {
                year = int.Parse(sYear);
                month = int.Parse(sMonth);
                day = int.Parse(sDay);
            }
            catch
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
                day = DateTime.Now.Day;
            }

            int nTheDate;
            int nIsEnd;
            int k, m, n, nBit, i;
            string calendar = string.Empty;
            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一)
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + MonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2))
                nTheDate += 1;
            //计算天干，地支，月，日
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarData[m] < 4095)
                    k = 11;
                else
                    k = 12;
                n = k;
                while (n >= 0)
                {
                    //获取LunarData[m]的第n个二进制位的值
                    nBit = LunarData[m];
                    for (i = 1; i < n + 1; i++)
                        nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }
                if (nIsEnd == 1)
                    break;
                m = m + 1;
            }
            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;
            //return year+"-"+month+"-"+day;

            #region 格式化日期显示为三月廿四
            if (k == 12)
            {
                if (month == LunarData[m] / 65536 + 1)
                    month = 1 - month;
                else if (month > LunarData[m] / 65536 + 1)
                    month = month - 1;
            }
            //农历月
            if (month < 1)
                calendar = "闰" + MonthName[-1 * month].ToString() + "月";
            else
                calendar = MonthName[month].ToString() + "月";
            //农历日
            calendar += DayName[day].ToString() + " ";

            //生肖
            calendar += ShengXiao[(year - 4) % 60 % 12].ToString() + "年 ";
            //天干
            calendar += TianGan[(year - 4) % 60 % 10].ToString();
            //地支
            calendar += DiZhi[(year - 4) % 60 % 12].ToString() + " ";

            // 返回月,日,年
            return calendar;

            #endregion
        }
    }
    #endregion
}
