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
    public partial class JueYuanUCtrl : UserControl
    {
        public JueYuanUCtrl(SerialPort c)
        {
            InitializeComponent();
            com = c;
            //com.DataReceived += new SerialDataReceivedEventHandler(post_DataReceived);
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
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxRel;
            MsgBoxRel = MessageBox.Show("请确认设备是否断电！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (MsgBoxRel == DialogResult.OK)
            {
                resuallbl.Text = "开始测试...";
                //开始进行通讯操作
                //发送数据
                //if (com.IsOpen)
                //{
                //    //如果串口开启，按步骤发送数据
                //    byte[] array = Com.toolFunc.HexStringToByteArray(textBox_send.Text.Trim());
                //    com.Write(array, 0, array.Length);
                //    Thread.Sleep(10);
                //}
                //else
                //{
                //    MessageBox.Show("串口未打开");
                //}
                byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset01.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev01.Trim())))
                {
                    MessageBox.Show("设备指令异常1");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset02.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev02.Trim())))
                {
                    MessageBox.Show("设备指令异常2");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset03.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev03.Trim())))
                {
                    MessageBox.Show("设备指令异常3");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset04.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev04.Trim())))
                {
                    MessageBox.Show("设备指令异常4");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset05.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev05.Trim())))
                {
                    MessageBox.Show("设备指令异常5");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset07.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev07.Trim())))
                {
                    MessageBox.Show("设备指令异常7");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset08.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev08.Trim())))
                {
                    MessageBox.Show("设备指令异常8");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset09.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev09.Trim())))
                {
                    MessageBox.Show("设备指令异常9");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset10.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev10.Trim())))
                {
                    MessageBox.Show("设备指令异常10");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydzset11.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydzsetrev11.Trim())))
                {
                    MessageBox.Show("设备指令异常11");
                    return;
                }
                //测试指令
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydztest01.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydztestrev01.Trim())))
                {
                    MessageBox.Show("设备测试指令异常1");
                    return;
                }

                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydztest02.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydztestrev02.Trim())))
                {
                    MessageBox.Show("设备测试指令异常2");
                    return;
                }
                //获取结果
                Thread.Sleep(1200);
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydztest03.Trim()));
                /*
                string value="40100000";//16进制字符串
                UInt32 x = Convert.ToUInt32(ydl, 16);//字符串转16进制32位无符号整数
                float fy = BitConverter.ToSingle(BitConverter.GetBytes(x), 0);//IEEE754 字节转换float
                */
                int l = toolFunc.slice4BytesArray(recData, 6, 4);
                textBox2.Text = l.ToString();
                int n = toolFunc.slice4BytesArray(recData, 10, 4);
                textBox3.Text = n.ToString();

                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydztest05.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydztestrev05.Trim())))
                {
                    MessageBox.Show("设备测试指令异常5");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.jydztest06.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.jydztestrev06.Trim())))
                {
                    MessageBox.Show("设备测试指令异常6");
                    return;
                }
                //测试完成之后将结果写入数据库

                if (l > 10 || n > 10)
                {
                    op.updateTestResult(3, "pass");
                    resultlabel.Text = "状态:测试通过";
                }
                else
                {
                    op.updateTestResult(3, "fail");
                    resultlabel.Text = "状态:测试不通过";
                }                
                //日志写入，文档生成
            }
            else if (MsgBoxRel == DialogResult.Cancel)
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Dispose();
        }
        //private void post_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    byte data;            
        //    try
        //    {
        //        //循环接收数据
        //        while (com.BytesToRead > 0)
        //        {
        //            data = (byte)com.ReadByte();
        //            //currentline.Append(ch);
        //            string str = Convert.ToString(data, 16).ToUpper();//
        //            //textBox_receive.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + "  ");
        //            Thread.Sleep(50);
        //        }
        //        //在这里对接收到的数据进行处理     
        //        //GetData();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //    }
        // }
    }
}
