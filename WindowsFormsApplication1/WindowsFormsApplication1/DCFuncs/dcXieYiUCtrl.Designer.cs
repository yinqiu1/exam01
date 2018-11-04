namespace WindowsFormsApplication1.DCFuncs
{
    partial class dcXieYiUCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fullemptycbx = new System.Windows.Forms.CheckBox();
            this.selectAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSupport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15F);
            this.button2.Location = new System.Drawing.Point(244, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 44);
            this.button2.TabIndex = 36;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(81, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 37;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 19F);
            this.label18.Location = new System.Drawing.Point(144, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(194, 26);
            this.label18.TabIndex = 33;
            this.label18.Text = "协议一致性试验";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectAll,
            this.name,
            this.spn,
            this.description,
            this.isSupport});
            this.dataGridView1.Location = new System.Drawing.Point(3, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(494, 397);
            this.dataGridView1.TabIndex = 38;
            // 
            // fullemptycbx
            // 
            this.fullemptycbx.AutoSize = true;
            this.fullemptycbx.Location = new System.Drawing.Point(44, 33);
            this.fullemptycbx.Name = "fullemptycbx";
            this.fullemptycbx.Size = new System.Drawing.Size(15, 14);
            this.fullemptycbx.TabIndex = 39;
            this.fullemptycbx.UseVisualStyleBackColor = true;
            this.fullemptycbx.CheckedChanged += new System.EventHandler(this.fullemptycbx_CheckedChanged);
            // 
            // selectAll
            // 
            this.selectAll.HeaderText = "全选";
            this.selectAll.Name = "selectAll";
            this.selectAll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectAll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectAll.Width = 55;
            // 
            // name
            // 
            this.name.HeaderText = "报文名称";
            this.name.Name = "name";
            // 
            // spn
            // 
            this.spn.HeaderText = "SPN";
            this.spn.Name = "spn";
            // 
            // description
            // 
            this.description.HeaderText = "描述";
            this.description.Name = "description";
            // 
            // isSupport
            // 
            this.isSupport.HeaderText = "是否支持";
            this.isSupport.Name = "isSupport";
            // 
            // dcXieYiUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fullemptycbx);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label18);
            this.Name = "dcXieYiUCtrl";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.dcXieYiUCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox fullemptycbx;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn spn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSupport;
    }
}
