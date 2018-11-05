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

namespace WindowsFormsApplication1.DCFuncs
{
    public partial class dcWenYaUCtrl : UserControl
    {
        public dcWenYaUCtrl()
        {
            InitializeComponent();
            step = 0;
        }
        #region 变量定义、委托定义
        private SerialPort com;
        DbOps op = new DbOps();
        private static int step = 0;
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
        private void button1_Click(object sender, EventArgs e)
        {

        }
        /*
         步骤1：断开负载，启动桩和BMS，待充电机输出电压达到设定值后，手动接入50%额定负载，点击“测试按钮”，测量出半载对应的数据，然后断开负载，点“下一步”。
步骤2：负载断开情况下，点击“测试”，测量出测试点1(空载)对应的数据，然后点“下一步”。
步骤3：手动接入20%额定负载后，点击“测试”，测量出测试点2对应的数据，然后断开负载，点“下一步”。
步骤4：手动接入满载负载后，点击“测试”，测量出测试点3对应的数据，然后断开负载，点“下一步”，完成测试。
         */
        private void button2_Click(object sender, EventArgs e)
        {
            if (step < 4)
            {
                step++;
                switch (step)
                {
                    case 0:
                        richTextBox1.Text = "步骤1：断开负载，启动桩和BMS，待充电机输出电压达到设定值后，手动接入50%额定负载，点击“测试按钮”，测量出半载对应的数据，然后断开负载，点“下一步”。";
                        break;
                    case 1:
                        richTextBox1.Text = "步骤2：负载断开情况下，点击“测试”，测量出测试点1(空载)对应的数据，然后点“下一步”。";
                        break;
                    case 2:                        
                        richTextBox1.Text = "步骤3：手动接入20%额定负载后，点击“测试”，测量出测试点2对应的数据，然后断开负载，点“下一步”。";
                        break;
                    case 3:
                        button2.Text = "返回";
                        richTextBox1.Text = "步骤4：手动接入满载负载后，点击“测试”，测量出测试点3对应的数据，然后断开负载，点“下一步”，完成测试。";
                        break;
                }
            }

            if (step == 4)
            {
                // 触发事件， 传递自定义参数
                OnDataChange(this, new DataChangeEventArgs("", ""));
                this.Dispose();
            }            
        }
    }
}
