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
    public partial class GuoLiuUCtrl : UserControl
    {
        public GuoLiuUCtrl(SerialPort c)
        {
            InitializeComponent();
            com = c;
        }
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
        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //程序判断，点测试按钮后，读计量模块测量的交流电压，小于10V视为合格，否则不合格            
            byte[] recData = toolFunc.ReadPort(com, toolFunc.HexStringToByteArray(jlmk.readjldy.Trim()));
            if (recData.Length < 1)
            {
                MessageBox.Show("未读取到数据");
                return;
            }
            byte[] l = toolFunc.sliceBytes2Array(recData, 9, 4);

            float r = toolFunc.byte4tofloat(l);
            textBox1.Text = r.ToString();

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
        }
    }
}
