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
    public partial class SelectDiag : Form
    {
        public SelectDiag()
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
            this.dataGridView1.Columns[0].DataPropertyName = "ischecked";
            this.dataGridView1.Columns[1].DataPropertyName = "sortid";
            this.dataGridView1.Columns[2].DataPropertyName = "testname";

            /*checkbox属性*/
            DataGridViewCheckBoxColumn checkbox = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkbox.TrueValue = "1";
            checkbox.FalseValue = "0";            

            /*获取数据源*/
            
            //String pwd = op.getPwdbyUname(usrnameTbx.Text);
            //DataSet ds = SqliteSingleModel.Instance.ReadMethod("select [Id],[TestType],[Name],[TestDynamic],[TestSynch],[Description] from config_testtype order by TestType");

            DataTable dt = op.getItemView();

            /*binding 数据源*/
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["checkbox"];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    int chk = flag ? 1 : 0;
                    DataGridViewTextBoxCell idCell = (DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells["id"];
                    int id = Convert.ToInt32(idCell.Value);
                    op.updatecheckedbyid(chk,id);
                }
            }

        }

    }
}
