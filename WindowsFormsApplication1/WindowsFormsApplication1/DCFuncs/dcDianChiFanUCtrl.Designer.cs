namespace WindowsFormsApplication1.DCFuncs
{
    partial class dcDianChiFanUCtrl
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
            this.usrRtbx = new System.Windows.Forms.RichTextBox();
            this.Fail = new System.Windows.Forms.RadioButton();
            this.Pass = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usrRtbx
            // 
            this.usrRtbx.Location = new System.Drawing.Point(72, 269);
            this.usrRtbx.Name = "usrRtbx";
            this.usrRtbx.Size = new System.Drawing.Size(358, 93);
            this.usrRtbx.TabIndex = 47;
            this.usrRtbx.Text = "";
            // 
            // Fail
            // 
            this.Fail.AutoSize = true;
            this.Fail.Location = new System.Drawing.Point(125, 402);
            this.Fail.Name = "Fail";
            this.Fail.Size = new System.Drawing.Size(47, 16);
            this.Fail.TabIndex = 45;
            this.Fail.TabStop = true;
            this.Fail.Text = "Fail";
            this.Fail.UseVisualStyleBackColor = true;
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.Location = new System.Drawing.Point(72, 402);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(47, 16);
            this.Pass.TabIndex = 46;
            this.Pass.TabStop = true;
            this.Pass.Text = "Pass";
            this.Pass.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15F);
            this.button2.Location = new System.Drawing.Point(244, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 44);
            this.button2.TabIndex = 43;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(81, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 44;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(72, 190);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(358, 43);
            this.richTextBox2.TabIndex = 41;
            this.richTextBox2.Text = "1、符合测试要求；";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(72, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(358, 70);
            this.richTextBox1.TabIndex = 42;
            this.richTextBox1.Text = "将动力蓄电池与充电机输出正负极反置，启动充电机输出，充电机应闭锁直流输出并发出告警提示。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "③ 检查记录";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 374);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 37;
            this.label21.Text = "④ 测试结果";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(70, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 38;
            this.label20.Text = "② 判定准则";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(70, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 12);
            this.label19.TabIndex = 39;
            this.label19.Text = "① 测试方法和要求";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 19F);
            this.label18.Location = new System.Drawing.Point(149, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 26);
            this.label18.TabIndex = 40;
            this.label18.Text = "电池反接试验";
            // 
            // dcDianChiFanUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usrRtbx);
            this.Controls.Add(this.Fail);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "dcDianChiFanUCtrl";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox usrRtbx;
        private System.Windows.Forms.RadioButton Fail;
        private System.Windows.Forms.RadioButton Pass;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
    }
}
