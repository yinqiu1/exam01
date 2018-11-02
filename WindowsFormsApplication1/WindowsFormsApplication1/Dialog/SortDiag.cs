using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;

namespace WindowsFormsApplication1.Dialog
{
    public partial class SortDiag : Form
    {
        public SortDiag()
        {
            InitializeComponent();
            initsorid();
        }
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

        DbOps op = new DbOps();

        private void initsorid()
        {
            DataTable dt = op.getsortidlist();
            if (dt.Rows.Count < 15)
                return;
            textBox1.Text = dt.Rows[0]["sortid"].ToString();
            textBox2.Text = dt.Rows[1]["sortid"].ToString();
            textBox3.Text = dt.Rows[2]["sortid"].ToString();
            textBox4.Text = dt.Rows[3]["sortid"].ToString();
            textBox5.Text = dt.Rows[4]["sortid"].ToString();
            textBox6.Text = dt.Rows[5]["sortid"].ToString();
            textBox7.Text = dt.Rows[6]["sortid"].ToString();
            textBox8.Text = dt.Rows[7]["sortid"].ToString();
            textBox9.Text = dt.Rows[8]["sortid"].ToString();
            textBox10.Text = dt.Rows[9]["sortid"].ToString();
            textBox11.Text = dt.Rows[10]["sortid"].ToString();
            textBox12.Text = dt.Rows[11]["sortid"].ToString();
            textBox13.Text = dt.Rows[12]["sortid"].ToString();
            textBox14.Text = dt.Rows[13]["sortid"].ToString();
            textBox15.Text = dt.Rows[14]["sortid"].ToString();
            textBox16.Text = dt.Rows[15]["sortid"].ToString();
            textBox17.Text = dt.Rows[16]["sortid"].ToString();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || Convert.ToInt32(textBox1.Text) < 1)
            {
                MessageBox.Show("第1个项目输入空");
                return;
            }
            if (textBox2.Text == "" || Convert.ToInt32(textBox2.Text) < 1)
            {
                MessageBox.Show("第2个项目输入空");
                return;
            }
            if (textBox3.Text == "" || Convert.ToInt32(textBox3.Text) < 1)
            {
                MessageBox.Show("第3个项目输入空");
                return;
            }
            if (textBox4.Text == "" || Convert.ToInt32(textBox4.Text) < 1)
            {
                MessageBox.Show("第4个项目输入空");
                return;
            }
            if (textBox5.Text == "" || Convert.ToInt32(textBox5.Text) < 1)
            {
                MessageBox.Show("第5个项目输入空");
                return;
            }
            if (textBox6.Text == "" || Convert.ToInt32(textBox6.Text) < 1)
            {
                MessageBox.Show("第6个项目输入空");
                return;
            }
            if (textBox7.Text == "" || Convert.ToInt32(textBox7.Text) < 1)
            {
                MessageBox.Show("第7个项目输入空");
                return;
            }
            if (textBox8.Text == "" || Convert.ToInt32(textBox8.Text) < 1)
            {
                MessageBox.Show("第8个项目输入空");
                return;
            }
            if (textBox9.Text == "" || Convert.ToInt32(textBox9.Text) < 1)
            {
                MessageBox.Show("第9个项目输入空");
                return;
            }
            if (textBox10.Text == "" || Convert.ToInt32(textBox10.Text) < 1)
            {
                MessageBox.Show("第10个项目输入空");
                return;
            }
            if (textBox11.Text == "" || Convert.ToInt32(textBox11.Text) < 1)
            {
                MessageBox.Show("第11个项目输入空");
                return;
            }
            if (textBox12.Text == "" || Convert.ToInt32(textBox12.Text) < 1)
            {
                MessageBox.Show("第12个项目输入空");
                return;
            }
            if (textBox13.Text == "" || Convert.ToInt32(textBox13.Text) < 1)
            {
                MessageBox.Show("第13个项目输入空");
                return;
            }
            if (textBox14.Text == "" || Convert.ToInt32(textBox14.Text) < 1)
            {
                MessageBox.Show("第14个项目输入空");
                return;
            }
            if (textBox15.Text == "" || Convert.ToInt32(textBox15.Text) < 1)
            {
                MessageBox.Show("第15个项目输入空");
                return;
            }
            if (textBox16.Text == "" || Convert.ToInt32(textBox16.Text) < 1)
            {
                MessageBox.Show("第16个项目输入空");
                return;
            }
            if (textBox17.Text == "" || Convert.ToInt32(textBox17.Text) < 1)
            {
                MessageBox.Show("第17个项目输入空");
                return;
            }
            int[] sortarray = new int[17];
            sortarray[0] = Convert.ToInt32(textBox1.Text);
            sortarray[1] = Convert.ToInt32(textBox2.Text);
            sortarray[2] = Convert.ToInt32(textBox3.Text);
            sortarray[3] = Convert.ToInt32(textBox4.Text);
            sortarray[4] = Convert.ToInt32(textBox5.Text);
            sortarray[5] = Convert.ToInt32(textBox6.Text);
            sortarray[6] = Convert.ToInt32(textBox7.Text);
            sortarray[7] = Convert.ToInt32(textBox8.Text);
            sortarray[8] = Convert.ToInt32(textBox9.Text);
            sortarray[9] = Convert.ToInt32(textBox10.Text);
            sortarray[10] = Convert.ToInt32(textBox11.Text);
            sortarray[11] = Convert.ToInt32(textBox12.Text);
            sortarray[12] = Convert.ToInt32(textBox13.Text);
            sortarray[13] = Convert.ToInt32(textBox14.Text);
            sortarray[14] = Convert.ToInt32(textBox15.Text);
            sortarray[15] = Convert.ToInt32(textBox16.Text);
            sortarray[16] = Convert.ToInt32(textBox17.Text);

            for (int i = 0; i < 17; i++)
            {
                if (sortarray[i]>17)
                {
                    MessageBox.Show("不能给定大于总数的序号!");
                    return;
                }
                for(int j=i+1;j<17;j++)
                {
                    if (sortarray[i] == sortarray[j])
                    {
                        MessageBox.Show("不能有相同的序号!");
                        return;
                    }
                }
                
            }

            op.updatesortids(1, Convert.ToInt32(textBox1.Text));
            op.updatesortids(2, Convert.ToInt32(textBox2.Text));
            op.updatesortids(3, Convert.ToInt32(textBox3.Text));
            op.updatesortids(4, Convert.ToInt32(textBox4.Text));
            op.updatesortids(5, Convert.ToInt32(textBox5.Text));
            op.updatesortids(6, Convert.ToInt32(textBox6.Text));
            op.updatesortids(7, Convert.ToInt32(textBox7.Text));
            op.updatesortids(8, Convert.ToInt32(textBox8.Text));
            op.updatesortids(9, Convert.ToInt32(textBox9.Text));
            op.updatesortids(10, Convert.ToInt32(textBox10.Text));
            op.updatesortids(11, Convert.ToInt32(textBox11.Text));
            op.updatesortids(12, Convert.ToInt32(textBox12.Text));
            op.updatesortids(13, Convert.ToInt32(textBox13.Text));
            op.updatesortids(14, Convert.ToInt32(textBox14.Text));
            op.updatesortids(15, Convert.ToInt32(textBox15.Text));
            op.updatesortids(16, Convert.ToInt32(textBox16.Text));
            op.updatesortids(17, Convert.ToInt32(textBox17.Text));
            //MessageBox.Show("更新完成");
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Close();
        }
    }
}
