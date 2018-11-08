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
    public partial class ShiZhiWCUCtrl : UserControl
    {
        public ShiZhiWCUCtrl(SerialPort c)
        {
            InitializeComponent();
            com = c;
            shizhidiff = false;
            fufeidiff = false;
            read1 = false;
            read2 = false;
            read3 = false;
            button1.Enabled = false;
            #region 定时器相关
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            count = 0;
            timer.Elapsed += (x, y) =>
            {
                count++;
                InvokeMethod(count);
            };
            #endregion
        }

        private void ShiZhiWCUCtrl_Load(object sender, EventArgs e)
        {
            //先设置计量模块参数
            byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szSet01.Trim()));
            if (recData.Length < 1)
            {
                //MessageBox.Show("szSet01未读取到数据");
                resultlabel.Text = "szSet01未读取到数据";
                return;
            }
            if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
            {
                //MessageBox.Show("szSet01设备测试指令异常");
                resultlabel.Text = "szSet01设备测试指令异常";
                return;
            }
            Thread.Sleep(500);
            recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szSet02.Trim()));
            if (recData.Length < 1)
            {
                //MessageBox.Show("szSet02未读取到数据");
                resultlabel.Text = "szSet02未读取到数据";
                return;
            }
            if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
            {
                //MessageBox.Show("szSet02设备测试指令异常");
                resultlabel.Text = "szSet02设备测试指令异常";
                return;
            }
            Thread.Sleep(500);
            recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szSet03.Trim()));
            if (recData.Length < 1)
            {
                //MessageBox.Show("szSet03未读取到数据");
                resultlabel.Text = "szSet03未读取到数据";
                return;
            }
            if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
            {
                //MessageBox.Show("szSet03设备测试指令异常");
                resultlabel.Text = "szSet03设备测试指令异常";
                return;
            }
            Thread.Sleep(500);
            recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szSet04.Trim()));
            if (recData.Length < 1)
            {
                //MessageBox.Show("szSet04未读取到数据");
                resultlabel.Text = "szSet04未读取到数据";
                return;
            }
            if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
            {
                //MessageBox.Show("szSet04设备测试指令异常");
                resultlabel.Text = "szSet04设备测试指令异常";
                return;
            }
            button1.Enabled = true;
        }
        
        #region 变量定义、委托定义
        
        private SerialPort com;
        DbOps op = new DbOps();

        private static bool shizhidiff = false;
        private static bool fufeidiff = false;
        private static bool read1 = false;
        private static bool read2 = false;
        private static bool read3 = false;

        // 定义委托        
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
        #endregion        
        
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
                switch ((int)(count % 4))
                {
                    case 1:
                        if (!read1)
                        {
                            //1、上位机发“计量模块读第1页，环境温度Ary33（4Byte ,float）和湿度Ary34（4Byte ,float）命令”          
                            byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szRwsd.Trim()));
                            if (recData.Length < 23)
                            {
                                resultlabel.Text = "szRwsd未读取到数据";
                                return;
                            }
                            //环境温度Ary33（4Byte ,float）
                            byte[] l = toolFunc.sliceBytes2Array(recData, 11, 4);
                            float r = toolFunc.byte4tofloat(l);
                            textBox6.Text = r.ToString("0.000");
                            //湿度Ary34（4Byte ,float）
                            l = toolFunc.sliceBytes2Array(recData, 15, 4);
                            float r1 = toolFunc.byte4tofloat(l);
                            textBox7.Text = r1.ToString("0.000");
                            read1 = true;
                        }
                        break;
                    case 2:
                        if (!read2)
                        {
                            //2、上位机发＂读第1页，交流电压Ary00（4Byte）、交流电流Ary01(4Byte)，交流频率Ary04(4Byte)，交流功率Ary06(4Byte)＂          
                            byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szRvahp.Trim()));
                            if (recData.Length < 31)
                            {
                                resultlabel.Text = "szRvahp未读取到数据";
                                return;
                            }
                            //交流电压Ary00（4Byte）
                            byte[] l = toolFunc.sliceBytes2Array(recData, 7, 4);
                            float r = toolFunc.byte4tofloat(l);
                            textBox8.Text = r.ToString("0.00");
                            //交流电流Ary01(4Byte)
                            l = toolFunc.sliceBytes2Array(recData, 11, 4);
                            float r1 = toolFunc.byte4tofloat(l);
                            textBox9.Text = r1.ToString("0.0000");
                            //交流频率Ary04(4Byte)
                            l = toolFunc.sliceBytes2Array(recData, 15, 4);
                            r = toolFunc.byte4tofloat(l);
                            textBox11.Text = r.ToString("0.00");
                            //交流功率Ary06(4Byte)
                            l = toolFunc.sliceBytes2Array(recData, 19, 4);
                            r1 = toolFunc.byte4tofloat(l);
                            textBox10.Text = r1.ToString("0.00");
                            read2 = true;
                        }
                        break;
                    case 3:
                        if (!read3)
                        {
                            //3、上位机发＂读交流走字状态Ary13（1Byte）、交流走字标准电能值Ary14(4Byte)，交流走字电能脉冲数Ary15(8Byte)，交流走字时间Ary16(8Byte)＂      
                            byte[]  recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szRvahp1.Trim()));
                            if (recData.Length < 36)
                            {
                                resultlabel.Text = "szRvahp1未读取到数据";
                                return;
                            }
                            //读交流走字状态Ary13（1Byte）
                            int l_int = toolFunc.slice1Byte(recData, 8, 1);
                            switch (l_int)
                            {
                                case 1:
                                    textBox16.Text = "已启动";
                                    break;
                                case 2:
                                    textBox16.Text = "测量中";
                                    break;
                                case 3:
                                    textBox16.Text = "已停止";
                                    break;
                            }
                            //交流走字标准电能值Ary14(4Byte)                       
                            byte[]  l = toolFunc.sliceBytes2Array(recData, 9, 4);
                            float r1 = toolFunc.byte4tofloat(l);
                            textBox12.Text = r1.ToString();
                            //标准电能值*率单价=标准付费金额
                            float ffje = r1 * float.Parse(textBox4.Text);
                            textBox13.Text = ffje.ToString("0.00");
                            //[(电能示值－标准电能)／标准电能]*100% =示值误差
                            float szfc = (float.Parse(textBox1.Text) - r1) * 100;
                            textBox14.Text = szfc.ToString("0.00");
                            //示值误差判定                        
                            if (Math.Abs(szfc) <= float.Parse(textBox3.Text))
                            {
                                shizhidiff = true;
                            }
                            //2、计算测量结果：，|标准付费金额-付费金额示值|=付费误差
                            float ffwc = Math.Abs(ffje - float.Parse(textBox2.Text));
                            textBox15.Text = ffwc.ToString("0.00");
                            //付费误差判定
                            if (ffwc <= float.Parse(textBox5.Text))
                            {
                                fufeidiff = true;
                            }
                            //交流走字电能脉冲数Ary15(8Byte)                  
                            l = toolFunc.sliceBytes2Array(recData, 13, 8);
                            UInt64 ul = toolFunc.byte8toUINT64(l);
                            //textBox12.Text = ul.ToString();
                            //交流走字电能脉冲数Ary15(8Byte)                  
                            l = toolFunc.sliceBytes2Array(recData, 21, 8);
                            ul = toolFunc.byte8toUINT64(l);
                            textBox17.Text = ul.ToString();

                            read3 = true;
                        }
                        break;
                }
                if (read1 && read2 && read3)
                {
                    timer.Stop();
                    button1.Text = "完成";
                    resultlabel.Text = "测试数据采集完成";
                    button1.Enabled = true;                    
                }
                if (count == 100)
                {
                    timer.Stop();
                }
            }
        }

        private void Star_Click()
        {
            timer.Start();
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
            if (button1.Text == "启动")
            {
                byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szStart.Trim()));
                if (recData.Length < 1)
                {
                    //MessageBox.Show("szStart未读取到数据");
                    resultlabel.Text = "szStart未读取到数据";
                    return;
                }
                if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
                {
                    //MessageBox.Show("szStart设备测试指令异常");
                    resultlabel.Text = "szStart设备测试指令异常";
                    return;
                }
                Star_Click();
                button1.Enabled = false;
            }
            else if (button1.Text == "完成")
            {
                //1、上位机发“写计量模块第2页，交流走字控制Ary12=0x02 停止”命令
                byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.szStop.Trim()));
                if (recData.Length < 1)
                {
                    resultlabel.Text = "szStop未读取到数据";
                    return;
                }
                if (!toolFunc.sliceBytes2Array(recData, 0, 8).SequenceEqual(toolFunc.HexStringToByteArray(jlmk.szReply.Trim())))
                {
                    resultlabel.Text = "szStop设备测试指令异常";
                    return;
                }
                //2、计算测量结果：标准电能值*率单价=标准付费金额，|标准付费金额-付费金额示值|=付费误差，[(电能示值－标准电能)／标准电能]*100% =示值误差。
                if (shizhidiff&&fufeidiff)
                {
                    op.updateTestResult(16, "pass");
                    resultlabel.Text = "状态:测试通过";
                }
                else
                {
                    op.updateTestResult(16, "fail");
                    resultlabel.Text = "状态:测试不通过";
                }
            }
        }

        private void ShiZhiWCUCtrl_ControlRemoved(object sender, ControlEventArgs e)
        {
            timer.Stop();
        }


    }
}
