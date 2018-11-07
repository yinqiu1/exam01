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
    public partial class KaiMenUCtrl : UserControl
    {
        public KaiMenUCtrl(SerialPort c)
        {
            InitializeComponent();
            com = c;
            #region 定时器相关
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            count = 0;
            timer.Elapsed += (x, y) =>
            {
                count++;
                InvokeMethod(count);
            };
            #endregion
        }
        private SerialPort com;
        DbOps op = new DbOps();
        // 定义委托
        // public delegate void DataChangeHandler(string x); 一次可以传递一个string
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;
        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        /// <summary>
        /// 自定义事件参数类型，根据需要可设定多种参数便于传递
        /// </summary>
        public class DataChangeEventArgs : EventArgs
        {
            public string name { get; set; }
            public string pass { get; set; }
            public DataChangeEventArgs(string s1, string s2)
            {
                name = s1;
                pass = s2;
            }
        }
        #region 定时器、实现界面延迟
        private int count = 0;
        System.Timers.Timer timer;
        private void InvokeMethod(int count)
        {
            Action<int> invokeAction = new Action<int>(InvokeMethod);
            if (this.InvokeRequired)
            {
                this.Invoke(invokeAction, count);
            }
            else
            {
                button1.Text = "测试(" + count.ToString() + "s)";
                if (count == 3)
                {
                    timer.Stop();
                    //Thread.Sleep(3000);
                    //程序判断，点测试按钮后，读计量模块测量的交流电压，小于10V视为合格，否则不合格            
                    byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.readjldy.Trim()));
                    if (recData.Length < 1)
                    {
                        MessageBox.Show("未读取到数据");
                        return;
                    }
                    //交流电压
                    byte[] l = toolFunc.sliceBytes2Array(recData, 7, 4);
                    float r = toolFunc.byte4tofloat(l);
                    textBox1.Text = r.ToString();

                    //交流电流
                    l = toolFunc.sliceBytes2Array(recData, 11, 4);
                    float r1 = toolFunc.byte4tofloat(l);
                    textBox2.Text = r1.ToString();

                    //测试完成之后将结果写入数据库
                    if (r < 10)
                    {
                        op.updateTestResult(5, "pass");
                        resultlabel.Text = "状态:测试通过";
                    }
                    else
                    {
                        op.updateTestResult(5, "fail");
                        resultlabel.Text = "状态:测试不通过";
                    }
                    button1.Enabled = false;
                }
            }
        }

        private void Star_Click()
        {
            if (button1.Text == "测试")
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Star_Click();
        }
    }
}
