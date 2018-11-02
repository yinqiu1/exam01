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
    public partial class JieDianUCtrl : UserControl
    {
        public JieDianUCtrl(SerialPort c)
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
            MsgBoxRel = MessageBox.Show("警告：请确认设备是否断电！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (MsgBoxRel == DialogResult.OK)
            {
                resuallbl.Text = "开始测试...";
                byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset01.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev01.Trim())))
                {
                    MessageBox.Show("设备指令异常1");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset02.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev02.Trim())))
                {
                    MessageBox.Show("设备指令异常2");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset03.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev03.Trim())))
                {
                    MessageBox.Show("设备指令异常3");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset04.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev04.Trim())))
                {
                    MessageBox.Show("设备指令异常4");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset05.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev05.Trim())))
                {
                    MessageBox.Show("设备指令异常5");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset06.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev06.Trim())))
                {
                    MessageBox.Show("设备指令异常6");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset08.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev08.Trim())))
                {
                    MessageBox.Show("设备指令异常8");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset09.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev09.Trim())))
                {
                    MessageBox.Show("设备指令异常9");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset10.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev10.Trim())))
                {
                    MessageBox.Show("设备指令异常10");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.acset11.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.acsetrev11.Trim())))
                {
                    MessageBox.Show("设备指令异常11");
                    return;
                }
                //测试指令
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.actest01.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.actestrev01.Trim())))
                {
                    MessageBox.Show("设备测试指令异常1");
                    return;
                }

                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.actest02.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.actestrev02.Trim())))
                {
                    MessageBox.Show("设备测试指令异常2");
                    return;
                }
                //获取结果
                Thread.Sleep(60000);
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.actest03.Trim()));
                /*
                string value="40100000";//16进制字符串
                UInt32 x = Convert.ToUInt32(ydl, 16);//字符串转16进制32位无符号整数
                float fy = BitConverter.ToSingle(BitConverter.GetBytes(x), 0);//IEEE754 字节转换float
                */
                int l = toolFunc.slice4BytesArray(recData, 6, 4);
                textBox2.Text = l.ToString();
                int n = toolFunc.slice4BytesArray(recData, 10, 4);
                textBox3.Text = n.ToString();

                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.actest05.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.actestrev05.Trim())))
                {
                    MessageBox.Show("设备测试指令异常5");
                    return;
                }
                recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(ainuoangui.actest06.Trim()));
                if (!recData.SequenceEqual(toolFunc.HexStringToByteArray(ainuoangui.actestrev06.Trim())))
                {
                    MessageBox.Show("设备测试指令异常6");
                    return;
                }
                //测试完成之后将结果写入数据库

                if (l > 10 || n > 10)
                {
                    op.updateTestResult(4, "pass");
                    resultlabel.Text = "状态:测试通过";
                }
                else
                {
                    op.updateTestResult(4, "fail");
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

    }
}
