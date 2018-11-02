using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using DataBase;
using System.Threading;
using WindowsFormsApplication1.Com;

namespace WindowsFormsApplication1.Funcs
{
    public partial class MainView : UserControl
    {
        DbOps op = new DbOps();
        public MainView()
        {
            InitializeComponent();            
            
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Timer2_Load();

            //cpvolttbx.Text = "0";
            //cpfrtbx.Text = "0";
            //cpdutytbx.Text = "0";
            //cpcutbx.Text = "0";

            //axvolttbx.Text = "0";
            //axcutbx.Text = "0";
            //bxvolttbx.Text = "0";
            //bxcutbx.Text = "0";
            //cxvolttbx.Text = "0";
            //cxcutbx.Text = "0";
            //powertbx.Text = "0";
            //energytbx.Text = "0";
            
            //ccstatustbx.Text = "空闲状态";
            Mytimer.Start();
        }

        #region  定时器
        //定义Timer类变量
        System.Timers.Timer Mytimer;
        //int TimeCount;        
        //定义委托
        public delegate void SetControlValue();

        private void Timer2_Load()
        {
            //设置时间间隔ms
            int interval = 1000;
            Mytimer = new System.Timers.Timer(interval);
            //设置重复计时
            Mytimer.AutoReset = true;
            //设置执行System.Timers.Timer.Elapsed事件

            Mytimer.Elapsed += new System.Timers.ElapsedEventHandler(Mytimer_tick);
        }
        private void Mytimer_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            //防止在窗口句柄初始化之前就走到下面的代码
            while (!this.IsHandleCreated)
            {
                ;
            }
            //this.Invoke(new InitRunFunction(InitWindows));
            this.Invoke(new SetControlValue(ShowTime));
            //TimeCount++;
        }

        private void ShowTime()
        {
            //TimeSpan temp = new TimeSpan(0, 0, (int)t);
            //txtTimeShow.Text = string.Format("{0:00}:{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds);
            cpvolttbx.Text = Com.acboard.cpvolt;
            cpfrtbx.Text = Com.acboard.cpfr;
            cpdutytbx.Text = Com.acboard.cpduty;
            cpcutbx.Text = Com.acboard.cpcu;

            axvolttbx.Text = Com.acboard.Axvolt;
            axcutbx.Text = Com.acboard.Axcu;
            bxvolttbx.Text = Com.acboard.Bxvolt;
            bxcutbx.Text = Com.acboard.Bxcu;
            cxvolttbx.Text = Com.acboard.Cxvolt;
            cxcutbx.Text = Com.acboard.Cxcu;
            powertbx.Text = Com.acboard.inpower;
            energytbx.Text = Com.acboard.chargeSingle;
            ccstatustbx.Text = Com.acboard.chargestatus;

           // ccstatustbx.Text = "ss状态";
        }

        #endregion

    }
}
