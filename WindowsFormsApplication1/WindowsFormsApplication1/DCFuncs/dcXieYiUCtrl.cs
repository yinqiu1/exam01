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
    public partial class dcXieYiUCtrl : UserControl
    {
        public dcXieYiUCtrl()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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

        public void UpdateDataGrid()
        {
            //if (this.dataGridView1.Rows.Count>0)
            //{
            //    this.dataGridView1.Rows.Clear();
            //}            
            /*禁止自动创建Column*/
            this.dataGridView1.AutoGenerateColumns = false;
            /*设置binding 属性值*/
            this.dataGridView1.Columns[0].DataPropertyName = "isChecked";
            this.dataGridView1.Columns[1].DataPropertyName = "pname";
            this.dataGridView1.Columns[2].DataPropertyName = "spn";
            this.dataGridView1.Columns[3].DataPropertyName = "description";
            this.dataGridView1.Columns[4].DataPropertyName = "isSupport";

            /*checkbox属性*/
            DataGridViewCheckBoxColumn checkbox = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkbox.TrueValue = "1";
            checkbox.FalseValue = "0";

            /*获取数据源*/
            DataTable dt = op.XYgetItemView();

            /*binding 数据源*/
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }
        private void dcXieYiUCtrl_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs("", ""));
            this.Dispose();	   
	   
        }

        private void fullemptycbx_CheckedChanged(object sender, EventArgs e)
        {
            if (fullemptycbx.Checked)
            {
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == false)
                    {
                        checkCell.Value = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        checkCell.Value = false;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }

        
    }
}
