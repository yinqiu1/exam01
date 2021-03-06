﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;

namespace WindowsFormsApplication1.Funcs
{
    public partial class UsualCheckUCtrl : UserControl
    {
        public UsualCheckUCtrl()
        {
            InitializeComponent();
        }
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
        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存一般检测结果
            if(Pass.Checked)
            {
                op.updateTestResult(1,"pass");
            }
            else if(Fail.Checked)
            {
                op.updateTestResult(1, "fail");
            }
            else
            {
                MessageBox.Show("请选择测试结果！");
            }
            //用户输入存入数据库
            if (usrRtbx.Text != "")
            {

            }
        }
    }
}
