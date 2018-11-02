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
    public partial class dcJueYuanUCtrl : UserControl
    {
        public dcJueYuanUCtrl()
        {
            InitializeComponent();
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
            DialogResult MsgBoxRel;
            MsgBoxRel = MessageBox.Show("请确认设备是否断电！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (MsgBoxRel == DialogResult.OK)
            {
                resuallbl.Text = "开始测试...";
            }
            else if (MsgBoxRel == DialogResult.Cancel)
            {

            }
        }
    }
}
