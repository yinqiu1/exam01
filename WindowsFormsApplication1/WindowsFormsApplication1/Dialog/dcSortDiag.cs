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
    public partial class dcSortDiag : Form
    {
        public dcSortDiag()
        {
            InitializeComponent();
            initsorid();
        }
        #region 定义委托
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

        DbOps op = new DbOps();

        private void initsorid()
        {
            DataTable dt = op.dcgetsortidlist();
            if (dt.Rows.Count < 32)
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
            textBox18.Text = dt.Rows[17]["sortid"].ToString();
            textBox19.Text = dt.Rows[18]["sortid"].ToString();
            textBox20.Text = dt.Rows[19]["sortid"].ToString();
            textBox21.Text = dt.Rows[20]["sortid"].ToString();
            textBox22.Text = dt.Rows[21]["sortid"].ToString();
            textBox23.Text = dt.Rows[22]["sortid"].ToString();
            textBox24.Text = dt.Rows[23]["sortid"].ToString();
            textBox25.Text = dt.Rows[24]["sortid"].ToString();
            textBox26.Text = dt.Rows[25]["sortid"].ToString();
            textBox27.Text = dt.Rows[26]["sortid"].ToString();
            textBox28.Text = dt.Rows[27]["sortid"].ToString();
            textBox29.Text = dt.Rows[28]["sortid"].ToString();
            textBox30.Text = dt.Rows[29]["sortid"].ToString();
            textBox31.Text = dt.Rows[30]["sortid"].ToString();
            textBox32.Text = dt.Rows[31]["sortid"].ToString();
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
            //新增textbox
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
            if (textBox18.Text == "" || Convert.ToInt32(textBox18.Text) < 1)
            {
                MessageBox.Show("第18个项目输入空");
                return;
            }
            if (textBox19.Text == "" || Convert.ToInt32(textBox19.Text) < 1)
            {
                MessageBox.Show("第19个项目输入空");
                return;
            }
            if (textBox20.Text == "" || Convert.ToInt32(textBox20.Text) < 1)
            {
                MessageBox.Show("第20个项目输入空");
                return;
            }
            if (textBox21.Text == "" || Convert.ToInt32(textBox21.Text) < 1)
            {
                MessageBox.Show("第21个项目输入空");
                return;
            }
            if (textBox22.Text == "" || Convert.ToInt32(textBox22.Text) < 1)
            {
                MessageBox.Show("第22个项目输入空");
                return;
            }
            if (textBox23.Text == "" || Convert.ToInt32(textBox23.Text) < 1)
            {
                MessageBox.Show("第23个项目输入空");
                return;
            }
            if (textBox24.Text == "" || Convert.ToInt32(textBox24.Text) < 1)
            {
                MessageBox.Show("第24个项目输入空");
                return;
            }
            if (textBox25.Text == "" || Convert.ToInt32(textBox25.Text) < 1)
            {
                MessageBox.Show("第25个项目输入空");
                return;
            }
            if (textBox26.Text == "" || Convert.ToInt32(textBox26.Text) < 1)
            {
                MessageBox.Show("第26个项目输入空");
                return;
            }
            if (textBox27.Text == "" || Convert.ToInt32(textBox27.Text) < 1)
            {
                MessageBox.Show("第27个项目输入空");
                return;
            }
            if (textBox28.Text == "" || Convert.ToInt32(textBox28.Text) < 1)
            {
                MessageBox.Show("第28个项目输入空");
                return;
            }
            if (textBox29.Text == "" || Convert.ToInt32(textBox29.Text) < 1)
            {
                MessageBox.Show("第29个项目输入空");
                return;
            }
            if (textBox30.Text == "" || Convert.ToInt32(textBox30.Text) < 1)
            {
                MessageBox.Show("第30个项目输入空");
                return;
            }
            if (textBox31.Text == "" || Convert.ToInt32(textBox31.Text) < 1)
            {
                MessageBox.Show("第31个项目输入空");
                return;
            }
            if (textBox32.Text == "" || Convert.ToInt32(textBox32.Text) < 1)
            {
                MessageBox.Show("第32个项目输入空");
                return;
            }           

            int[] sortarray = new int[32];
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
            sortarray[17] = Convert.ToInt32(textBox18.Text);
            sortarray[18] = Convert.ToInt32(textBox19.Text);
            sortarray[19] = Convert.ToInt32(textBox20.Text);
            sortarray[20] = Convert.ToInt32(textBox21.Text);
            sortarray[21] = Convert.ToInt32(textBox22.Text);
            sortarray[22] = Convert.ToInt32(textBox23.Text);
            sortarray[23] = Convert.ToInt32(textBox24.Text);
            sortarray[24] = Convert.ToInt32(textBox25.Text);
            sortarray[25] = Convert.ToInt32(textBox26.Text);
            sortarray[26] = Convert.ToInt32(textBox27.Text);
            sortarray[27] = Convert.ToInt32(textBox28.Text);
            sortarray[28] = Convert.ToInt32(textBox29.Text);
            sortarray[29] = Convert.ToInt32(textBox30.Text);
            sortarray[30] = Convert.ToInt32(textBox31.Text);
            sortarray[31] = Convert.ToInt32(textBox32.Text);

            for (int i = 0; i < 32; i++)
            {
                if (sortarray[i] > 32)
                {
                    MessageBox.Show("不能给定大于总数的序号!");
                    return;
                }
                for (int j = i + 1; j < 32; j++)
                {
                    if (sortarray[i] == sortarray[j])
                    {
                        MessageBox.Show("不能有相同的序号!");
                        return;
                    }
                }

            }

            op.dcupdatesortids(1, Convert.ToInt32(textBox1.Text));
            op.dcupdatesortids(2, Convert.ToInt32(textBox2.Text));
            op.dcupdatesortids(3, Convert.ToInt32(textBox3.Text));
            op.dcupdatesortids(4, Convert.ToInt32(textBox4.Text));
            op.dcupdatesortids(5, Convert.ToInt32(textBox5.Text));
            op.dcupdatesortids(6, Convert.ToInt32(textBox6.Text));
            op.dcupdatesortids(7, Convert.ToInt32(textBox7.Text));
            op.dcupdatesortids(8, Convert.ToInt32(textBox8.Text));
            op.dcupdatesortids(9, Convert.ToInt32(textBox9.Text));
            op.dcupdatesortids(10, Convert.ToInt32(textBox10.Text));
            op.dcupdatesortids(11, Convert.ToInt32(textBox11.Text));
            op.dcupdatesortids(12, Convert.ToInt32(textBox12.Text));
            op.dcupdatesortids(13, Convert.ToInt32(textBox13.Text));
            op.dcupdatesortids(14, Convert.ToInt32(textBox14.Text));
            op.dcupdatesortids(15, Convert.ToInt32(textBox15.Text));

            op.dcupdatesortids(16, Convert.ToInt32(textBox16.Text));
            op.dcupdatesortids(17, Convert.ToInt32(textBox17.Text));
            op.dcupdatesortids(18, Convert.ToInt32(textBox18.Text));
            op.dcupdatesortids(19, Convert.ToInt32(textBox19.Text));
            op.dcupdatesortids(20, Convert.ToInt32(textBox20.Text));
            op.dcupdatesortids(21, Convert.ToInt32(textBox21.Text));
            op.dcupdatesortids(22, Convert.ToInt32(textBox22.Text));
            op.dcupdatesortids(23, Convert.ToInt32(textBox23.Text));
            op.dcupdatesortids(24, Convert.ToInt32(textBox24.Text));
            op.dcupdatesortids(25, Convert.ToInt32(textBox25.Text));
            op.dcupdatesortids(26, Convert.ToInt32(textBox26.Text));
            op.dcupdatesortids(27, Convert.ToInt32(textBox27.Text));
            op.dcupdatesortids(28, Convert.ToInt32(textBox28.Text));
            op.dcupdatesortids(29, Convert.ToInt32(textBox29.Text));
            op.dcupdatesortids(30, Convert.ToInt32(textBox30.Text));
            op.dcupdatesortids(31, Convert.ToInt32(textBox31.Text));
            op.dcupdatesortids(32, Convert.ToInt32(textBox32.Text));

            //MessageBox.Show("更新完成");
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Close();
        }
    }
}
