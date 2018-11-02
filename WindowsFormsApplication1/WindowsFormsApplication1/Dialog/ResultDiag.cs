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
    public partial class ResultDiag : Form
    {
        public ResultDiag()
        {
            InitializeComponent();
            InitView();
        }
        DbOps op = new DbOps();
        public void InitView()
        {
            /*禁止自动创建Column*/
            this.dataGridView1.AutoGenerateColumns = false;
            /*设置binding 属性值*/            
            this.dataGridView1.Columns[0].DataPropertyName = "id";
            this.dataGridView1.Columns[1].DataPropertyName = "testname";
            this.dataGridView1.Columns[2].DataPropertyName = "result";            

            /*获取数据源*/

            DataTable dt = op.getItemViewChecked();

            /*binding 数据源*/
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }
    }
}
