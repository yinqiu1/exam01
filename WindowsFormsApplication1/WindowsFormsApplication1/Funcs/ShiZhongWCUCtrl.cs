using System;
using System.Windows;
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
    public partial class ShiZhongWCUCtrl : UserControl
    {
        public ShiZhongWCUCtrl(SerialPort c)
        {
            InitializeComponent();
            com = c;
            #region 北京时间定时器相关
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            count = 0;
            timer.Elapsed += (x, y) =>
            {
                count++;
                InvokeMethod(count);
            };
            #endregion
            #region GPS时间定时器相关
            timer1 = new System.Timers.Timer();
            timer1.Interval = 300;
            count1 = 0;
            timer1.Elapsed += (x, y) =>
            {
                count1++;
                InvokeMethod(count1);
            };
            #endregion          
        }
        private void ShiZhongWCUCtrl_Load(object sender, EventArgs e)
        {
            //byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.clockRgps.Trim()));

            byte[] array = toolFunc.HexStringToByteArray(Com.jlmk.clockRgps.Trim());
            com.Write(array, 0, array.Length);

            timer.Start();
            timer1.Start();
            //Thread t = new Thread(new ThreadStart(GetData));
            //t.IsBackground = true;
            //t.Start();       
            //timer1 = new System.Threading.Timer(new System.Threading.TimerCallback(timer_Elapsed), this, 0, 300);

            _keepReading = true;
            _ThreadStopFlg = true; 
            _readThread = new Thread(ReadPort);
            _readThread.Start();
        }
        private void ReadPort()
        {
            while (_keepReading && _ThreadStopFlg)
            {
                if (com.IsOpen)
                {
                    byte[] readBuffer = new byte[com.ReadBufferSize + 1];
                    try
                    {
                        lock (locko)
                        {
                            // If there are bytes available on the serial port,   
                            // Read returns up to "count" bytes, but will not block (wait)   
                            // for the remaining bytes. If there are no bytes available   
                            // on the serial port, Read will block until at least one byte   
                            // is available on the port, up until the ReadTimeout milliseconds   
                            // have elapsed, at which time a TimeoutException will be thrown.   
                            Thread.Sleep(50);
                            int count = com.Read(readBuffer, 0, com.BytesToRead);
                            //String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
                            if (count > 0)
                            {
                                //byteToHexStr(readBuffer);   
                                //Thread(byteToHexStr(readBuffer, count));
                                //byte[] buf = new byte[count]; 
                                //1.缓存数据
                                buffer.AddRange(readBuffer);
                                //2.完整性判断
                                while (buffer.Count >= 4 && _ThreadStopFlg) //至少包含帧头（2字节）、长度（1字节）、校验位（1字节）；根据设计不同而不同
                                {
                                    //2.1 查找数据头
                                    if (buffer[0] == 0x81) //传输数据有帧头，用于判断
                                    {
                                        int len = buffer[3];
                                        if (buffer.Count < len||len<1) //数据区尚未接收完整
                                        {
                                            break;
                                        }
                                        //得到完整的数据，复制到ReceiveBytes中进行校验
                                        byte[] ReceiveBytes = new byte[len];
                                        byte[] RecJY = new byte[len - 1];
                                        buffer.CopyTo(0, ReceiveBytes, 0, len);
                                        buffer.CopyTo(0, RecJY, 0, len - 1);
                                        byte jiaoyan; //开始校验
                                        jiaoyan = Com.toolFunc.Get_CheckXor(RecJY);
                                        if (jiaoyan != ReceiveBytes[len - 1]) //校验失败，最后一个字节是校验位
                                        {
                                            buffer.RemoveRange(0, len);
                                            //MessageBox.Show("数据包不正确！");
                                            continue;
                                        }
                                        buffer.RemoveRange(0, len);
                                        /////执行其他代码，对数据进行处理。
                                        GetData4SZ(ReceiveBytes);
                                    }
                                    else //帧头不正确时，记得清除
                                    {
                                        buffer.RemoveAt(0);
                                    }
                                }
                            }
                        }
                    }
                    catch (TimeoutException) { }
                }
                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }
        }
        private void GetData4SZ(byte[] data)
        { 
            //将cmd指令取出
            byte[] cmd = toolFunc.sliceBytes2Array(data, 0, 10);
            if (cmd.SequenceEqual(toolFunc.HexStringToByteArray(Com.jlmk.clockRgpsRPCMD)))
            {
                //1、进入该测试界面后，上位机发“读GPS信号强度Ary31、读GPS数据有效性Ary32”
                int l_int = toolFunc.slice1Byte(data, 10, 1);
                textBox11.Text = l_int.ToString();//信号强度
                string yxx = toolFunc.bytes2asciiS(data, 12, 1);//GPS数据有效性Ary32
                switch (yxx)
                {
                    case "A":
                        textBox12.Text = "显示有效";
                        break;
                    case "V":
                        textBox12.Text = "显示无效";
                        break;
                    case "N":
                        textBox12.Text = "未连接";
                        break;
                    default:
                        textBox12.Text = "数据无效";
                        break;
                }
            }
            cmd = toolFunc.sliceBytes2Array(data, 0, 9);
            if (cmd.SequenceEqual(toolFunc.HexStringToByteArray(Com.jlmk.clockRgpstRPCMD)))
            {
                textBox5.Text = toolFunc.bytes2asciiS(data, 9, 4);//年
                textBox6.Text = toolFunc.bytes2asciiS(data, 13, 2);//月
                textBox7.Text = toolFunc.bytes2asciiS(data, 15, 2);//日
                textBox8.Text = toolFunc.bytes2asciiS(data, 17, 2);//时
                textBox9.Text = toolFunc.bytes2asciiS(data, 19, 2);//分
                textBox10.Text = toolFunc.bytes2asciiS(data, 21, 2);//秒
                //计算时间误差，ΔT =  |充电机显示时间-标准时间|
                int chargeT = int.Parse(textBox1.Text) * 3600 + int.Parse(textBox2.Text) * 60 + int.Parse(textBox3.Text);
                int standardT = int.Parse(textBox8.Text) * 3600 + int.Parse(textBox9.Text) * 60 + int.Parse(textBox10.Text);
                int diff = Math.Abs(chargeT - standardT);
                textBox13.Text = diff.ToString();
            }
        }

        private static object locko = new object();
        private Thread _readThread;
        private bool _keepReading = false;
        private bool _ThreadStopFlg = false; 
        private List<byte> buffer = new List<byte>(4096);
         

        #region 变量定义、委托定义
        private SerialPort com;
        DbOps op = new DbOps();

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

        #region 定时器 更新北京时间
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
                textBox1.Text = DateTime.Now.Hour.ToString();
                textBox2.Text = DateTime.Now.Minute.ToString();
                textBox3.Text = DateTime.Now.Second.ToString();
                if (count == 1000)
                {
                    timer.Stop();
                }
            }
        }
        #endregion
        #region 定时器 更新GPS时间
        private int count1 = 0;
        System.Timers.Timer timer1;
        private void InvokeMethod1(int count)
        {
            Action<int> invokeAction = new Action<int>(InvokeMethod1);
            if (this.InvokeRequired)
            {
                this.Invoke(invokeAction, count);
            }
            else
            {
                //2、上位机间隔300ms循环发送“计量模块读GPS时间”命令，然后将读到的日期时间进行显示
                //byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.clockRgpst.Trim()));
                byte[] array = toolFunc.HexStringToByteArray(Com.jlmk.clockRgpst.Trim());
                com.Write(array, 0, array.Length);
                if (count == 2000)
                {
                    timer1.Stop();
                }
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
            if (button1.Text == "测试")
            {
                timer.Stop();
                timer1.Stop();
                _ThreadStopFlg = false; 
                button1.Text = "完成";
            }
            else if (button1.Text == "完成")
            {
                //计算时间误差，ΔT =  |充电机显示时间-标准时间|
                int chargeT = int.Parse(textBox1.Text) * 3600 + int.Parse(textBox2.Text) * 60 + int.Parse(textBox3.Text);
                int standardT = int.Parse(textBox8.Text) * 3600 + int.Parse(textBox9.Text) * 60 + int.Parse(textBox10.Text);
                int diff = Math.Abs(chargeT - standardT);
                textBox13.Text = diff.ToString();

                if (diff < int.Parse(textBox4.Text))
                {
                    op.updateTestResult(17, "pass");
                    resultlabel.Text = "状态:测试通过";
                }
                else
                {
                    op.updateTestResult(17, "fail");
                    resultlabel.Text = "状态:测试不通过";
                }
                button1.Enabled = false;
            }
        }

        
    }
}
